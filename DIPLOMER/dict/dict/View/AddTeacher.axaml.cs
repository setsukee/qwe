using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using dict.dbases;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;

namespace dict.View
{
    public partial class AddTeacher : Window
    {
        public User teacher;
      
        public AddTeacher()
        {
            
            InitializeComponent();
            
            

            Save.Click += Save_Click;
           
            List<Subject> subs = new List<Subject>();
            subs = Helper.db.Subjects.ToList();
            
            
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
            maingrid.Background = gradient;

            Save.BorderBrush = new SolidColorBrush(Colors.Black);
            Save.Background = new SolidColorBrush(Colors.WhiteSmoke);
        }

        

       

        private void Save_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            try
            {
                if (surname.Text == null || name.Text == null || patr.Text == null)
                {
                    error.Text = "Кажется... Вы заполнили не все поля";
                }
                else
                {
                    teacher = new User();
                    teacher.Firstname = surname.Text;
                    teacher.Lastname = name.Text;
                    teacher.Patronymic = patr.Text;
                    teacher.Login = login.Text;
                    teacher.Password = pass.Text;
                    Helper.db.Users.Add(teacher);
                    Helper.db.SaveChanges();
                }

            }
            catch
            {


            }
        }
    }
}
