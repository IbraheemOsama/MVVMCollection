using SQLite;
using SQLiteSample.DB_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteSample.Services
{
    class DBServices
    {
        //Singleton
        private static SQLiteAsyncConnection _SQLiteConnector;
        public static SQLiteAsyncConnection SQLiteConnector
        {
            get
            {
                if (_SQLiteConnector == null)
                {
                    _SQLiteConnector = new SQLiteAsyncConnection("sqlDB.lite");

                }
                return _SQLiteConnector;
            }
        }

        public static async Task CreateTables()
        {
            await SQLiteConnector.CreateTableAsync<Company>();
        }
    }
}
