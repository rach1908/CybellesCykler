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
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddBike: Window
    {
        private DataController dc = new DataController(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCyklerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public AddBike()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbxPricePerDay.Text, out int ppd) && !string.IsNullOrEmpty(tbxBikeDescription.Text))
            {
                Bike b = new Bike(tbxBikeDescription.Text, ppd);
                dc.NewEntity(b);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid inputs. You must enter some description, and the price must be numbers only");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
