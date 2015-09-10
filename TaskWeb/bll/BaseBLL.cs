using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
namespace TaskWeb.bll
{
    public class BaseBLL
    {
        private static TaskDbEntities _db = null;
        protected TaskDbEntities DB
        {
            get
            {
                if (_db == null)
                {
                    _db = new TaskDbEntities();

                }
                return _db;
            }
        }
        public BaseBLL()
        { 
        
        }

        
    }
}
