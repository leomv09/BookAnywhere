using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using BookAnyWhere.Logic;

namespace BookAnyWhere.Data
{
    public class MongoConnection
    {
        private MongoServer server;
        public bool isConnected;
        private MongoDatabase db;
        DataValidation validator;
        
        public MongoConnection(int node)
        {
            this.validator = new DataValidation();
            try
            {
                /*string connectionString = "";
                switch (node)
                {
                    case 1: connectionString = "mongodb://SERVER1:27017";
                        break;
                    case 2: connectionString = "mongodb://SERVER2:27017";
                        break;
                    case 3: connectionString = "mongodb://SERVER3:27017";
                        break;
                }
                MongoClient client = new MongoClient(connectionString);*/
                MongoClient client = new MongoClient(); // connect to localhost
                this.server = client.GetServer();
                this.db = this.server.GetDatabase("BookAnywhere");
                this.isConnected = true;
            }
            catch (MongoDB.Driver.MongoConnectionException e)
            {
                this.validator.showConfirmMessage("No hay conexión al servidor", "Error de conexión");
                this.isConnected = false;
            }
            
        }

        public void setDataBase(string dataBaseName)
        {
            this.db = this.server.GetDatabase(dataBaseName);
        }

        public MongoServer getServer()
        {
            return this.server;
        }

        public MongoDatabase getCurrentDataBase()
        {
            return this.db;
        }



    }
}
