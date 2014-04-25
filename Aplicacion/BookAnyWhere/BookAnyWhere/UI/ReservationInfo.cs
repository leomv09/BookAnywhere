using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using BookAnyWhere.Data;
using BookAnyWhere.Logic;

namespace BookAnyWhere.UI
{
    public partial class ReservationInfo : Form
    {
        DataBase db;
        DataValidation validator;
        BsonDocument currentData;
        bool inQueue;
        int queueId;

        public ReservationInfo(BsonDocument info)
        {
            InitializeComponent();
            this.inQueue = false;
            this.validator = new DataValidation();
            this.currentData = info;
        }

        public void setDataBase(DataBase dataBase)
        {
            this.db = dataBase;
            setInfo(this.currentData);
        }

        public void setQueue(bool value, int id)
        {
            this.inQueue = value;
            this.queueId = id;
        }


        private void clearInfo()
        {
            this.clientBox.Clear();
            this.dateBox.Clear();
            this.hourBox.Clear();
            this.flightBox.Clear();
            this.seatBox.Clear();
            this.countryBox.Clear();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            clearInfo();
            this.Dispose();
        }

        private void setSeatInfo(BsonDocument seat)
        {
            this.seatBox.Text = seat["tipoAiento"].AsString;
        }

        private void setClientInfo(BsonDocument client)
        {
            List<BsonDocument> result = this.db.getObjectById(client["idCliente"].AsInt32, "clientes").ToList();
            if (result.Count > 0)
            {
                this.clientBox.Text = result.ElementAt(0)["nombre"].AsString + " " + result.ElementAt(0)["apellido1"].AsString;
            }
        }

        //1 para reservaciones normales, 2 para reservaciones de cola.
        private void setInfo(BsonDocument info)
        {
            BsonDocument fecha = info["fecha"].AsBsonDocument;
            BsonDocument datosCliente = info["datosCliente"].AsBsonDocument;
            List<BsonDocument> result = this.db.getObjectById(datosCliente["idCliente"].AsInt32, "clientes").ToList();
            if (result.Count > 0)
            {
                BsonDocument cliente = result.ElementAt(0);
                this.clientBox.Text = cliente["nombre"].AsString + " " + cliente["apellido1"].AsString;
                this.dateBox.Text = fecha["dia"].AsInt32 + "/" + fecha["mes"].AsInt32 + "/" + fecha["anio"].AsInt32;
                this.hourBox.Text = info["hora"].AsString;
                this.flightBox.Text = info["vuelo"].AsString;
                this.countryBox.Text = info["paisRegistro"].AsString;
                if (info["asiento"] != -1)
                {
                    setSeatInfo(info["asiento"].AsBsonDocument);

                }
                else
                {
                    this.seatBox.Text = "En espera";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.db.removeRservation(this.currentData["_id"].AsInt32);
            if (this.inQueue)
            {
                this.db.removeRservationFromQueue(this.queueId);
            }
            this.validator.showConfirmMessage("Reservación eliminada", "Eliminar Reservación");
            clearInfo();
        }

        private void clientBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
