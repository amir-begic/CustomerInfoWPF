﻿using System;
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
            this.CustomerListBox.ItemsSource = _data.Customers.CustomerList;
            _currentCustomer = 0;
            DisplayCustomer();
        }

        private void DisplayCustomer()
        {
            this.DataContext = _data.Customers.CustomerList[_currentCustomer];
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            _data.Save();
            this.Close();
            Application.Current.Shutdown();
        }

        private void CustomerListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox != null)
            {
                this.DataContext = listBox.SelectedItem;
            }
        }
    }
}
