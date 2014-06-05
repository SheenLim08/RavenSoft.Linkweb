using RavenSoft.Linkweb.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RavenSoft.Linkweb.Test
{
    public static class DatabaseInstanceTest
    {
        public static LinkwebEntities Database;

        public static LinkwebEntities InitializeDatabase()
        {
            if (Database == null)
                Database = new LinkwebEntities();

            return Database;
        }
    }
}
