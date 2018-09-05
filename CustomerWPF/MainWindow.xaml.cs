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
        private Data _data;
        private int _currentCustomer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            this._data = Data.Load();
            _currentCustomer = 0;
            DisplayCustomer();

        }

        private void DisplayCustomer()
        {
            var customer = _data.Customers.CustomerList[_currentCustomer];

            this.CustomerIdTextBox.Text = customer.CustomerID;
            this.CompanyNameTextBox.Text = customer.CompanyName;
            this.ContactNameTextBox.Text = customer.ContactName;
            this.ContactTitleTextBox.Text = customer.ContactTitle;
            this.PhoneTextBox.Text = customer.Phone;
            this.FaxTextBox.Text = customer.Fax;
            this.BirthdayDatePicker.SelectedDate = customer.Birthday;
        }

        private void SaveCustomer()
        {
            var customer = _data.Customers.CustomerList[_currentCustomer];

            customer.CustomerID = this.CustomerIdTextBox.Text;
            customer.CompanyName = this.CompanyNameTextBox.Text;
            customer.ContactName = this.ContactNameTextBox.Text;
            customer.ContactTitle = this.ContactTitleTextBox.Text;
            customer.Phone = this.PhoneTextBox.Text;
            customer.Fax = this.FaxTextBox.Text;
            customer.Birthday = this.BirthdayDatePicker.SelectedDate;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            SaveCustomer();
            _data.Save();
            this.Close();
            Application.Current.Shutdown();
        }

        private void NextCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            SaveCustomer();
            _currentCustomer = _currentCustomer + 1;
            if (_currentCustomer > _data.Customers.CustomerList.Count - 1)
            {
                _currentCustomer = 0;
            }
            DisplayCustomer();

        }

        private void PreviousCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            SaveCustomer();
            _currentCustomer = _currentCustomer - 1;
            if (_currentCustomer < 0)
            {
                _currentCustomer = _data.Customers.CustomerList.Count - 1;
            }
            DisplayCustomer();

        }
    }
}
