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
using System.Collections.ObjectModel;

namespace CybellesCykler
{
    /// <summary>
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        private DataController dc = new DataController(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CybellesCyklerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private ObservableCollection<Order> orderList = new ObservableCollection<Order>();
        public Orders()
        {
            DataContext = this;
            InitializeComponent();
            List<IPersistable> li = dc.GetEntities("ORDER");
            foreach (IPersistable item in li)
            {
                OrderList.Add(item as Order);
            }
        }


        public ObservableCollection<Order> OrderList
        {
            get { return orderList; }
            set { orderList = value; }
        }

    }
}
