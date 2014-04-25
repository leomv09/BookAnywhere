using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Windows.Forms;
using BookAnyWhere.Data;
using BookAnyWhere.Logic;

namespace BookAnyWhere.UI
{
    public partial class ReservationQueue : Form
    {
        DataBase db;
        DataValidation validator;
        List<BsonDocument> currentData;
        bool hayRegistros;

        public ReservationQueue()
        {
            InitializeComponent();
            this.hayRegistros = false;
            this.validator = new DataValidation();
        }

        public void setDataBase(DataBase dataBase)
        {
            this.db = dataBase;
            getReservations();
        }

        private void addReservations()
        {
            this.reservationList.Items.Clear();
            int count = 1;
            foreach(BsonDocument doc in this.currentData)
            {
                string item = "Reservación " + Convert.ToString(doc["_id"].AsInt32);
                this.reservationList.Items.Add(item);
                count++;
            }
        }

        private void showReservation(int idReservation, int idQueueReservation)
        {
            List<BsonDocument> reservation = this.db.getObjectById(idReservation, "reservaciones").ToList(); 
            if(reservation.Count > 0)
            {
                BsonDocument res = reservation.ElementAt(0);
                ReservationInfo info = new ReservationInfo(res);
                info.setDataBase(this.db);
                info.setQueue(true, idQueueReservation);
                info.ShowDialog();
                this.reservationList.Items.Clear();
                getReservations();
            }
        }

        private void getReservations()
        {
            this.currentData = this.db.getReservationQueue().ToList();

            if (this.currentData.Count > 0)
            {
                this.hayRegistros = true;
                addReservations();
            }
            else
            {
                this.hayRegistros = false;
                this.reservationList.Items.Add("No hay registros.");
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.currentData.Clear();
            this.reservationList.Items.Clear();
            this.Dispose();
        }

        private void reservationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.hayRegistros)
            {
                int index = this.reservationList.SelectedIndex;
                if (index >= 0)
                {
                    BsonDocument selectedRes = this.currentData.ElementAt(index);
                    showReservation(selectedRes["idReservacion"].AsInt32, selectedRes["_id"].AsInt32);
                }
            }
            else
            {
                this.validator.showConfirmMessage("No hay registros en la cola para mostrar.", "Cola de Reservaciones");
            }
        }
    }
}
