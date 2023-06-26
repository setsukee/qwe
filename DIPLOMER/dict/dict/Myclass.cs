using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;

namespace dict
{
    internal class Myclass
    {
        public int? Id { get; set; }

        public int cbox { get; set; }
        public int? SubId { get; set; }

        public int? markpn { get; set; }
        public int? markvt { get; set; }
        public int? marksr { get; set; }
        public int? markth { get; set; }
        public int? markft { get; set; }

        public DateTime? Datemarkpn { get; set; }
        public DateTime? Datemarkvt { get; set; }
        public DateTime? Datemarksr { get; set; }
        public DateTime? Datemarkth { get; set; }
        public DateTime? Datemarkft { get; set; }

       

        public double? Average { get
            { 
                return Helper.db.Marks.Where(x => x.StudentId == StudentId && x.SubId == cbox).Select(x => x.MarkId).Average();
            } }

        public Avalonia.Media.ISolidColorBrush brush
        {
            get
            {
                if (Average <= 2)
                {

                    return Avalonia.Media.Brushes.Black;
                }
                else if (Average <= 3)
                {

                    return Avalonia.Media.Brushes.Gray;

                }
                else if (Average <= 3.99)
                {
                    return Avalonia.Media.Brushes.Red;
                }
                else if (Average <= 4.5)
                {
                    return Avalonia.Media.Brushes.Yellow;

                }
                else if (Average > 4.5)
                {
                    return Avalonia.Media.Brushes.Green;
                }
                else 
                {
                    return Avalonia.Media.Brushes.Transparent;
                }



            }
        }

        public int StudentId { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string? Patronymic { get; set; }

        public int? GroupId { get; set; }
    }
}
