using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System.Linq;

namespace dict.View
{
    public partial class Auth : Window
    {
        public Auth()
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
            this.Background = gradient;

            EnterButton.Click += EnterButton_Click;
            EnterButton.Background = new SolidColorBrush(Colors.White);
            EnterButton.BorderBrush = new SolidColorBrush(Colors.Black);
        }

        private void EnterButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
           
            var users = Helper.db.Users.FirstOrDefault(x => x.Login == logb.Text);
            if (users != null && users.RoleId == 2 &&users.Password == passb.Text)
            {
                MainWindow win = new MainWindow();
                win.Show();
                this.Close();
            }
            else if (users != null && users.RoleId == 1 && users.Password == passb.Text)
            {
                int names = users.Id;
                adminname.name = names;
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
                this.Close();
            }
        }
    }
}
