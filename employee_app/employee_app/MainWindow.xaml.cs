using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace employee_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Emp_detail> users = new List<Emp_detail>();

        public MainWindow()
        {
            InitializeComponent();
            emp_list.ItemsSource = users ;

        }




        private void button_Click(object sender, RoutedEventArgs e)
        {
            Emp_detail newUser = new Emp_detail();
            newUser.UserName= textBox_name.Text;
            string emp_id = textBox_id.Text;
            newUser.UserId = Convert.ToInt32(emp_id);

            newUser.UserAddress = textBox_add.Text;
            string emp_zip = textBox_zip.Text;
            newUser.UserZip = Convert.ToInt32(emp_zip);

            newUser.UserHireDate = textBox_hireddate.Text;
            newUser.UserTerm = textBox_termdate.Text;


            users.Add(newUser);
            emp_list.ItemsSource = null;
            emp_list.ItemsSource = users;


            string fileName = "C:\\Users\\Ting\\Source\\Repos\\Week4_Day5_TIY\\employee_app\\employee_list.txt";

            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                sw.WriteLine("id: " + textBox_id.Text + " | employee name: " + textBox_name.Text + " | address: " + textBox_add.Text + " | zip: " + textBox_zip.Text + " | hire date: " + textBox_hireddate.Text + " | termination date: " + textBox_termdate.Text);

            }

        }

        private void button_Click_load(object sender, RoutedEventArgs e)
        {

            string fileName = "C:\\Users\\Ting\\Source\\Repos\\Week4_Day5_TIY\\employee_app\\employee_list.txt";

            StreamReader sr = new StreamReader(fileName);
            sr.ReadLine();
            while (sr.ReadLine() != null)
            {
                Emp_detail newUser = new Emp_detail();

                users.Add(newUser);
            }


        }
    }
}
