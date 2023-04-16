using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarRent.Pages
{
    /// <summary>
    /// Логика взаимодействия для ConnectionPage.xaml
    /// </summary>
    public partial class ConnectionPage : Page
    {
        MainWindow mainWindow;
        Page parrentPage;

        WpfControlLibrary1.BeautifulTextBox Server = new WpfControlLibrary1.BeautifulTextBox("Server Name");
        WpfControlLibrary1.BeautifulTextBox Port = new WpfControlLibrary1.BeautifulTextBox("Port");
        WpfControlLibrary1.BeautifulTextBox DataBase = new WpfControlLibrary1.BeautifulTextBox("DataBase");
        WpfControlLibrary1.BeautifulTextBox User = new WpfControlLibrary1.BeautifulTextBox("User");
        public ConnectionPage(MainWindow mainWindow,Page parrentPage)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
            this.parrentPage = parrentPage;

            WpfControlLibrary1.BackButton Back = new WpfControlLibrary1.BackButton();
            Back.VerticalAlignment = VerticalAlignment.Center;
            Back.HorizontalAlignment = HorizontalAlignment.Left;
            Back.Margin = new Thickness(5);
            Back.MouseDown += BackClick;
            top.Children.Add(Back);

            Server.VerticalAlignment = VerticalAlignment.Top;
            Server.Margin = new Thickness(10, 10, 10, 0);
            parrent.Children.Add(Server);

            Port.VerticalAlignment = VerticalAlignment.Top;
            Port.Margin = new Thickness(10, 50, 10, 0);
            parrent.Children.Add(Port);

            DataBase.VerticalAlignment = VerticalAlignment.Top;
            DataBase.Margin = new Thickness(10, 90, 10, 0);
            parrent.Children.Add(DataBase);

            User.VerticalAlignment = VerticalAlignment.Top;
            User.Margin = new Thickness(10, 130, 10, 0);
            parrent.Children.Add(User);

            WpfControlLibrary1.CustomButton1 SetConnection = new WpfControlLibrary1.CustomButton1("Применить настройки");
            SetConnection.VerticalAlignment = VerticalAlignment.Bottom;
            SetConnection.HorizontalAlignment = HorizontalAlignment.Left;
            SetConnection.Margin = new Thickness(10, 0, 0, 10);
            SetConnection.Width = 300;
            SetConnection.Height = 40;
            SetConnection.MouseDown += delegate { SetConnectionString(Server.GetText(),Port.GetText(),DataBase.GetText(),User.GetText()); };
            parrent.Children.Add(SetConnection);
        }
        public void BackClick(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(mainWindow,parrentPage);
        }
        public void SetConnectionString(string Server = "localhost",string Port = "3308",string DataBase = "KursBD",string User = "root")
        {
            if (Server == "") Server = "localhost";
            if (Port == "") Port = "3308";
            if (DataBase == "") DataBase = "KursBD";
            if (User == "") User = "root";
            MainWindow.ConnectionString = $"server={Server};port={Port};database={DataBase};uid={User}";
            mainWindow.OpenPage(mainWindow,new Pages.LogIn(mainWindow));
            MainWindow.Timer.Start();
        }
    }
}
