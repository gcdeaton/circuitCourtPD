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
            List<Staff> items = new List<Staff>();
            items.Add(new Staff() { userName = "JohnD", firstName = "John", lastName="Doe", email = "john@doe-family.com" });
            items.Add(new Staff() { userName = "JaneD", firstName = "Jane", lastName ="Doe", email = "jane@doe-family.com" });
            items.Add(new Staff() { userName = "SammyD", firstName = "Sammy", lastName ="Doe", email = "sammy.doe@gmail.com" });
            listView.ItemsSource = items;

        }
    }
}
