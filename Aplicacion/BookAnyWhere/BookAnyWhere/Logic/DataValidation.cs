using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace BookAnyWhere.Logic
{
    class DataValidation
    {
        public DataValidation()
        {

        }

        public bool isNumber(string str)
        {
            int num;
            return int.TryParse(str, out num);
        }

        public bool isDay(string day)
        {
            if (isNumber(day) && (0 < int.Parse(day)) && (int.Parse(day) <= 31))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isMonth(string month)
        {
            if (isNumber(month) && (0 < int.Parse(month)) && (int.Parse(month) <= 12))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isYear(string year)
        {
            if (isNumber(year) && (year.Length >= 4))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool isDate(string date)
        {
            try
            {
                date = date.Trim();
                string day = date.Substring(0, date.IndexOf("/"));
                date = date.Remove(0, date.IndexOf("/") + 1);
                string month = date.Substring(0, date.IndexOf("/"));
                date = date.Remove(0, date.IndexOf("/"));
                string year = date.Remove(0, 1);

                if (year.Trim() != "" && month.Trim() != "" && day.Trim() != "")
                {
                    if (isYear(year) && isMonth(month) && isDay(day))
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                showConfirmMessage("Error en longitud de fecha.", "Error");
                return false;
            }

        }

        public DateTime createDate(string date)
        {
            return Convert.ToDateTime(date);
        }

        //Shows a confirmation massage.
        //Param msg: message to show.
        //Param panelTitle: title of the message box.
        public void showConfirmMessage(string msg, string panelTitle)
        {
            MessageBox.Show(msg, panelTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public int calculateAgeFromDate(DateTime date)
        {
            DateTime date_now = DateTime.Now.Date;
            int currentYear = date_now.Year;

            int birthYear = date.Year;

            if (Convert.ToInt32(date.Month) <= Convert.ToInt32(date_now.Month) && Convert.ToInt32(date.Day) <= Convert.ToInt32(date_now.Day))
            {
                return currentYear - birthYear;
            }
            else
            {
                return currentYear - birthYear - 1;
            }
        }
    }
}
