using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using BookAnyWhere.Logic;

namespace BookAnyWhere.Data
{
    public class DataBase
    {

        private MongoServer server;
        private MongoConnection connection;
        private MongoDatabase db;
        private int node;
        private DataValidation validator;

        public DataBase(int Node)
        {
            this.validator = new DataValidation();
            try
            {
                this.node = Node;
                this.connection = new MongoConnection(Node);
                this.server = this.connection.getServer();
                this.db = this.connection.getCurrentDataBase();
            }
            catch (MongoDB.Driver.MongoConnectionException e)
            {
                this.validator.showConfirmMessage("No se puede establecer conexión al servidor", "Error de conexión"+ "\n"+
                                                    "Información adicional: "+e);
            }
        }

        public MongoConnection getConnection()
        {
            return this.connection;
        }

        //Establece el nodo donde va a establecer conexión.
        //CR: 1, PM: 2 y BR: 3.
        public void setNode(int Node)
        {
            this.node = Node;
        }

        public int getNode()
        {
            return this.node;
        }

        /*Retorna el nombre del nodo al que está conectado.
         *Retorna: String con el nombre del nodo.
         */
        public string getNodeName()
        {
            string nodeName = "";
            switch(this.node)
            {
                case 1: nodeName = "Costa Rica";
                    break;
                case 2: nodeName = "Panama";
                    break;
                case 3: nodeName = "Brasil";
                    break;
            }
            return nodeName;
        }

        /*Obtiene los vuelos por país que se desee.
         * Parametro country: País a obtener los vuelos. 
         * Parametro id: Indicador de país. 1 para salida y 2 para destino.
         * Retorna: Objeto de tipo MongoCursor con el resultado de la consulta.
         */
        public MongoCursor<BsonDocument> getFlightsByCountry(string country, int id)
        {
            this.db.Server.Connect();
            MongoCollection<BsonDocument> tiquetes = db.GetCollection<BsonDocument>("vuelos");
            MongoCursor < BsonDocument > res;
            if (id == 1)
            {
                var query = Query.EQ("paisSalida", country);
                res = tiquetes.Find(query);
                this.db.Server.Disconnect();
                return res;
            }
            else
            {             
                var query = Query.EQ("paisDestino", country);
                res = tiquetes.Find(query);
                this.db.Server.Disconnect();
                return res;
            }
        }

        /*Obtiene los vuelos por fecha
         *Parametro date: Fecha a buscar.
         * Retorna: Objeto de tipo MongoCursor con el resultado de la consulta.
         */
        public MongoCursor<BsonDocument> getFlightsByDate(DateTime date)
          {
              MongoCollection<BsonDocument> tiquetes = db.GetCollection<BsonDocument>("vuelos");
              BsonDocument Date = new BsonDocument{
                                      {"dia", date.Day},
                                      {"mes", date.Month},
                                      {"anio", date.Year}
                                  };
              var query = Query.EQ("fecha", Date);
              return tiquetes.Find(query);
          }

        /*Obtiene los vuelos por fecha
         *Parametro date: Fecha a buscar.
         * Retorna: Objeto de tipo MongoCursor con el resultado de la consulta.
         */
        public MongoCursor<BsonDocument> getFlightsByDateAndNode(DateTime date, string node)
          {
              MongoCollection<BsonDocument> tiquetes = db.GetCollection<BsonDocument>("vuelos");
              BsonDocument Date = new BsonDocument{
                                      {"dia", date.Day},
                                      {"mes", date.Month},
                                      {"anio", date.Year}
                                  };
              var query = Query.And(Query.EQ("fecha", Date), Query.EQ("paisSalida", node));
              return tiquetes.Find(query);
          }

        /*Obtiene un cliente por su pasaporte.
         *Parametro passport:Pasaporte del cliente.
         *Retorna: Objeto de tipo MongoCursor con el resultado de la consulta.
         */
        public MongoCursor<BsonDocument> searchUserByPassport(string passport)
          {
              MongoCollection<BsonDocument> clientes = db.GetCollection<BsonDocument>("clientes");
              var query = Query.EQ("pasaporte", passport);
              return clientes.Find(query);
          }


        /*Agrega un usuario a la base de datos
         *Parametro user: Es un documento Bson que contiene los datos del cliente a registrar.
         */
          public void addUser(BsonDocument user)
          {
              MongoCollection<BsonDocument> clientes = db.GetCollection<BsonDocument>("clientes");
              clientes.Insert(user);
          }

          /*Obtiene la información de un empleado cuando inicia sesión en el sistema.
           *Parámetro user: String con el nombre de usuario.
           * Retorna: Objeto de tipo MongoCursor con el resultado de la consulta.
           */
          public MongoCursor<BsonDocument> getCredentials(string user)
          {
              MongoCollection<BsonDocument> empleados = db.GetCollection<BsonDocument>("empleados");
              var query = Query.EQ("usuario", user);
              return empleados.Find(query);

          }

