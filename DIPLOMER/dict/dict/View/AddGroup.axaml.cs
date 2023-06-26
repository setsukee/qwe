using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using dict.dbases;

namespace dict.View
{
    public partial class AddGroup : Window
    {
        public Group group;
        public AddGroup()
        {
            InitializeComponent();
            Save.Click += Save_Click;
            group = new Group();
            DataContext = group;
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

            Save.Background = new SolidColorBrush(Colors.White);
            Save.BorderBrush = new SolidColorBrush(Colors.Black);
        }

        private void Save_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Helper.db.Groups.Add(group);
            Helper.db.SaveChanges();
        }
    }
}
