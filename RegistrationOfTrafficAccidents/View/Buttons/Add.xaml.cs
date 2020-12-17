using MySql.Data.MySqlClient;
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

namespace RegistrationOfTrafficAccidents.View.Buttons
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();
        }

        private void go_add(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB();


                MySqlCommand command = new MySqlCommand("INSERT INTO `incidents` (`name`, `last_name`, `patronymic`, `phone`, `address`,  `help`,  `gender`,  `view`,  `car`,  `number_car` ) " +
                    "VALUES ( @name, @last_name, @patronymic, @phone, @address, @help, @gender, @view, @car, @number_car)", db.getConnection());
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name_box.Text;
                command.Parameters.Add("@last_name", MySqlDbType.VarChar).Value = lastName_box.Text;
                command.Parameters.Add("@patronymic", MySqlDbType.VarChar).Value = patronymic_box.Text;

                command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone_box.Text;
                command.Parameters.Add("@address", MySqlDbType.VarChar).Value = addres_box.Text;
                command.Parameters.Add("@help", MySqlDbType.VarChar).Value = help_box.Text;
                command.Parameters.Add("@gender", MySqlDbType.VarChar).Value = gender_box.Text;
                command.Parameters.Add("@view", MySqlDbType.VarChar).Value = view_box.Text;
                command.Parameters.Add("@car", MySqlDbType.VarChar).Value = car_box.Text;
                command.Parameters.Add("@number_car", MySqlDbType.VarChar).Value = numberCar_box.Text;



                db.openConnection();


                if (CheckTextBoxes())
                {
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Запись добавлена");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Запись не добавлена");
                    }
                }
                else
                {
                    MessageBox.Show("Заполните пустые поля");
                }


            }

            catch (MySql.Data.MySqlClient.MySqlException)
            {
                MessageBox.Show("Отсутствует подключение с базой данных");
            }
        }

        public Boolean CheckTextBoxes()
        {
            String name = name_box.Text;
            String lastName = lastName_box.Text;
            String patronymic = patronymic_box.Text;
            String phone = phone_box.Text;
            String address = addres_box.Text;
            String help = help_box.Text;
            String gender = gender_box.Text;
            String view = view_box.Text;
            String car = car_box.Text;
            String number_Car = numberCar_box.Text;

            if (name == String.Empty || lastName == String.Empty || address == String.Empty ||
                patronymic == String.Empty || phone == String.Empty || help == String.Empty || gender == String.Empty ||
                view == String.Empty || car == String.Empty || number_Car == String.Empty)

            {
                return false;
            }
            else
            {
                return true;
            }
        }





        private void numberCar_box_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !((Char.IsDigit(e.Text, 0) || ((e.Text == System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0].ToString()) && (DS_Count(((TextBox)sender).Text) < 1))));
        }
    }
    }
}
