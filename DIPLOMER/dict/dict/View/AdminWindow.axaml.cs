using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using dict.dbases;
using System.Drawing;
using System.Net.Http.Headers;

namespace dict.View
{
    public partial class AdminWindow : Window
    {
        public User admin;
        public AdminWindow()
        {
            InitializeComponent();
            WindowStyle();
            Loaddata();
            admin = new User();
            DataContext = admin;
            addstud.Click += Addstud_Click;
            addteach.Click += Addteach_Click;
            addgroup.Click += Addgroup_Click;
            exit.Click += Exit_Click;

        }

        private void Addgroup_Click(object? sender, RoutedEventArgs e)
        {
            AddGroup addGroup = new AddGroup();
            addGroup.Show();
        }

        private void Exit_Click(object? sender, RoutedEventArgs e)
        {
            Auth win =  new Auth();
            win.Show();
            this.Close();
        }

        private void Addteach_Click(object? sender, RoutedEventArgs e)
        {
            AddTeacher teacher = new AddTeacher();
            teacher.Show();
        }

        private void Addstud_Click(object? sender, RoutedEventArgs e)
        {
            AddStudent win = new AddStudent();
            win.Show();
            
        }

        public void WindowStyle()
        {
            //Первый бордер
            var gradient = new LinearGradientBrush
            {
                GradientStops = new GradientStops
                {
                    new GradientStop(Colors.DarkBlue, 0.0),
                    new GradientStop(Colors.LightBlue, 1.0)
                },
                StartPoint = new RelativePoint(0, 0, RelativeUnit.Relative),
                EndPoint = new RelativePoint(1, 1, RelativeUnit.Relative)
            };
            bord.Background = gradient;

            
            
        }

        public void Loaddata()
        {
            try
            {
                int admin = adminname.name;
                var query = Helper.db.Users.Find(admin);
                surname.Text = query.Firstname;
                name.Text = query.Lastname;
            }
            catch
            {

                throw;
            }


            addstud.BorderBrush = new SolidColorBrush(Colors.Black);
            addstud.Background = new SolidColorBrush(Colors.White);

            addteach.BorderBrush = new SolidColorBrush(Colors.Black);
            addteach.Background = new SolidColorBrush(Colors.White);

            exit.Background = new SolidColorBrush(Colors.White);
            exit.BorderBrush = new SolidColorBrush(Colors.Black);

            addgroup.BorderBrush = new SolidColorBrush(Colors.Black);
            addgroup.Background = new SolidColorBrush(Colors.White) ;

        }
    }
}
