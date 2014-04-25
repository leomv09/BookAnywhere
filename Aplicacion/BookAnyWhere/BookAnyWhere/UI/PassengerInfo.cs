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
using BookAnyWhere.Logic;
using BookAnyWhere.Data;

namespace BookAnyWhere.UI
{
    public partial class PassengerInfo : Form
    {
        private DataBase db;
        DataValidation validator;

        public PassengerInfo()
        {
            this.validator = new DataValidation();
            InitializeComponent();
        }

        public void setDataBase(DataBase dataBase)
        {
            this.db = dataBase;
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void setClient(BsonDocument client)
        {
            this.nameBox.Text = client["nombre"].AsString;
            this.lastName1Box.Text = client["apellido1"].AsString;
            this.lastName2Box.Text = client["apellido2"].AsString;
            this.ageBox.Text = Convert.ToString(client["edad"].AsInt32);
            this.genderBox.Text = client["genero"].AsString;
            this.telephoneNumberBox.Text = Convert.ToString(client["telefono"].AsInt32);
            this.countryBox.Text = client["paisRegistro"].AsString;
        }

        private void searchUserByPassport(string passport)
        {
            List<BsonDocument> result = this.db.searchUserByPassport(passport).ToList();
            if (result.Count > 0)
            {
                if (result.Count <= 1)
                {
                    setClient(result.ElementAt(0));
                }
                else
                {
                    this.validator.showConfirmMessage("Cliente duplicado", "Buscar Pasajero");
                }
            }
            else
            {
                this.validator.showConfirmMessage("Cliente no encontrado", "Buscar Pasajero");
            }

        }

        //When the search button is clicked;
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.passportBox.Text.Trim() != "")
            {
                    searchUserByPassport(this.passportBox.Text.Trim());
            }
            else
            {
                this.validator.showConfirmMessage("Debe ingresar el número de pasaporte.", "Buscar Pasajero");
            }
            
        }
    }
}
