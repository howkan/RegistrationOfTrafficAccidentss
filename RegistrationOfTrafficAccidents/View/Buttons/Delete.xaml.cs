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
    /// Логика взаимодействия для Delete.xaml
    /// </summary>
    public partial class Delete : Window
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void go_save(object sender, RoutedEventArgs e)
        {
            DB dB = new DB();

            MySqlCommand command = new MySqlCommand("DELETE FROM incidents WHERE id=@Id", dB.getConnection());
            command.Parameters.AddWithValue("Id", Convert.ToInt32(Id_Box.Text));
            DataTable dataTable = new DataTable();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            dataTable.Clear();
            dataAdapter.Fill(dataTable);
            dB.openConnection();

            MessageBox.Show("Запись удалена");
            this.Close();
        }
    }
}
