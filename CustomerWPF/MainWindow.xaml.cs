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
            this.CustomerIdTextBox.Text = _data.Customers.CustomerList[_currentCustomer].CustomerID;
            this.CompanyNameTextBox.Text = _data.Customers.CustomerList[_currentCustomer].CompanyName;
            this.ContactNameTextBox.Text = _data.Customers.CustomerList[_currentCustomer].ContactName;
            this.ContactTitleTextBox.Text = _data.Customers.CustomerList[_currentCustomer].ContactTitle;
            this.PhoneTextBox.Text = _data.Customers.CustomerList[_currentCustomer].Phone;
            this.FaxTextBox.Text = _data.Customers.CustomerList[_currentCustomer].Fax;
            this.BirthdayDatePicker.SelectedDate = _data.Customers.CustomerList[_currentCustomer].Birthday;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.Shutdown();
        }

        private void NextCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            _currentCustomer = _currentCustomer + 1;
            if (_currentCustomer > _data.Customers.CustomerList.Count - 1)
            {
                _currentCustomer = 0;
            }

            DisplayCustomer();

        }

        private void PreviousCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            _currentCustomer = _currentCustomer - 1;
            if (_currentCustomer < 0)
            {
                _currentCustomer = _data.Customers.CustomerList.Count - 1;
            }

            DisplayCustomer();

        }
    }
}
