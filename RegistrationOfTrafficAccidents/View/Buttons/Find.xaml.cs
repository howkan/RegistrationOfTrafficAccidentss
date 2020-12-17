using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace RegistrationOfTrafficAccidents.View.Buttons
{
    /// <summary>
    /// Логика взаимодействия для Find.xaml
    /// </summary>
    public partial class Find : Window
    {

        public static DataGrid dataGridView1;

        public Find()
        {
            InitializeComponent();
        }



        private void SelectTab(string query)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand(query, db.getConnection());
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);

            DataTable dataTable = new DataTable();
            dataTable.Clear();
            dataAdapter.Fill(dataTable);
            dataGridView1.ItemsSource = dataTable.DefaultView;
        }

        private void go_add(object sender, RoutedEventArgs e)
        {
            string id = "id";
            string name = "name";
            string lastName = "last_name";
            string patronymic = "patronymic";
            string phone = "phone";
            string address = "address";
            string help = "help";
            string gender = "gender";
            string view = "view";
            string car = "car";
            string number_Car = "number_car";

            SelectTab("Select * from incidents " +
               "WHERE " + name + "  LIKE '" + name_box.Text + "%' " +
               "AND " + lastName + " LIKE '" + lastName_box.Text + "%'" +
               "AND " + patronymic + " LIKE '" + patronymic_box.Text + "%'" +
               "AND " + phone + " LIKE '" + phone_box.Text + "%'" +
               "AND " + address + " LIKE '" + addres_box.Text + "%'" +
               "AND " + help + " LIKE '" + help_box.Text + "%'" +
               "AND " + gender + " LIKE '" + gender_box.Text + "%'" +
               "AND " + view + " LIKE '" + view_box.Text + "%'" +
               "AND " + car + " LIKE '" + car_box.Text + "%'" +
               "AND " + number_Car + " LIKE '" + numberCar_box.Text + "%'"

               );

            this.Close();
        }
    }
}
