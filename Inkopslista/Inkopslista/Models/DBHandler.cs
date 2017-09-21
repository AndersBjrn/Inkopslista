using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inkopslista.Models
{
    public class DBHandler
    {
        private static void CreateDatabase()
        {
            var cfg = DbService.Configure();
            var export = new SchemaExport(cfg);
            export.Create(true, true);
        }

        private static void DeleteDatabase()
        {
            var cfg = DbService.Configure();
            var export = new SchemaExport(cfg);
            export.Drop(false, true);
        }
    }
}