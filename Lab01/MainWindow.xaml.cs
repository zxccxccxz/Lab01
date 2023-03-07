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

namespace Lab01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ViewModel _vm;
        public MainWindow()
        {
            InitializeComponent();
            _vm = new ViewModel();
            DataContext = _vm;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button clicked!");
        }
    }
}
