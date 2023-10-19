using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tempppp
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-Q54H48I\SQLEXPRESS;Initial Catalog=Trade; Integrated Security=True");
            string query = "Select * from [User] where UserLogin = '" + loginTB.Text.Trim() + "' and UserPassword = '" + passTB.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            sqlcon.Open();
            SqlDataReader myReader = null;
            SqlCommand command = new SqlCommand("Select * from [User] Where UserLogin = '" + loginTB.Text.Trim() + " ' and UserPassword = '" + passTB.Text.Trim() + "'", sqlcon);
            myReader = command.ExecuteReader();
            if (dtbl.Rows.Count == 0)
            {
                MessageBox.Show("Неправильно введен логин или пароль!", "Ошибка!");
                ErrorWindow errorWin = new ErrorWindow();
                errorWin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Выполнен вход!", "Успешно!");
                MainWWW mainwww = new MainWWW();
                mainwww.Show();
                this.Hide();
            }
        }
    }
}
