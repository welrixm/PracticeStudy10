using PracticeStudy.Components;
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

namespace PracticeStudy.Pages
{
    /// <summary>
    /// Логика взаимодействия для DecorationOrderPage.xaml
    /// </summary>
    public partial class DecorationOrderPage : Page
    {
        Product product;
        Order order;
        public DecorationOrderPage()
        {

            InitializeComponent();
            //order = _order;
            ProductListViu.ItemsSource = DBConnect.db.Product.ToList();
        }
        public static void refrashe()
        {

        }

        private void ViborBt_Click(object sender, RoutedEventArgs e)
        {
            if (ProductListViu.SelectedItem != null)
            {
                ProductOrder productOrder = new ProductOrder();
                product = ProductListViu.SelectedItem as Product;
                productOrder.ProductId = product.Id;
                productOrder.OrderId = order.Id;
                Random rnd = new Random();
                productOrder.Id = rnd.Next(0, 109999009);
                DBConnect.db.ProductOrder.Add(productOrder);
                DBConnect.db.SaveChanges();
                MessageBox.Show("Добавлено!");
            }
            else
            {
                MessageBox.Show("Выберите продукт");
            }
            //    return;
            //Name.Text = (ProductListViu.SelectedItem as Product).Name;
        }

        private void SaveBt_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            order = new Order();
            order.Id = rnd.Next(0, 1999999);
            order.DateOrder = DateTime.Now;
            order.UserId = Navigation.AuthUser.Id;
            DBConnect.db.Order.Add(order);
            DBConnect.db.SaveChanges();
            MessageBox.Show("ЕМАЕ");

        }
    }
}
