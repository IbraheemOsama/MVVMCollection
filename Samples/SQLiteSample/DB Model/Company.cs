using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLiteSample.DB_Model
{
    class Company
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; private set; }
        public string Name { get; set; }

    }
}
