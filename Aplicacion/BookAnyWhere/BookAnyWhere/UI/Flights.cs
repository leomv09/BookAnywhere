using System;
using System.Collections;
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
using BookAnyWhere.Logic;
using BookAnyWhere.Data;

namespace BookAnyWhere.UI
{
    public partial class Flights : Form
    {
        DataBase db;
        DataValidation validator;
        List<BsonDocument> currentData;
        Inicio parent;
        public Flights(Inicio Parent)
        {
            this.parent = Parent;
            this.currentData = new List<BsonDocument>();
            this.db = new DataBase(1);
            this.validator = new DataValidation();
            InitializeComponent();
        }

        public void setDataBase(DataBase dataBase)
        {
            this.db = dataBase;
        }

        private void selecFlightButton_Click(object sender, EventArgs e)
        {
            if (this.flightsList.SelectedIndex >= 0)
            {
                int index = this.flightsList.SelectedIndex;
                BsonDocument selectedFlight = this.currentData.ElementAt(index);
                this.parent.setFlightInfo(selectedFlight);
                this.Dispose();
            }
            else
            {
                this.validator.showConfirmMessage("Debe seleccionar el vuelo.","BuscarVuelo");
            }
        }

        /*Función que consulta a la base de datos los vuelos por país
         *Parametro country: Nombre del país a buscar.
         *Parametro id: Indicador de país. 1 para país de salida y 2 para país destino.
         */
        private void searchFlifhtByCountry(string country, int id)
        {
            if (!this.validator.isNumber(country))
            {
                try
                {
                    this.currentData.Clear();
                    if (id == 1)
                    {
                        this.flightsList.Items.Clear();
                        this.currentData = db.getFlightsByCountry(country, 1).ToList();
                        foreach (BsonDocument ticket in this.currentData)
                        {
                            string tiquete = ticket["paisSalida"].AsString + " - " + ticket["paisDestino"].AsString;
                            this.flightsList.Items.Add(tiquete);
                        }
                    }
                    else
                    {
                        this.flightsList.Items.Clear();
                        this.currentData = db.getFlightsByCountry(country, 2).ToList();
                        foreach (BsonDocument ticket in this.currentData)
                        {
                            string tiquete = ticket["paisSalida"].AsString + " - " + ticket["paisDestino"].AsString;
                            this.flightsList.Items.Add(tiquete);
                        }

                    }
                }
                catch (MongoDB.Driver.MongoConnectionException e)
                {
                    this.validator.showConfirmMessage("No se puede establecer conexión con la base de datos.", "Seleccionar Vuelo");
                }
            }
            else
            {
                this.validator.showConfirmMessage("El nombre del pais no debe contener números.", "Seleccionar Vuelo");
            }
        }


        private void searchFlightByDate(string date)
        {
            if (this.validator.isDate(date))
            {
                this.currentData.Clear();
                DateTime Date = validator.createDate(date);//Crea fecha con formato de sistema.
                this.currentData = db.getFlightsByDate(Date).ToList();
                this.flightsList.Items.Clear();
                foreach(BsonDocument flight in this.currentData)
                {
                    string item = flight["paisSalida"].AsString + " - " + flight["paisDestino"].AsString;
                    this.flightsList.Items.Add(item);
                }
            }
            else
            {
                this.validator.showConfirmMessage("Error en el formato de la fecha.", "Seleccionar Vuelo");
            }

        }


        private void comboSearchBox_SelectedValueChanged(object sender, EventArgs e)
        {
            int index = this.comboSearchBox.SelectedIndex;

            switch (index)
            {
                case 2: this.valueLabel.Text = "Fecha:";
                        this.searchBox.Text = "Día/Mes/Año";
                    break;
                case 3: this.valueLabel.Text = "Hora:";
                    this.searchBox.Text = "0 - 24";
                    break;
                default: this.valueLabel.Text = "País:"; 
                    break;

            }
        }

        private void searchBox_Click(object sender, EventArgs e)
        {
            this.searchBox.Clear();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int index = this.comboSearchBox.SelectedIndex;
            string filterInfo = this.searchBox.Text.Trim();
            if (filterInfo != "")
            {
                switch (index)
                {
                    case 0: searchFlifhtByCountry(filterInfo, 2);
                        break;
                    case 1: searchFlifhtByCountry(filterInfo, 1);
                        break;
                    case 2: searchFlightByDate(filterInfo); ;
                        break;

                }
            }
            else
            {
                this.validator.showConfirmMessage("Debe ingresar el valor a buscar.","Buscar Vuelo");
            }
        }

        private void flightsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selecFlightButton.Enabled = true;
        }

        
    }
}
