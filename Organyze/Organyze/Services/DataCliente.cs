#define OFFLINE_SYNC_ENABLED

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Organyze.Models;
using Organyze.Helpers;
using Xamarin.Forms;
using Organyze.Services;
using Organyze.Interfaces;

#if OFFLINE_SYNC_ENABLED
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
#endif

[assembly: Dependency(typeof(Organyze.Services.DataCliente))]
[assembly: Dependency(typeof(Organyze.ViewModels.Services.IMessageService))]
[assembly: Dependency(typeof(Organyze.ViewModels.Services.INavigationService))]
namespace Organyze.Services
{
    public class DataCliente : IDataCliente<ICliente>
    {
        static DataCliente defaultInstance = new DataCliente();
        MobileServiceClient client;

#if OFFLINE_SYNC_ENABLED
        IMobileServiceSyncTable<Cliente> todoTable;
#else
        IMobileServiceTable<Cliente> todoTable;
#endif

        const string offlineDbPath = @"localstore.db";

        public Cliente Cliente { get; set; }
        public DataCliente()
        {
            this.client = new MobileServiceClient(Constants.ApplicationURL);

#if OFFLINE_SYNC_ENABLED
            var store = new MobileServiceSQLiteStore(offlineDbPath);
            store.DefineTable<Cliente>();

            //Initializes the SyncContext using the default IMobileServiceSyncHandler.
            this.client.SyncContext.InitializeAsync(store);

            this.todoTable = client.GetSyncTable<Cliente>();
#else
            this.todoTable = client.GetTable<Cliente>();
#endif
        }

        public DataCliente DefaultManager
        {
            get
            {
                return defaultInstance;
            }
            private set
            {
                defaultInstance = value;
            }
        }

        public ICliente GetNewClienteAsync()
        {
            Cliente = new Cliente();
            return Cliente;
        }

        public MobileServiceClient CurrentClient
        {
            get { return client; }
        }

        public bool IsOfflineEnabled
        {
            get { return todoTable is Microsoft.WindowsAzure.MobileServices.Sync.IMobileServiceSyncTable<Cliente>; }
        }

        public async Task<ObservableCollection<ICliente>> GetTodoItemsAsync(bool syncItems = false)
        {
            try
            {
#if OFFLINE_SYNC_ENABLED
                if (syncItems)
                {
                    await this.SyncAsync();
                }
#endif
                IEnumerable<Cliente> items = await todoTable
                    .Where(todoItem => !todoItem.Apagado)
                    .ToEnumerableAsync();

                return new ObservableCollection<ICliente>(items);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
            }
            return null;
        }

        public async Task<bool> SaveTaskAsync(Cliente item)
        {
            if (item.Id == null)
            {
                item.CreatedAt = DateTime.Now;
                await todoTable.InsertAsync(item);
            }
            else
            {
                item.UpdatedAt = DateTime.Now;
                await todoTable.UpdateAsync(item);
            }
            return await Task.FromResult(true);
        }

#if OFFLINE_SYNC_ENABLED
        public async Task SyncAsync()
        {
            ReadOnlyCollection<MobileServiceTableOperationError> syncErrors = null;

            try
            {
                await this.client.SyncContext.PushAsync();

                await this.todoTable.PullAsync(
                    //The first parameter is a query name that is used internally by the client SDK to implement incremental sync.
                    //Use a different query name for each unique query in your program
                    "allTodoItems",
                    this.todoTable.CreateQuery());
            }
            catch (MobileServicePushFailedException exc)
            {
                if (exc.PushResult != null)
                {
                    syncErrors = exc.PushResult.Errors;
                }
            }

            // Simple error/conflict handling. A real application would handle the various errors like network conditions,
            // server conflicts and others via the IMobileServiceSyncHandler.
            if (syncErrors != null)
            {
                foreach (var error in syncErrors)
                {
                    if (error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                    {
                        //Update failed, reverting to server's copy.
                        await error.CancelAndUpdateItemAsync(error.Result);
                    }
                    else
                    {
                        // Discard local change.
                        await error.CancelAndDiscardItemAsync();
                    }

                    Debug.WriteLine(@"Error executing sync operation. Item: {0} ({1}). Operation discarded.", error.TableName, error.Item["id"]);
                }
            }
        }

#endif

    }

}
