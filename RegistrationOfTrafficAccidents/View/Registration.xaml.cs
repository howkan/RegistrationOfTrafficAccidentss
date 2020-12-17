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
using MahApps.Metro.Controls;
using MySql.Data.MySqlClient;

namespace RegistrationOfTrafficAccidents.View
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : MetroWindow
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("INSERT INTO `users` ( `Login`, `Password`, `Name`) VALUES ( @login, @pass, @name)", db.getConnection());
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = Login.Text;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Password.Password.ToString();
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = Name.Text;
                db.openConnection();


                if (CheckTextBoxes())
                {
                    if (CheckUserName())
                    {
                        if (CheckPasswordLenght())
                        {
                            if (Password.Password.ToString().Equals(Passowrd2.Password.ToString()))
                            {
                                if (!CheckLogin())
                                {
                                    if (command.ExecuteNonQuery() == 1)
                                    {
                                        Authorization authorization = new Authorization();
                                        authorization.Show();
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error");
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Такой логин уже существует");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Пароль не совпадают");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пароль не должен превышать 10 символов");
                        };
                    }
                    else
                    {
                        MessageBox.Show("Имя должно содержать больше 2 букв");
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

        public Boolean CheckLogin()
        {
            DB db = new DB();
            String login = Login.Text;
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `Login` = @login", db.getConnection());

            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public Boolean CheckUserName()
        {
            String name = Name.Text;
            if (name.Length <= 3)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public Boolean CheckPasswordLenght()
        {
            String password = Password.Password.ToString();

            if (password.Length > 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public Boolean CheckTextBoxes()
        {
            String name = Name.Text;
            String login = Login.Text;
            String password = Password.Password.ToString();


            if (name == String.Empty || login == String.Empty || password == String.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
        }
    }
}
