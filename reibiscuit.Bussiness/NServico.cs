using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using reibiscuit.Bussiness.Model;

namespace reibiscuit.Bussiness
{
    public class NServico
    {
        private NServico()
        {
        }
        private static DataModelDataContext db;
        public static DataModelDataContext Db
        {
            get { return db ?? (db = new DataModelDataContext()); }
        }
    }
}
