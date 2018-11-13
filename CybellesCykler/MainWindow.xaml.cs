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
using Business;
using Entities;
namespace CybellesCykler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataController dc = new DataController(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCyklerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnShowRentees_Click(object sender, RoutedEventArgs e)
        {
            List<IPersistable> li = dc.GetEntities("RENTEE");
            List<Rentee> renters = new List<Rentee>();
            foreach (IPersistable persistable in li)
            {
                renters.Add(persistable as Rentee);
            }
            DtgSelected.ItemsSource = renters;
        }

        private void BtnShowBikes_Click(object sender, RoutedEventArgs e)
        {
            List<IPersistable> li = dc.GetEntities("BIKE");
            List<Bike> bikes = new List<Bike>();
            foreach (IPersistable persistable in li)
            {
                bikes.Add(persistable as Bike);
            }
            DtgSelected.ItemsSource = bikes;
        }

        private void BtnShowOrders_Click(object sender, RoutedEventArgs e)
        {
            List<IPersistable> li = dc.GetEntities("ORDER");
            List<Order> orders = new List<Order>();
            foreach (IPersistable persistable in li)
            {
                orders.Add(persistable as Order);
            }
            DtgSelected.ItemsSource = orders;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
