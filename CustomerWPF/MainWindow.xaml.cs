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
using Datasource;

namespace CustomerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Data data;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            this.data = Data.Load();
            DisplayCustomer(0);

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.Shutdown();
        }

        private void DisplayCustomer(int index)
        {
            this.CustomerIdTextBox.Text = data.Customers.CustomerList[index].CustomerID;
            this.CompanyNameTextBox.Text = data.Customers.CustomerList[index].CompanyName;
            this.ContactNameTextBox.Text = data.Customers.CustomerList[index].ContactName;
            this.ContactTitleTextBox.Text = data.Customers.CustomerList[index].ContactTitle;
            this.PhoneTextBox.Text = data.Customers.CustomerList[index].Phone;
            this.FaxTextBox.Text = data.Customers.CustomerList[index].Fax;
            this.BirthdayDatePicker.SelectedDate = data.Customers.CustomerList[index].Birthday;
        }
    }
}
