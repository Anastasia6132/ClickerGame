using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClickerGame
{
    [Table("Items")]
    public class DBProgress
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string login { get; set; }
        public int balance { get; set; }
        public int upgr { get; set; }
    }/*
   
        public class BaseDatos
        {
            SQLiteConnection database;
            public BaseDatos(string databasePath)
            {
                database = new SQLiteConnection(databasePath);
                database.CreateTable<DBProgress>();
            }
            public IEnumerable<DBProgress> GetItems()
            {
                return database.Table<DBProgress>().ToList();
            }
            public DBProgress GetItem(string id)
            {
                return database.Get<DBProgress>(id);
            }
            public int DeleteItem(int id)
            {
                return database.Delete<DBProgress>(id);
            }
            public void SaveItem(DBProgress item)
            {
                if (item.login != "")
                {
                    database.Update(item);
                   // return item.login;
                }
                else
                {
                    database.Insert(item);
                }
            }
        }*/

    public class BaseDatos
    {
        private readonly SQLiteAsyncConnection db;

        public BaseDatos(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<DBProgress>();
        }

        public void CreateProgress(DBProgress dbpr) { 
        
         db.InsertAsync(dbpr);
        
        }

        public void UpdateProgress(DBProgress dbpr)
        {

           db.UpdateAsync(dbpr);

        }

        public Task <List<DBProgress>> SelectProgress()
        {

            return db.Table<DBProgress>().ToListAsync(); ;

        }

    

    }




    }