        /*Verifica si hay asientos de un tipo determinado en un arreglo.
         *Parámetro seatsArray: Arreglo donde se va a buscar.
         *Parámetro type: Tipo de asiento a buscar. "Primera", "Negocios", "Economica".
         *Retorna: true si existe el tipo buscado, false de lo contrario.
         */
          public bool areAvailableSeatsByType(BsonArray seatsArray, string type)
          {

              int currenId = 0;
              BsonDocument currentSeat = new BsonDocument();
              List<BsonDocument> result = new List<BsonDocument>();
              for (int i = 0; i < seatsArray.Count; i++)
              {
                  currenId = seatsArray.ElementAt(i).AsInt32;
                  result= getObjectById(currenId, "asientos").ToList();
                  if(result.Count > 0)
                  {
                      currentSeat = result.ElementAt(0);
                      if (currentSeat["tipoAsiento"].AsString.Equals(type))
                      {
                          return true; ;
                      }
                  }
              }
              return false;

          }

        /*Remueve un asiento de un arreglo de asientos.
         *Parámetro seatsArray: Arreglo de asientos(arreglo de id's) donde se va a eliminar.
         *Parámetro seat: asiento a buscar y eliminar en el arreglo.
         */
          public void removeSeatFromArray(List<BsonDocument> seatsArray, BsonDocument seat)
          {
              BsonDocument currentSeat = seatsArray.ElementAt(0);
              for (int i = 0; i < seatsArray.Count; i++)
              {
                  currentSeat = seatsArray.ElementAt(i);
                  BsonArray asientos = currentSeat["asientos"].AsBsonArray;
                  if (asientos.ElementAt(i) == seat["_id"])
                  {
                      seatsArray.Remove(currentSeat);//Se elimina el registro de la tabla.
                      return;
                  }
              }
          }

          /*Busca un asiento por el tipo deseado.
           * Parámetro seatsArray: Arreglo de asientos(arreglo de id's) a buscar el asiento.
           * Parámetro type: Tipo de asiento a buscar. "Primera", "Negocios", "Economica".
           * Retorna: Objeto de tipo BsonDocument con la información del asiento.
           */
          public BsonDocument searchSeatByType(BsonArray seatsArray, string type)
          {
              int currenId = 0;
              BsonDocument currentSeat = new BsonDocument();
              List<BsonDocument> result = new List<BsonDocument>();
              for (int i = 0; i < seatsArray.Count; i++)
              {
                  currenId = seatsArray.ElementAt(i).AsInt32;
                  result = getObjectById(currenId, "asientos").ToList();
                  if (result.Count > 0)
                  {
                      currentSeat = result.ElementAt(0);
                      if (currentSeat["tipoAsiento"].AsString.Equals(type))
                      {
                          break;
                      }
                  }
              }
              return currentSeat;
          }

          /*Obtiene el arreglo de asientos por vuelo.
           *Parámetro idFlight: Identificador del vuelo a obtener los asientos disponibles.
           *Retorna: Objeto de tipo MongoCursor con el resultado de la consulta.
           */
          public MongoCursor<BsonDocument> getSeatByFlight(string idFlight)
          {
              MongoCollection<BsonDocument> asientosPorVuelo = db.GetCollection<BsonDocument>("asientosPorVuelo");
              var query = Query.EQ("idVuelo", idFlight);
              return asientosPorVuelo.Find(query);
          }

        //Convierte lista de asientos a array de tipo Bson de asientos.
          public BsonArray toBsonArray(List<BsonDocument> array)
          {
              BsonArray newArray = new BsonArray();
              foreach(BsonDocument docu in array)
              {
                  BsonDocument newDocu = new BsonDocument { {"_id", docu["_id"]},
                                                            {"estadoReservacion", docu["estadoReservacion"]},
                                                            {"tipoAsiento", docu["tipoAsiento"]},
                                                            {"precio", docu["precio"]}};
                  newArray.Add(newDocu);

              }
              return newArray;
          }

        //Actualiza el estado de un asiento.(atomica)
          public void updateSeatSatuts(int idSeat, string status)
          {
              MongoCollection<BsonDocument> asientos = db.GetCollection<BsonDocument>("asientos");
              var query = Query.EQ("_id", idSeat);
              var sortBy = SortBy.Descending("precio");
              var update = Update.Set("estado", status);
              var result = asientos.FindAndModify(query,sortBy, update);
          }

          public void updateSeatsByFlight(string idFlight, List<BsonDocument> seatsArray)
          {
              MongoCollection<BsonDocument> asientosPorVuelo = db.GetCollection<BsonDocument>("asientosPorVuelo");
              var query = Query.EQ("idVuelo", idFlight);
              var sortBy = SortBy.Descending("_id");
              var update = Update.Set("asientos", toBsonArray(seatsArray));
              var result = asientosPorVuelo.FindAndModify(query, sortBy,update);

          }

