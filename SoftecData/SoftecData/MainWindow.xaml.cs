﻿using SoftecData.Pages;
using SoftecData.Services;
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

namespace SoftecData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DataRepository _repository;

        public MainWindow()
        {
            InitializeComponent();
            _repository = new DataRepository();
            _repository.FetchData();

            _mainFrame.Navigate(new HomePage());
            //_mainFrame.Navigate(new AddDataPage());
        }

    }

    public class User
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Mail { get; set; }
    }
}
