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

namespace actors_site
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string username = "Victoria";
        private string pass = "987654321";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        { 
            if (LoginText.Text == username & PasswordPassBox.Password == pass)
            {
                MainForm gf = new MainForm();
                gf.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }
                
        }
    }
}
