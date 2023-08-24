using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionAPI.Models.Settings;

public class DatabaseSettings : IDatabaseSettings
{
    public string ContentCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}
