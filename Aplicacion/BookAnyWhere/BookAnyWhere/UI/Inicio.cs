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
    public partial class Inicio : Form
    {

        private DataBase db;
        private string hour;
        private DateTime date;
        private DataValidation validator;
        BsonDocument flightInfo;
        BsonDocument clientInfo;

        public Inicio(string userName)
        {
            InitializeComponent();
            this.employeeNameLabel.Text = userName;
            this.employeeNameLabel.Visible = true;
            this.date = DateTime.Now.Date;
            this.validator = new DataValidation();
            this.hour = DateTime.Now.ToString("HH:mm:ss tt");
            this.dateValueLabel.Text = date.ToString("dd/MM/yyyy");
            this.hourValueLabel.Text = this.hour;
            this.timeTimer.Start();
        }

        public void setDataBase(DataBase dataBase)
        {
            this.db = dataBase;
            setFlightsBox();
        }


        public void setFlightInfo(BsonDocument info)
        {
            this.flightInfo = info;
            BsonDocument fecha = info["fecha"].AsBsonDocument;
            this.flightNameBox.Text = info["paisSalida"].AsString + " - " + info["paisDestino"].AsString;
            this.flightNumberBox.Text = info["_id"].AsString;
            this.departureDateBox.Text = fecha["dia"].AsInt32 +" / " + fecha["mes"].AsInt32 +" / "+ fecha["anio"].AsInt32;
            this.departureHourBox.Text = Convert.ToString(info["hora"].AsInt32);
            this.destinationBox.Text = info["paisDestino"].AsString;

        }

        public void setClientInfo(BsonDocument info)
        {
            this.clientInfo = info;
            this.clientNameBox.Text = info["nombre"].AsString + " " + info["apellido1"].AsString;
            this.clientGenderBox.Text = info["genero"].AsString;
            this.clientAgeBox.Text = Convert.ToString(info["edad"].AsInt32);
        }

        private string getSeatType()
        {
            if (this.businessClassButton.Checked)
            {
                return "Negocios";
            }
            else if (this.economyClassButton.Checked)
            {
                return "Economica";
            }
            else
            {
                return "Primera";
            }
        }

        private void clearReservation()
        {
            this.flightNameBox.Clear();
            this.flightNumberBox.Clear();
            this.departureDateBox.Clear();
            this.departureHourBox.Clear();
            this.destinationBox.Clear();
            this.clientPassportBox.Clear();
            this.clientNameBox.Clear();
            this.clientGenderBox.Clear();
            this.clientAgeBox.Clear();
            this.firstClassButton.Checked = false;
            this.businessClassButton.Checked = false;
            this.economyClassButton.Checked = false;
        }

        private void setFlightsBox()
        {
            List<BsonDocument> flightsList = this.db.getFlightsByDateAndNode(DateTime.Now, db.getNodeName()).ToList();
            if (flightsList.Count > 0)
            {
                foreach (BsonDocument flight in flightsList)
                {
                    string newFlight = "Vuelo: " + flight["_id"].AsString + " Destino: " + flight["paisSalida"].AsString +
                                        " - " + flight["paisDestino"].AsString + " Hora Salida: " + 
                                        Convert.ToString(flight["hora"].AsInt32)+"Hrs";
                    this.flightsBox.Items.Add(newFlight);
                }
            }

        }

        // 1: Pagar de una vez. 2: Sólo reservar.
        private void setReservation(int id)
        {
            BsonDocument reservation, infoCliente, fecha, seat, queue;
            List<BsonDocument> seatsArray = this.db.getSeatByFlight(this.flightInfo["_id"].AsString).ToList();
            string seatType = getSeatType();
            infoCliente = new BsonDocument {    {"idCliente", this.clientInfo["_id"]},
                                                            {"pasaporte", this.clientInfo["pasaporte"].AsString},
                                                            {"edad", this.clientInfo["edad"].AsInt32}
                                                        };
            fecha = new BsonDocument {  {"dia", this.date.Day},
                                                    {"mes", this.date.Month},
                                                    {"anio", this.date.Year}
                                                 };
            if (seatsArray.Count > 0)
            {
                BsonArray seatsIdArray = seatsArray.ElementAt(0)["asientos"].AsBsonArray;
                if (this.db.areAvailableSeatsByType(seatsIdArray, seatType))
                {
                    seat = this.db.searchSeatByType(seatsIdArray, seatType);
                    if (id == 1)
                    {
                        if (seat["estadoReservacion"].AsString.Equals("Sin Reservar"))
                        {
                            this.db.updateSeatSatuts(seat["_id"].AsInt32, "reservado");
                            this.db.removeSeatFromArray(seatsArray, seat);
                            reservation = new BsonDocument {    {"datosCliente", infoCliente},
                                                            {"fecha", fecha},
                                                            {"hora", this.hour},
                                                            {"vuelo", this.flightInfo["_id"]},
                                                            {"asiento", seat},
                                                            {"paisRegistro", this.db.getNodeName()}
                                                        };
                            this.db.addReservation(reservation);
                            this.db.updateSeatsByFlight(this.flightInfo["_id"].AsString, seatsArray);
                            this.validator.showConfirmMessage("Reservación realizada con éxito.", "Nueva Reservación");
                            clearReservation();
                        }
                        else
                        {
                            reservation = new BsonDocument {            {"_id", this.db.getNextIntegerId("reservaciones")},
                                                            {"datosCliente", infoCliente},
                                                            {"fecha", fecha},
                                                            {"hora", this.hour},
                                                            {"vuelo", this.flightInfo["_id"]},
                                                            {"asiento", -1},
                                                            {"paisRegistro", this.db.getNodeName()}
                                                        };
                            queue = new BsonDocument { {"_id", this.db.getNextIntegerId("colaReservaciones")},
                                            {"idReservacion", reservation["_id"]},
                                            {"paisRegistro", this.db.getNodeName()},
                                            {"hora", this.hour},
                                            {"fecha", fecha}};
                            this.db.addReservation(reservation);
                            this.db.addReservationToQueue(queue);
                            this.validator.showConfirmMessage("No hay asientos disponibles para el vuelo." + "\n" +
                                                            "Reservación agregada a la cola.", "Nueva Reservación");
                            clearReservation();
                        }
                    }
                    else
                    {
                        this.db.updateSeatSatuts(seat["_id"].AsInt32, "en espera");
                        this.db.removeSeatFromArray(seatsArray, seat);
                        reservation = new BsonDocument {    {"_id", this.db.getNextIntegerId("reservaciones")},
                                                            {"datosCliente", infoCliente},
                                                            {"fecha", fecha},
                                                            {"hora", this.hour},
                                                            {"vuelo", this.flightInfo["_id"]},
                                                            {"asiento", -1},
                                                            {"paisRegistro", this.db.getNodeName()}
                                                        };
                        this.db.addReservation(reservation);
                        this.db.updateSeatsByFlight(this.flightInfo["_id"].AsString, seatsArray);
                        this.validator.showConfirmMessage("Reservación realizada con éxito.", "Nueva Reservación");
                        clearReservation();
                    }
                }
                else
                {
                    reservation = new BsonDocument {            {"_id", this.db.getNextIntegerId("reservaciones")},
                                                            {"datosCliente", infoCliente},
                                                            {"fecha", fecha},
                                                            {"hora", this.hour},
                                                            {"vuelo", this.flightInfo["_id"]},
                                                            {"asiento", -1},
                                                            {"paisRegistro", this.db.getNodeName()}
                                                        };
                    queue = new BsonDocument { {"_id", this.db.getNextIntegerId("colaReservaciones")},
                                            {"idReservacion", reservation["_id"]},
                                            {"paisRegistro", this.db.getNodeName()},
                                            {"hora", this.hour},
                                            {"fecha", fecha}};
                    this.db.addReservation(reservation);
                    this.db.addReservationToQueue(queue);
                    this.validator.showConfirmMessage("No hay asientos disponibles para el vuelo." + "\n" +
                                                    "Reservación agregada a la cola.", "Nueva Reservación");
                    clearReservation();
                }
            }
            else
            {//No se agrega asiento.
                reservation = new BsonDocument {            {"_id", this.db.getNextIntegerId("reservaciones")},
                                                            {"datosCliente", infoCliente},
                                                            {"fecha", fecha},
                                                            {"hora", this.hour},
                                                            {"vuelo", this.flightInfo["_id"]},
                                                            {"asiento", -1},
                                                            {"paisRegistro", this.db.getNodeName()}
                                                        };
                queue = new BsonDocument { {"_id", this.db.getNextIntegerId("colaReservaciones")},
                                            {"idReservacion", reservation["_id"]},
                                            {"paisRegistro", this.db.getNodeName()},
                                            {"hora", this.hour},
                                            {"fecha", fecha}};
                this.db.addReservation(reservation);
                this.db.addReservationToQueue(queue);
                this.validator.showConfirmMessage("No hay asientos disponibles para el vuelo." + "\n" +
                                                "Reservación agregada a la cola.", "Nueva Reservación");
                clearReservation();

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Seeks for a client by the given passport.
        //Param passport: client passport.
        private void searchClient(string passport)
        {
            try
            {
                List<BsonDocument> result = this.db.searchUserByPassport(passport).ToList();
                if (result.Count > 0)
                {
                    BsonDocument client = result.ElementAt(0);
                    setClientInfo(client);
                }
                else
                {
                    this.validator.showConfirmMessage("Cliente no encontrado.", "Buscar Cliente");
                }
            }
            catch (System.ArgumentOutOfRangeException a)
            {
                this.validator.showConfirmMessage("Cliente no encontrado.", "Buscar Cliente");
            }

        }

        //When the search client text box is clicked.
        private void clientPassportBox_Click(object sender, EventArgs e)
        {
            this.clientPassportBox.Clear();
        }

        
        private void birthDayBox_Click(object sender, EventArgs e)
        {
            this.birthDayBox.Clear();
        }


        private void birthMonthBox_Click(object sender, EventArgs e)
        {
            this.birthMonthBox.Clear();
        }


        private void birthYearBox_Click(object sender, EventArgs e)
        {
            this.birthYearBox.Clear();
        }

        //Timer that updates the time label in the UI.
        private void timeTimer_Tick(object sender, EventArgs e)
        {
            this.hour = DateTime.Now.ToString("HH:mm:ss tt");
            this.hourValueLabel.Text = this.hour;
        }

        private void setReservationWindow()
        {
            this.Text = "Nueva Reservación";
            this.birthDayBox.Text = "Día";
            this.birthMonthBox.Text = "Mes";
            this.birthYearBox.Text = "Año";
            
        }


        //When the reservation button is clicked.
        private void ReservationButton_Click(object sender, EventArgs e)
        {
            //this.startPanel.Visible = false;
            this.reservationPanel.Visible = true;
            this.splitReservation.Visible = true;
            setReservationWindow();
            
        }


        //When the menu button(Inicio) is clicked;
        private void menuButton_Click(object sender, EventArgs e)
        {
            this.reservationPanel.Visible = false;
            this.splitReservation.Visible = false;
            this.startPanel.Visible = true;
            this.Text = "Inicio";
        }


        private void otherGenderButton_Click(object sender, EventArgs e)
        {
            if (this.otherGenderButton.Checked)
            {
                this.otherGenderBox.ReadOnly = false;
                this.otherGenderBox.Cursor = Cursors.IBeam;
            }
 
        }


        private void otherGenderButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.otherGenderButton.Checked)
            {
                this.otherGenderBox.ReadOnly = true;
                this.otherGenderBox.Clear();
                this.otherGenderBox.Cursor = Cursors.No;
            }
        }


        //When select flight button is clicked.
        private void selectFlight_Click(object sender, EventArgs e)
        {
            Flights flightsWindow = new Flights(this);
            flightsWindow.ShowDialog();
        }

        private DialogResult showQuestionMessage(string msg, string panelTitle, int id)
        {
            DialogResult res = DialogResult.None;
            switch (id)
            {
                case 1:  res = MessageBox.Show(msg, panelTitle,
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                    break;
                case 2: res = MessageBox.Show(msg, panelTitle,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    break;
            }

            return res;
        }

        //Cleans all the data inputs related to the client.
        private void clearClient()
        {
            this.clientNameBox2.Clear();
            this.clientLastName1Box.Clear();
            this.clientLastName2Box.Clear();
            this.passportBox.Clear();
            this.telephoneBox.Clear();
            this.birthDayBox.Text = "Día";
            this.birthMonthBox.Text = "Mes";
            this.birthYearBox.Text = "Año";
            this.otherGenderBox.Clear();
            this.maleButton.Checked = false;
            this.femaleButton.Checked = false;
            this.otherGenderButton.Checked = false;            
        }

        //Checks if all the necessary client information is given. 
        private bool clientCompleted()
        {
            if ((this.clientNameBox2.Text.Trim() != "") && (this.passportBox.Text.Trim() != "")
                 && (this.telephoneBox.Text.Trim() != "") && (this.clientLastName1Box.Text.Trim() != "")
                && (this.clientLastName2Box.Text.Trim() != ""))
            {
                        if ((this.birthDayBox.Text.Trim() != "") && (this.birthMonthBox.Text.Trim() != "") &&
                            (this.birthYearBox.Text.Trim() != ""))
                        {
                            if ((this.maleButton.Checked) || (this.femaleButton.Checked) || (this.otherGenderButton.Checked))
                            {
                                return true;
                            }
                            else
                            {
                                this.validator.showConfirmMessage("Debe seleccionar el género del usuario.", "Registro de Usuario");
                                return false;
                            }
                }
                else
                {
                    this.validator.showConfirmMessage("Debe ingresar el primer apellido del usuario.", "Registro de Usuario");
                    return false;
                }
            }
            else
            {
                this.validator.showConfirmMessage("Información de cliente incompleta.", "Registro de Usuario");
                return false;
            }
        }

        private bool reservationCompleted()
        {
            if ((this.flightNameBox.Text.Trim() != "") && (this.flightNumberBox.Text.Trim() != "") && (this.departureDateBox.Text.Trim() != "")
                && (this.departureHourBox.Text.Trim() != "") && (this.destinationBox.Text.Trim() != ""))
            {
                if (this.firstClassButton.Checked || this.businessClassButton.Checked || this.economyClassButton.Checked)
                {
                    if ((this.clientNameBox.Text.Trim() != "") && (this.clientGenderBox.Text.Trim() != "")
                        && (this.clientAgeBox.Text.Trim() != ""))
                    {
                        return true;
                    }
                    else
                    {
                        this.validator.showConfirmMessage("Información de cliente incompleta.", "Nueva Reservación");
                        return false;
                    }
                }
                else
                {
                    this.validator.showConfirmMessage("Debe seleccionar el tipo de vuelo.", "Nueva Reservación");
                    return false;
                }
            }
            else
            {
                this.validator.showConfirmMessage("Información del vuelo incompleta.", "Nueva Reservación");
                return false;
            }
           
        }

        //Checks if the client information given has the correct format.
        private bool clientFormatOk()
        {
            if (this.validator.isNumber(this.telephoneBox.Text.Trim()))
            {
                if (this.passportBox.Text.Trim() != "")
                {
                    if (!this.validator.isNumber(this.clientNameBox2.Text.Trim()))
                    {
                        if (!this.validator.isNumber(this.clientLastName1Box.Text.Trim()))
                        {
                            if (!this.validator.isNumber(this.clientLastName2Box.Text.Trim()))
                            {
                                if ((this.validator.isNumber(this.birthDayBox.Text.Trim())) &&
                                    (this.validator.isNumber(this.birthMonthBox.Text.Trim())) &&
                                    (this.validator.isNumber(this.birthYearBox.Text.Trim())))
                                {
                                    if (this.validator.isDate(this.birthDayBox.Text.Trim() + "/" +
                                        this.birthMonthBox.Text.Trim() + "/" + this.birthYearBox.Text.Trim()))
                                    {
                                        if (this.otherGenderButton.Checked)
                                        {
                                            if (!this.validator.isNumber(this.otherGenderBox.Text.Trim())
                                                && this.otherGenderBox.Text.Trim() != "")
                                            {
                                                return true;
                                            }
                                            else
                                            {
                                                this.validator.showConfirmMessage("Error género: Debe indicar el género. No puede contener números.", "Registro de Usuario");
                                                return false;
                                            }
                                        }
                                        return true;
                                    }
                                    else
                                    {
                                        this.validator.showConfirmMessage("Error en el formato de la fecha.", "Registro de Usuario");
                                        return false;
                                    }
                                }
                                else
                                {
                                    this.validator.showConfirmMessage("La fecha debe estar compuesta de números", "Registro de Usuario");
                                    return false;
                                }

                            }
                            else
                            {
                                this.validator.showConfirmMessage("El segundo apellido no debe contener números", "Registro de Usuario");
                                return false;
                            }
                        }
                        else
                        {
                            this.validator.showConfirmMessage("El primer apellido no debe contener números", "Registro de Usuario");
                            return false;
                        }
                    }
                    else
                    {
                        this.validator.showConfirmMessage("El primer nombre no debe contener números", "Registro de Usuario");
                        return false;
                    }
                }
                else
                {
                    this.validator.showConfirmMessage("Formato de número de pasaporte incorrecto.", "Registro de Usuario");
                    return false;
                }
            }
            else
            {
                this.validator.showConfirmMessage("Formato de número telefónico incorrecto.", "Registro de Usuario");
                return false;
            }
        }

        private string getUserGender()
        {
            if (this.maleButton.Checked)
            {
                return "Masculino";
            }
            else if (this.femaleButton.Checked)
            {
                return "Femenino";
            }
            else
            {
                return this.otherGenderBox.Text.Trim();
            }
        }

        private void addUser()
        {
            BsonDocument user = new BsonDocument { 
                    {"_id", this.db.getNextIntegerId("clientes")},
                    {"nombre", this.clientNameBox2.Text.Trim()},
                    {"apellido1", this.clientLastName1Box.Text.Trim()},
                    {"apellido2", this.clientLastName2Box.Text.Trim()},
                    {"edad", this.validator.calculateAgeFromDate(
                        this.validator.createDate(this.birthDayBox.Text.Trim()+"/"+this.birthMonthBox.Text.Trim()+"/"+
                        this.birthYearBox.Text.Trim()))},
                        {"genero", getUserGender()},
                    {"pasaporte", this.passportBox.Text.Trim()},
                    {"telefono",Convert.ToInt32(this.telephoneBox.Text.Trim())},
                    {"paisRegistro",this.db.getNodeName()}
                };
            this.db.addUser(user);
            this.validator.showConfirmMessage("Usuario registrado con éxito.", "Registro de Usuario");
            clearClient();
        }
        //When client register button is clicked.
        private void button2_Click(object sender, EventArgs e)
        {
            if (clientCompleted() && clientFormatOk())
            {
                addUser();
            }
        }

        //when search client button is clicked.
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.clientPassportBox.Text.Trim() != "")
            {
                    searchClient(this.clientPassportBox.Text.Trim());
            }
            else
            {
                this.validator.showConfirmMessage("Debe ingresar el número de pasaporte.", "Buscar Usuario");
            }
        }


        //when the reservation button is clicked.
        private void doReservationButton_Click(object sender, EventArgs e)
        {
            if (reservationCompleted())//Falta validar si hay tiquetes disponibles.
            {
                setReservation(2);
            }
        }

        private void payButton_Click(object sender, EventArgs e)
        {
            if (reservationCompleted())//Falta validar si hay tiquetes disponibles.
            {
                setReservation(1);
            }
        }

        //When the "see all reservations" button is cliked;
        private void allReservationsButton_Click_1(object sender, EventArgs e)
        {
            Reservations reservationsWindow = new Reservations();
            reservationsWindow.setDataBase(this.db);
            reservationsWindow.ShowDialog();
        }

        private void passengerInfoButton_Click(object sender, EventArgs e)
        {
            PassengerInfo passangerWindow = new PassengerInfo();
            passangerWindow.setDataBase(this.db);
            passangerWindow.ShowDialog();
        }

        private void flightsButton_Click(object sender, EventArgs e)
        {
            FlightInfo flightWindow = new FlightInfo();
            flightWindow.setDataBase(this.db);
            flightWindow.ShowDialog();
        }

        private void reservationsQueueButton_Click_1(object sender, EventArgs e)
        {
            ReservationQueue queue = new ReservationQueue();
            queue.setDataBase(this.db);
            queue.ShowDialog();
        }

    
    }
}
