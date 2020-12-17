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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {


        public Edit()
        {
            InitializeComponent();
        }


        private void go_add(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("UPDATE incidents SET Name = @name, last_name = @lastName, patronymic = @patronymic, phone = @phone, gender = @gender, address = @addres," +
                "help = @help, view = @view, car = @car, number_car = @numbercar   Where ID = @id", db.getConnection());
            command.Parameters.AddWithValue("@id", id_box.Text);
            command.Parameters.AddWithValue("@name", name_box.Text);
            command.Parameters.AddWithValue("@lastName", lastName_box.Text);
            command.Parameters.AddWithValue("@patronymic", patronymic_box.Text);
            command.Parameters.AddWithValue("@phone", phone_box.Text);
            command.Parameters.AddWithValue("@gender", gender_box.Text);
            command.Parameters.AddWithValue("@addres", addres_box.Text);
            command.Parameters.AddWithValue("@help", help_box.Text);
            command.Parameters.AddWithValue("@view", view_box.Text);
            command.Parameters.AddWithValue("@car", car_box.Text);
            command.Parameters.AddWithValue("@numberCar", numberCar_box.Text);

            db.openConnection();

          

            if (command.ExecuteNonQuery() == 1)
            {
                MainAdmin winadm = new MainAdmin();
                MessageBox.Show("Услуга успешно отредактирована!");
                this.Close();
                winadm.Show();
            }
        }

      
    }
}
