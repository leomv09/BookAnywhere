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
    public partial class Login : Form
    {
        private static string userName;
        private DataValidation validator;
        public static DataBase db;


        public Login()
        {
            this.validator = new DataValidation();
            InitializeComponent();
        }

        private void setDataBase(int node)
        {
            try
            {
                Login.db = new DataBase(node);
            }
            catch (MongoDB.Driver.MongoConnectionException e)
            {
                this.validator.showConfirmMessage("No se puede establecer conexión al servidor", "Error de conexión" + "\n" +
                                                    "Información adicional: " + e);
            }
        }

        private bool loginCompleted()
        {
            if ((this.userNameBox.Text.Trim() != "") && (this.passwordBox.Text.Trim() != ""))
            {
                if (this.crButton.Checked || this.pmButton.Checked || this.brButton.Checked)
                {
                    return true;
                }
                else
                {
                    this.validator.showConfirmMessage("Debe seleccionar el país.", "Login");
                    return false;
                }
            }
            else
            {
                this.validator.showConfirmMessage("Debe ingresar todos los datos.", "Login");
                return false;
            }
        }

        private void setNode()
        {
            if(this.crButton.Checked)
            {
                setDataBase(1);
                Login.db.setNode(1);
                return;
            }
            else if (this.pmButton.Checked)
            {
                setDataBase(2);
                Login.db.setNode(2);
                return;
            }
            else
            {
                setDataBase(3);
                Login.db.setNode(3);
                return;
            }
        }

        public static void ThreadProc()
        {
            Inicio inicio = new Inicio(Login.userName);
            inicio.setDataBase(db);
            Application.Run(inicio);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (loginCompleted())
            {
                try
                {
                    setNode();
                    List<BsonDocument> query = Login.db.getCredentials(this.userNameBox.Text.Trim()).ToList();
                    BsonDocument result = query.ElementAt(0);
                    string password = result["password"].AsString;
                    if (password.Equals(this.passwordBox.Text.Trim()))
                    {
                        Login.userName = result["nombre"].AsString + " " + result["apellido"].AsString;
                        System.Threading.Thread app = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
                        app.Start();
                        this.Close();    
                    }
                    else
                    {
                        this.validator.showConfirmMessage("Nombre de usuario o cntraseña incorrectos.", "Login");
                    }
                }
                catch (System.ArgumentOutOfRangeException a)
                {
                    this.validator.showConfirmMessage("Nombre de usuario o cntraseña incorrectos.", "Login");
                }
                catch (MongoDB.Driver.MongoConnectionException a)
                {
                    this.validator.showConfirmMessage("No se puede establecer conexión al servidor. Verifique que el servicio de MongoDB esté activo."+ "\n\n" +
                                                        "Información adicional: " +"\n"+ a, "Error de conexión");
                }
            }
        }
    }
}
