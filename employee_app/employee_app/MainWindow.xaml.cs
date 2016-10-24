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
            newUser.UserZip = textBox_zip.Text;

            newUser.UserHireDate = textBox_hireddate.Text;
            newUser.UserTerm = textBox_termdate.Text;


            users.Add(newUser);
            emp_list.ItemsSource = null;
            emp_list.ItemsSource = users;
          
            string fileName = "C:\\Users\\Ting\\Source\\Repos\\Week4_Day5_TIY\\employee_app\\employee_list.txt";

            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
               sw.WriteLine("id:" + textBox_id.Text + "| employee name: " + textBox_name.Text + " | address: " + textBox_add.Text + " | zip: " + textBox_zip.Text + " | hire date: " + textBox_hireddate.Text + " | termination date: " + textBox_termdate.Text);
                //sw.WriteLine(textBox_id.Text +  "|" + textBox_name.Text + "|" + textBox_add.Text + "|" + textBox_zip.Text + "|" + textBox_hireddate.Text + "|" + textBox_termdate.Text);
            }
            textBox_name.Text = String.Empty;
            textBox_id.Text = String.Empty;
            textBox_add.Text = String.Empty;
            textBox_zip.Text = String.Empty;
            textBox_hireddate.Text = String.Empty;
            textBox_termdate.Text = String.Empty;

        }

        private void button_Click_load(object sender, RoutedEventArgs e)
        {

            string fileName = "C:\\Users\\Ting\\Source\\Repos\\Week4_Day5_TIY\\employee_app\\employee_list.txt";

            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                string temp = sr.ReadLine();
                string[] values = temp.Split('|');
                Emp_detail newUser = new Emp_detail();
                newUser.UserId = Convert.ToInt32(values[0].Replace("id: ", ""));
                newUser.UserName = values[1].Replace("employee name: ", "");
                newUser.UserAddress = values[2].Replace("address: ", ""); ;
                newUser.UserZip = values[3].Replace("zip: ", "");
                newUser.UserHireDate = values[4].Replace("hire date: ", "");
                newUser.UserTerm = values[5].Replace("termination date: ", "");

                users.Add(newUser);
            }
            emp_list.ItemsSource = null;
            emp_list.ItemsSource = users;


        }
    }
}
