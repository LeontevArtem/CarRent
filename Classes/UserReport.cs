using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarRent.Classes
{
    public class UserReport
    {
        public string UserName { get; set; }
        public string Car { get; set; }
        public UserReport(string UserName, string Car)
        {
            this.UserName = UserName;
            this.Car = Car;
        }
        public static void LoadUsersReport(MainWindow mainWindow,string idUser)
        {
            try
            {
                mainWindow.UsersReportList.Clear();
                MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
                mySqlConnection.Open();
                MySqlDataReader reportQuery = Connection.Query($"Select UserName,CarManufacturer,CarModel from rents,users,cars where rents.idClient = users.idUsers and rents.idCar = cars.idCars and users.idUsers = {idUser}   order by idClient ;", mySqlConnection);
                while (reportQuery.Read())
                {
                    mainWindow.UsersReportList.Add(new Classes.UserReport(reportQuery.GetString(0), reportQuery.GetString(1) + " " + reportQuery.GetString(2)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка(Загрузка данных для отчета)", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
