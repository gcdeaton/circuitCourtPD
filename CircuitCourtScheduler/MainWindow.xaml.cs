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

namespace CircuitCourtScheduler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void menuItemAddDefender_Click(object sender, RoutedEventArgs e)
        {
            addDefender addDefenderWindow = new addDefender();
            addDefenderWindow.ShowDialog();
        }

        private void menuItemAddStaff_Click(object sender, RoutedEventArgs e)
        {
            addStaff addStaffWindow = new addStaff();
            addStaffWindow.ShowDialog();
        }
    }
}
