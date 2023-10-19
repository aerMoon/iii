using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
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

namespace tempppp
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    /// 
    public class Product
    {
        public string ProductArticleNumber { get; set; }
        public string ProductName { get; set; } 
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public string ProductPhoto {  get; set; }   
        public string ProductManufacturer { get; set; }
        public double ProductCost { get; set; }
        public int ProductDiscountAmount { get; set; }
        public int ProductQuantityInStock { get; set; }
        public string ProductStatus { get; set;}
    }


    public partial class ClientWindow : Window
    {
        
        public ClientWindow()
        {
            InitializeComponent();

           
        }
       
       

        private async void cmdDeleteCar_Click(object sender, RoutedEventArgs e)
        {
          //  var product = ProductsDataGrid.SelectedItem as Product; 

        }

        private void cmdAddCar_Click(object sender, RoutedEventArgs e)
        {

        }












        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void cmdGetCar_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(
                @"Data Source=DESKTOP-Q54H48I\SQLEXPRESS;Initial Catalog=Trade; Integrated Security=True"
                );

            using (conn)
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT ProductArticleNumber, ProductName FROM Product", conn);
                SqlDataReader read = cmd.ExecuteReader();

                using (read)
                {
                    dt.Load(read);
                }


            }

            ProductsDataGrid.Items.Clear();
            ProductsDataGrid.ItemsSource = dt.DefaultView;

            //ProductsDataGrid.Columns.Add(new DataGridTextColumn
            //{
            //    Header = "ProductName",
            //    Binding = new Binding("ProductName")
            //});


            conn.Close();
            conn.Dispose();





        }

       
    }
}

