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
using System.Windows.Shapes;
using Entities;
using Business;

namespace CybellesCykler
{
    /// <summary>
    /// Interaction logic for EditBike.xaml
    /// </summary>
    public partial class EditBike : Window
    {
        public Bike bike;
        public EditBike(Bike b)
        {
            InitializeComponent();
            bike = b;
            lblBikeDescription.Content = bike.BikeDescription;
            lblPricePerDay.Content = bike.PricePerDay;
            tbxBikeDescription.Text = bike.BikeDescription;
            tbxPricePerDay.Text = bike.PricePerDay.ToString();

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(tbxPricePerDay.Text, out decimal ppd) && !string.IsNullOrEmpty(tbxBikeDescription.Text))
            {
                bike.BikeDescription = tbxBikeDescription.Text;
                bike.PricePerDay = ppd;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("You must enter some description of the bike, and a price that is numbers only");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
