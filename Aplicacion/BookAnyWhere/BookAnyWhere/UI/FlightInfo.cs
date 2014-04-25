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
using BookAnyWhere.Logic;
using BookAnyWhere.Data;

namespace BookAnyWhere.UI
{
    public partial class FlightInfo : Form
    {
        public DataBase db;
        private DataValidation validator;
        public FlightInfo()
        {
            this.validator = new DataValidation();
            InitializeComponent();
        }
        
        public void setDataBase(DataBase dataBase)
        {
            this.db = dataBase;
        }

        private void clearInfo()
        {
            this.dateBox.Clear();
            this.departureCountryBox.Clear();
            this.destinyCountryBox.Clear();
            this.hourBox.Clear();
            this.availableSeatsBox.Clear();
            this.statusBox.Clear();
        }

        private void setDate(BsonDocument date)
        {
            this.dateBox.Text = date["dia"].AsInt32 + "/" + date["mes"].AsInt32 + "/" + date["anio"].AsInt32;
        }

        private void setFlightInfo(BsonDocument flight)
        {
            setDate(flight["fecha"].AsBsonDocument);
            this.departureCountryBox.Text = flight["paisSalida"].AsString;
            this.destinyCountryBox.Text = flight["paisDestino"].AsString;
            this.hourBox.Text = Convert.ToString(flight["hora"].AsInt32);
            this.availableSeatsBox.Text = Convert.ToString(flight["asientosDisponibles"].AsInt32);
            this.statusBox.Text = flight["estadoVuelo"].AsString;
        }
      
        private void searchFlightByDate(string date)
        {
            if (this.validator.isDate(date))
            {
                DateTime Date = validator.createDate(date);//Crea fecha con formato de sistema.
                List<BsonDocument> flights = db.getFlightsByDate(Date).ToList();
                if (flights.Count > 0)
                {
                    setFlightInfo(flights.ElementAt(0));
                }
                else
                {
                    this.validator.showConfirmMessage("No hay registros.", "Buscar Vuelo");
                }
             
            }
            else
            {
                this.validator.showConfirmMessage("Error en el formato de la fecha.", "Buscar Vuelo");
            }

        }

        //1: Salida, 2: Destino
        private void searchFlightByCountry(string country, int id)
        {
            if (!this.validator.isNumber(country))
            {
                List<BsonDocument> flights = db.getFlightsByCountry(country, id).ToList();
                if (flights.Count > 0)
                {
                    setFlightInfo(flights.ElementAt(0));
                }
                else
                {
                    this.validator.showConfirmMessage("No hay registros.", "Buscar Vuelo");
                }
            }
            else
            {
                this.validator.showConfirmMessage("El nombre del país no debe contener números.","Buscar Vuelo");
            }
 

        }


        private void comboSearchBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.comboSearchBox.SelectedIndex;

            switch (index)
            {
                case 2: this.filterBox.Text = "Día/Mes/Año";
                    this.valueLabel.Text = "Fecha:";
                    break;
                default: this.valueLabel.Text = "País:";
                    break;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string data = this.filterBox.Text.Trim();
            if (data != "")
            {
                int index = this.comboSearchBox.SelectedIndex;

                switch (index)
                {
                    case 0: searchFlightByCountry(data, 2);
                        break;
                    case 1: searchFlightByCountry(data, 1);
                        break;
                    case 2: searchFlightByDate(data);
                        break;
                }
            }
            else
            {
                this.validator.showConfirmMessage("Debe ingresar el valor a buscar.", "Buscar Vuelo");
                this.filterBox.Clear();
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void filterBox_Click(object sender, EventArgs e)
        {
            this.filterBox.Clear();
        }
    }
}
