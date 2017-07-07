using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Organyze.Controls
{
    public class Group<TKey, TItem> : ObservableCollection<TItem>
    {
        public TKey Key { get; private set; }

        public Group(TKey key, IEnumerable<TItem> items)
        {
            Key = key;
            foreach (var item in items)
                Items.Add(item);
        }
    }
}