          public void addReservationToQueue(BsonDocument reservation)
          {
              MongoCollection<BsonDocument> cola = db.GetCollection<BsonDocument>("colaReservaciones");
              cola.Insert(reservation);

          }

        public void addReservation(BsonDocument reservation)
        {
            MongoCollection<BsonDocument> reservaciones = db.GetCollection<BsonDocument>("reservaciones");
            reservaciones.Insert(reservation);
        }

        public string getRegisterId(BsonDocument docu)
        {
            return docu["_id"].AsString;
        }

        public int getNextIntegerId(string tableName)
        {
            MongoCollection<BsonDocument> table = db.GetCollection<BsonDocument>(tableName);
            List<BsonDocument> allDocs = table.FindAll().ToList();
            if (allDocs.Count > 0)
            {
                int nextId = 0;
                for (int i = 0; i < allDocs.Count; i++)
                {
                    BsonDocument currentElement = allDocs.ElementAt(i);
                    int currentId = currentElement["_id"].AsInt32;
                    if (currentId > nextId)
                    {
                        nextId = currentId;
                    }
                }
                return nextId + 1;
            }
            return 1;
        }

        public MongoCursor<BsonDocument> getReservationQueue()
        {
            MongoCollection<BsonDocument> queue = db.GetCollection<BsonDocument>("colaReservaciones");
            var sortBy = SortBy.Descending("fecha");
            return queue.FindAll().SetSortOrder(sortBy);
        }

        private bool isInQueue(int id)
        {
            List<BsonDocument> reservations = getReservationQueue().ToList();
            bool inQueue = false;
            foreach (BsonDocument doc in reservations)
            {
                if(doc["idReservacion"].AsInt32 == id)
                {
                    inQueue = true;
                }
            }
            return inQueue;
        }

        private BsonDocument getReservationFromQueue()
        {
            List<BsonDocument> queue = getReservationQueue().ToList();
            return queue.ElementAt(0);
        }

        private int getReservationInQueue(int id)
        {
            MongoCollection<BsonDocument> queue = db.GetCollection<BsonDocument>("colaReservaciones");
            List<BsonDocument> queueElements = queue.FindAll().ToList();
            foreach (BsonDocument doc in queueElements)
            {
                if (doc["idReservacion"].AsInt32 == id)
                {
                    return doc["_id"].AsInt32;
                }
            }
            return -1;
        }

        //Elimina reservación.
        //id: Id de la reservación.
        public void removeRservation(int id)
        {
            MongoCollection<BsonDocument> reservaciones = db.GetCollection<BsonDocument>("reservaciones");
            int idQueue = getReservationInQueue(id) ;
            if (idQueue > 0)
            {
                var query = Query.EQ("_id", id);
                reservaciones.Remove(query);
                removeRservationFromQueue(id);
            }
            else
            {
                var query = Query.EQ("_id", id);
                reservaciones.Remove(query);
            }
        }

        //Elimina reservación de la cola.
        //id: Id de la reservación de cola a eliminar.
        public void removeRservationFromQueue(int id)
        {
            MongoCollection<BsonDocument> queueTable = db.GetCollection<BsonDocument>("colaReservaciones");
            var query = Query.EQ("_id", id);
            queueTable.Remove(query);
        }

        public MongoCursor<BsonDocument> getObjectById(int id, string tableName)
        {
            MongoCollection<BsonDocument> table = db.GetCollection<BsonDocument>(tableName);
            var query = Query.EQ("_id", id);
            return table.Find(query);
        }

        public MongoCursor<BsonDocument> searchReservationByDate(DateTime date)
        {
            MongoCollection<BsonDocument> reservaciones = db.GetCollection<BsonDocument>("reservaciones");
            BsonDocument Date = new BsonDocument{
                                      {"dia", date.Day},
                                      {"mes", date.Month},
                                      {"anio", date.Year}
                                  };
            var query = Query.EQ("fecha", Date);
            return reservaciones.Find(query);
        }

        public MongoCursor<BsonDocument> searchReservationByClient(string passport)
        {
            MongoCollection<BsonDocument> clientes = db.GetCollection<BsonDocument>("clientes");
            MongoCollection<BsonDocument> reservaciones = db.GetCollection<BsonDocument>("reservaciones");
            var query = Query.EQ("pasaporte", passport);
            List<BsonDocument> result = clientes.Find(query).ToList();
            if (result.Count > 0)
            {
                int id = result.ElementAt(0)["_id"].AsInt32;
                int edad = result.ElementAt(0)["edad"].AsInt32;
                BsonDocument doc = new BsonDocument { { "idCliente", id }, { "pasaporte", passport }, { "edad", edad } };
                var query2 = Query.EQ("datosCliente", doc);
                return reservaciones.Find(query2);
            }
            else
            {
                return null;
            }
        }

     }
}
