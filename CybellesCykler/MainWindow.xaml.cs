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
        private bool RentersSelected = false;
        private bool BikesSelected = false;
        private DataController dc = new DataController(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCyklerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public MainWindow()
        {
            InitializeComponent();
        }
        private List<Bike> GenerateBikeList()
        {
            List<IPersistable> li = dc.GetEntities("BIKE");
            List<Bike> bikes = new List<Bike>();
            foreach (IPersistable persistable in li)
            {
                bikes.Add(persistable as Bike);
            }
            return bikes;
        }

        private List<Rentee> GenerateRenteeList()
        {
            List<IPersistable> li = dc.GetEntities("RENTEE");
            List<Rentee> renters = new List<Rentee>();
            foreach (IPersistable persistable in li)
            {
                renters.Add(persistable as Rentee);
            }
            return renters;
        }
        private void BtnShowRentees_Click(object sender, RoutedEventArgs e)
        {
            DtgSelected.ItemsSource = GenerateRenteeList();
            RentersSelected = true;
            BikesSelected = false;
        }

        private void BtnShowBikes_Click(object sender, RoutedEventArgs e)
        {
            DtgSelected.ItemsSource = GenerateBikeList();
            RentersSelected = false;
            BikesSelected = true;
        }

        private void BtnShowOrders_Click(object sender, RoutedEventArgs e)
        {
            //Needs to launch the order window.
            Orders dialog = new Orders();
            dialog.Show();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (BikesSelected)
            {
                AddBike dialog = new AddBike();
                dialog.ShowDialog();
                DtgSelected.ItemsSource = GenerateBikeList();
            }
            else if (RentersSelected)
            {
                //launch renters window
            }
            else
            {
                MessageBox.Show("You must pick a list to show, before you can add to it");
            }
            

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DtgSelected.SelectedItem is Bike)
            {
                try
                {
                    if(dc.DeleteEntity(DtgSelected.SelectedItem as Bike))
                    {
                        MessageBox.Show("Item deleted successfully");
                        DtgSelected.ItemsSource = GenerateBikeList();
                    }
                    else
                    {
                        MessageBox.Show("Item could not be deleted");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (DtgSelected.SelectedItem is Rentee)
            {
                try
                {
                    if (dc.DeleteEntity(DtgSelected.SelectedItem as Rentee))
                    {
                        MessageBox.Show("Item deleted successfully");
                        DtgSelected.ItemsSource = GenerateRenteeList();
                    }
                    else
                    {
                        MessageBox.Show("Item could not be deleted");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
             
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (BikesSelected)
            {
                EditBike dialog = new EditBike(DtgSelected.SelectedItem as Bike);
                if (dialog.ShowDialog() == true)
                {
                    dc.UpdateEntity(dialog.bike);
                    MessageBox.Show("Item updated successfully");
                    DtgSelected.ItemsSource = GenerateBikeList();
                }
            }
            if (RentersSelected)
            {
                //Launch edit renters window
            }
        }
    }
}
