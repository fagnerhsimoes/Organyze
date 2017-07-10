using System;

namespace Organyze.Interfaces
{
    public interface IBaseDataObject
    {
        string         Id        { get; set; }
        DateTimeOffset CreatedAt { get; set; }
        DateTimeOffset UpdatedAt { get; set; }
        string         Version   { get; set; }
    }
}


