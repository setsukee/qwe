using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using dict.dbases;
using System.Collections.Generic;
using System.Linq;

namespace dict.View
{
    public partial class AddStudent : Window
    {
        public Student student;
        public AddStudent()
        {
            InitializeComponent();
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

            
            Save.Click += Save_Click;
            
            List<Group> gr = new List<Group>();
            gr = Helper.db.Groups.ToList();

            group.Items = gr.Select(x => x.Name);
            Save.Background = new SolidColorBrush(Colors.White);
            Save.BorderBrush = new SolidColorBrush(Colors.Black);


        }
       

        private void Save_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
          
                if (surname.Text == null || name.Text == null || patr.Text == null)
                {
                    error.Text = "Кажется... Вы заполнили не все поля";
                }
                else
                {
                    student = new Student();
                    student.Firstname = surname.Text;
                    student.Lastname = name.Text;
                    student.Patronymic = patr.Text;
                    student.GroupId = group.SelectedIndex + 1;
                    Helper.db.Students.Add(student);
                    Helper.db.SaveChanges();
                    
                }

           


        }
    }
}
