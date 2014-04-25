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
using BookAnyWhere.UI;
using BookAnyWhere.Logic;
using BookAnyWhere.Data;

namespace BookAnyWhere.UI
{
    public partial class Reservations : Form
    {
        DataBase db;
        List<BsonDocument> currentData;
        DataValidation validator;

        public Reservations()
        {
            this.currentData = new List<BsonDocument>();
            this.validator = new DataValidation();
            InitializeComponent();
        }

        public void setDataBase(DataBase dataBase)
        {
            this.db = dataBase;
        }

        private DateTime createDate(string date)
        {
            try
            {
                return Convert.ToDateTime(date);
            }
            catch (System.FormatException e)
            {
                this.validator.showConfirmMessage("Error en el formato de la fecha." + "\n\n" + e, "Reservaciones");
                return new DateTime();
            }
        }

        private void addReservations(List<BsonDocument> reservations)
        {
            int count = 1;

            foreach (BsonDocument doc in reservations)
            {
                this.reservationsList.Items.Add("Reservación "+count);
                count++;
            }
        }

        private void searchReservationByDate(string date)
        {
            if (this.validator.isDate(date))
            {
                DateTime Date = validator.createDate(date);//Crea fecha con formato de sistema.
                this.currentData = db.searchReservationByDate(Date).ToList();
                if (this.currentData.Count > 0)
                {
                    addReservations(this.currentData);
                }
                else
                {
                    this.validator.showConfirmMessage("No hay registros.", "Buscar Reservación");
                }

            }
            else
            {
                this.validator.showConfirmMessage("Error en el formato de la fecha.", "Buscar Vuelo");
            }


        }


        private void searchReservationByClientPassport(string passport)
        {
            this.currentData.Clear();
            this.currentData = db.searchReservationByClient(passport).ToList();
            if((this.currentData != null)&&this.currentData.Count > 0)
            {
                addReservations(this.currentData);
            }
            else
            {
                this.validator.showConfirmMessage("No hay registros.", "Buscar Reservación");
            }

        }

        //Se selecciona un filtro de búsqueda.
        private void searchButton_Click(object sender, EventArgs e)
        {
            this.reservationsList.Items.Clear();
            if (this.searchFilterBox.Text.Trim() != "")
            {
                int selectedIndex = this.comboSearchBox.SelectedIndex;
                switch (selectedIndex)
                {
                    case 0: searchReservationByDate(this.searchFilterBox.Text.Trim());
                        break;
                    case 1: searchReservationByClientPassport(this.searchFilterBox.Text.Trim());
                        break;
                }
            }
            else
            {
                this.validator.showConfirmMessage("Debe ingresar el valor a buscar.", "Buscar Reservación");
            }
        }

        private void comboSearchBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = this.comboSearchBox.SelectedIndex;
            switch (selectedIndex)
            {
                case 0: this.searchFilterBox.Text = "Día/Mes/Año";
                    this.filterLabel.Text = "Fecha:";
                    break;
                case 1: this.searchFilterBox.Clear();
                    this.filterLabel.Text = "Nombre:";
                    break;
            }
        }

        private void searchFilterBox_Click(object sender, EventArgs e)
        {
            this.searchFilterBox.Clear();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.reservationsList.Items.Clear();
            this.Dispose();
        }

        private void reservationsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.reservationsList.SelectedIndex;
            if (index >= 0)
            {
                BsonDocument selectedReservation = this.currentData.ElementAt(index);
                ReservationInfo info = new ReservationInfo(selectedReservation);
                info.setDataBase(this.db);
                info.ShowDialog();
                this.reservationsList.Items.Clear();
            }
        }
        
    }
}
