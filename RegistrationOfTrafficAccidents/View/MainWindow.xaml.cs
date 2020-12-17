using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MySql.Data.MySqlClient;
using RegistrationOfTrafficAccidents.View.Buttons;

namespace RegistrationOfTrafficAccidents.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
  
    public partial class MainWindow : MetroWindow 
    {
        public MainWindow()
        {
            InitializeComponent();

            sql();

            List<string> styles = new List<string> { "Default", "Dark", "Blue" };
            styleBox.SelectionChanged += ThemeChange;
            styleBox.ItemsSource = styles;
            styleBox.SelectedItem = "Default";
        }

        private void Click_Add(object sender, RoutedEventArgs e)
        {
            Add add = new Add();
            add.Show();
        }

        private void Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Click_Change(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
        }

        private void incidents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sql();
        }

        private void sql()
        {
            string sql = "SELECT * FROM incidents";
            DB dB = new DB();
            using (MySqlCommand cmdSel = new MySqlCommand(sql, dB.getConnection()))
            {
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                da.Fill(dt);
                incidents.ItemsSource = dt.DefaultView;
            }
        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = styleBox.SelectedItem as string;
            var url = new Uri("Styles/Themes/" + style + ".xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(url) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }

        private void Click_Find(object sender, RoutedEventArgs e)
        {
            Find find = new Find();
            find.Show();
            Find.dataGridView1 = this.incidents;
        }
    }
}
