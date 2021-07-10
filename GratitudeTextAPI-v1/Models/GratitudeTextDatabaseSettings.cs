using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GratitudeTextAPI_v1.Models
{
    public class GratitudeTextDatabaseSettings : IGratitudeTextDatabaseSettings
    {
            public string GratitudesCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
    }

        public interface IGratitudeTextDatabaseSettings
        {
            string GratitudesCollectionName { get; set; }
            string ConnectionString { get; set; }
            string DatabaseName { get; set; }
        }
}
