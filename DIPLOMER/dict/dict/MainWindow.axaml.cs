using Avalonia.Controls;
using dict.dbases;
using System;
using System.Collections.Generic;
using System.Linq;
using Npgsql;
using System.Runtime.Intrinsics.Arm;
using Avalonia;
using static System.Net.Mime.MediaTypeNames;
using Avalonia.Media;
using dict.View;

namespace dict
{
    public partial class MainWindow : Window
    {
        DateTime pn = new DateTime();
        DateTime pt = new DateTime();
        public MainWindow()
        {
            InitializeComponent();
            Init();
            Data();
            LoadData();
            
            
        }
        public void Init()
        {
            var groups = Helper.db.Groups.ToList();
            Group.Items = groups.Select(x => x.Name).ToList();
            Group.SelectedIndex = 0;

            var subs = Helper.db.Subjects.ToList();
            Sub.Items = subs.Select(x => x.Subname).ToList();
            Sub.SelectedIndex = 0;

            Group.SelectionChanged += Group_SelectionChanged;
            Sub.SelectionChanged += Sub_SelectionChanged;
            exitcl.Click += Exitcl_Click;

            btnleft.Click += Btnleft_Click;
            btnright.Click += Btnright_Click;

            StudentDG.CellEditEnding += StudentDG_CellEditEnding;

            





        }

        private void Exitcl_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Auth win = new Auth();
            win.Show();
            this.Close();
        }

        private void StudentDG_CellEditEnding(object? sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {

                int rowIndex = e.Row.GetIndex();
                string ColumnIndex = e.Column.GetValue(DataGridColumn.HeaderProperty).ToString();
                var item = StudentDG.Items.Cast<Myclass>().ElementAt(rowIndex);

                int qwe = 0;
                string str = (e.EditingElement as TextBox).Text;





                if (str == "")
                {
                    err.Text = "123";
                    
                }
                else if(!int.TryParse(str, out qwe))
                {
                    return;
                }




                if (str == "")
                {

                }
                else if(qwe > 5 || qwe < 1)
                {
                    (e.EditingElement as TextBox).Text = "";
                    return;
                }

                if (ColumnIndex.Trim().ToLower() == "пн")
                {
                    Mark mk = Helper.db.Marks.FirstOrDefault(x => x.StudentId == item.StudentId && x.SubId == item.SubId && x.Date == item.Datemarkpn);
                    if (mk != null)
                    {
                        if (str == "")
                        {
                            mk.MarkId = null;
                            Helper.db.SaveChanges();
                        }
                        else
                        {
                            mk.MarkId = Convert.ToInt16((e.EditingElement as TextBox).Text);
                            Helper.db.SaveChanges();
                        }
                      
                    }
                    else 
                    {
                        Mark zxc = new Mark();
                        zxc.StudentId = item.StudentId;
                        zxc.SubId = Sub.SelectedIndex + 1;
                        zxc.MarkId = Convert.ToInt16((e.EditingElement as TextBox).Text);
                        zxc.Date = pn.ToUniversalTime();
                        Helper.db.Marks.Add(zxc);
                        Helper.db.SaveChanges();

                    }
                }
                else if (ColumnIndex.Trim().ToLower() == "вт")
                {
                    Mark mk = Helper.db.Marks.FirstOrDefault(x => x.StudentId == item.StudentId && x.SubId == item.SubId && x.Date == item.Datemarkvt);
                    if (mk != null)
                    {
                        if (str == "")
                        {
                            mk.MarkId = null;
                            Helper.db.SaveChanges();
                        }
                        else
                        {
                            mk.MarkId = Convert.ToInt16((e.EditingElement as TextBox).Text);
                            Helper.db.SaveChanges();
                        }
                    }
                    else
                    {
                        Mark zxc = new Mark();
                        zxc.StudentId = item.StudentId;
                        zxc.SubId = Sub.SelectedIndex + 1;
                        zxc.MarkId = Convert.ToInt16((e.EditingElement as TextBox).Text);
                        zxc.Date = pn.AddDays(1).ToUniversalTime();
                        Helper.db.Marks.Add(zxc);
                        Helper.db.SaveChanges();

                    }
                }
                else if (ColumnIndex.Trim().ToLower() == "ср")
                {
                    Mark mk = Helper.db.Marks.FirstOrDefault(x => x.StudentId == item.StudentId && x.SubId == item.SubId && x.Date == item.Datemarksr);
                    if (mk != null)
                    {
                                if (str == "")
                                {
                                    mk.MarkId = null;
                                    Helper.db.SaveChanges();
                                }
                                else
                                {
                                    mk.MarkId = Convert.ToInt16((e.EditingElement as TextBox).Text);
                                    Helper.db.SaveChanges();
                                }
                    }
                    else
                    {
                        Mark zxc = new Mark();
                        zxc.StudentId = item.StudentId;
                        zxc.SubId = Sub.SelectedIndex + 1;
                        zxc.MarkId = Convert.ToInt16((e.EditingElement as TextBox).Text);
                        zxc.Date = pt.AddDays(-2).ToUniversalTime();
                        Helper.db.Marks.Add(zxc);
                        Helper.db.SaveChanges();

                    }
                }
                else if (ColumnIndex.Trim().ToLower() == "чт")
                {
                    
                    Mark mk = Helper.db.Marks.FirstOrDefault(x => x.StudentId == item.StudentId && x.SubId == item.SubId && x.Date == item.Datemarkth);
                    if (mk != null)
                    {
                        
                        if (str == "")
                        {
                            err.Text = "zxc";
                            mk.MarkId = null;
                            Helper.db.SaveChanges();
                        }
                        else
                        {
                            mk.MarkId = Convert.ToInt16((e.EditingElement as TextBox).Text);
                            Helper.db.SaveChanges();
                        }
                    }
                    else
                    {
                        
                        Mark zxc = new Mark();
                        zxc.StudentId = item.StudentId;
                        zxc.SubId = Sub.SelectedIndex + 1;
                        zxc.MarkId = Convert.ToInt16((e.EditingElement as TextBox).Text);
                        zxc.Date = pt.AddDays(-1).ToUniversalTime();
                        Helper.db.Marks.Add(zxc);
                        Helper.db.SaveChanges();

                    }
                }
                else
                {
                    
                    Mark mk = Helper.db.Marks.FirstOrDefault(x => x.StudentId == item.StudentId && x.SubId == item.SubId && x.Date == item.Datemarkft);
                    if (mk != null)
                    {

                                if (str == "")
                                {
                                    mk.MarkId = null;
                                    Helper.db.SaveChanges();
                                }
                                else
                                {
                                    mk.MarkId = Convert.ToInt16((e.EditingElement as TextBox).Text);
                                    Helper.db.SaveChanges();
                                }
                     }
                    else
                    {
                        Mark zxc = new Mark();
                        zxc.StudentId = item.StudentId;
                        zxc.SubId = Sub.SelectedIndex + 1;
                        zxc.MarkId = Convert.ToInt16((e.EditingElement as TextBox).Text);
                        zxc.Date = pt.ToUniversalTime();
                        Helper.db.Marks.Add(zxc);
                        Helper.db.SaveChanges();

                    }
                }



                LoadData();




            }
        }

 
        

        private void Btnright_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            pn = pn.AddDays(7);
            pt = pt.AddDays(7);
            Datetxt.Text = pn.ToShortDateString() + " - " + pt.ToShortDateString();
            LoadData();

        }

        private void Btnleft_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            
            
            pn = pn.AddDays(-7);
            pt = pt.AddDays(-7);
            Datetxt.Text = pn.ToShortDateString() + " - " + pt.ToShortDateString();
            LoadData();
        }

        private void Data()
        {
            string day = DateTime.Today.DayOfWeek.ToString().ToLower().Trim();


            switch (day)
            {
                case "monday":
                    pn = DateTime.Today;
                    pt = DateTime.Today.AddDays(4);
                    Datetxt.Text = pn.ToShortDateString() + " - " + pt.ToShortDateString();
                    break;
                case "tuesday":
                    pn = DateTime.Today.AddDays(-1);
                    pt = DateTime.Today.AddDays(3);
                    Datetxt.Text = pn.ToShortDateString() + " - " + pt.ToShortDateString();
                    break;
                case "wednesday":
                    pn = DateTime.Today.AddDays(-2);
                    pt = DateTime.Today.AddDays(2);
                    Datetxt.Text = pn.ToShortDateString() + " - " + pt.ToShortDateString();
                    break;
                case "thursday":
                    pn = DateTime.Today.AddDays(-3);
                    pt = DateTime.Today.AddDays(1);
                    Datetxt.Text = pn.ToShortDateString() + " - " + pt.ToShortDateString();
                    break;
                case "friday":
                    pn = DateTime.Today.AddDays(-4);
                    pt = DateTime.Today;
                    Datetxt.Text = pn.ToShortDateString() + " - " + pt.ToShortDateString();
                    break;
                case "saturday":
                    pn = DateTime.Today.AddDays(-5);
                    pt = DateTime.Today.AddDays(-1);
                    Datetxt.Text = pn.ToShortDateString() + " - " + pt.ToShortDateString();
                    break;
                case "sunday":
                    pn = DateTime.Today.AddDays(-6);
                    pt = DateTime.Today.AddDays(-2);
                    Datetxt.Text = pn.ToShortDateString() + " - " + pt.ToShortDateString();
                    break;
            }
        }

        private void Sub_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            LoadData();
        }

        private void Group_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            LoadData();
        }

        public async void LoadData()
        {
            string connectionString = "Host=localhost;Database=glaziki;userid=postgres;password=1q3e2w4r";

            string sqlExpression = $"Select mark.id, mark.mark_id, mark.sub_id, mark.\"date\", s.id, s.firstname, s.lastname, s.patronymic, s.group_id  \r\nfrom mark \r\nfull join student s on s.id = mark.student_id\r\nwhere ((mark.\"date\" BETWEEN \'{pn}\' and \'{pt}\') or mark.\"date\" is null) and mark.sub_id ={Sub.SelectedIndex + 1} and s.group_id = {Group.SelectedIndex + 1}\r\norder by s.id, mark.\"date\"\r\n";
           

            List<Myclass> students = Helper.db.Students.Where(y => y.GroupId == Group.SelectedIndex + 1).Select(x => new Myclass()
            {
                StudentId = x.Id,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                Patronymic = x.Patronymic,
                GroupId = x.GroupId,
                cbox = Sub.SelectedIndex + 1
            }).ToList();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();

                NpgsqlCommand command = new NpgsqlCommand(sqlExpression, connection);
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        int i = 0;
                        
                        
                        while (await reader.ReadAsync()) // построчно считываем данные
                        {
                            if (i != reader.GetInt16(4))
                            {
                                i = reader.GetInt16(4);
                                Myclass stud = students.FirstOrDefault(x => x.StudentId == i);
                                if (reader.IsDBNull(0))
                                {
                                    stud.Id = null;
                                    stud.SubId = null;
                                    stud.cbox = Sub.SelectedIndex + 1;
                                    
                                    
                                }
                                else
                                {
                                    stud.Id = reader.GetInt16(0);
                                    stud.SubId = reader.GetInt16(2);
                                    stud.cbox = Sub.SelectedIndex + 1;

                                    DateTime dt = reader.GetDateTime(3);
  
                                    switch (dt.DayOfWeek.ToString().Trim().ToLower())
                                    {
                                        case "monday":
                                            if (reader.IsDBNull(1))
                                            {
                                                stud.markpn = null;
                                            }
                                            else
                                            {
                                                stud.markpn = reader.GetInt16(1);
                                            }
                                            
                                            stud.Datemarkpn = reader.GetDateTime(3).ToUniversalTime();
                                            break;
                                        case "tuesday":
                                            if (reader.IsDBNull(1))
                                            {
                                                stud.markvt = null;
                                            }
                                            else
                                            {
                                                stud.markvt = reader.GetInt16(1);
                                            }
                                            stud.Datemarkvt = reader.GetDateTime(3).ToUniversalTime();
                                            break;
                                        case "wednesday":
                                            if (reader.IsDBNull(1))
                                            {
                                                stud.marksr = null;
                                            }
                                            else
                                            {
                                                stud.marksr = reader.GetInt16(1);
                                            }
                                            stud.Datemarksr= reader.GetDateTime(3).ToUniversalTime();
                                            break;
                                        case "thursday":
                                            if (reader.IsDBNull(1))
                                            {
                                                stud.markth = null;
                                            }
                                            else
                                            {
                                                stud.markth = reader.GetInt16(1);
                                            }
                                            stud.Datemarkth= reader.GetDateTime(3).ToUniversalTime();
                                            break;
                                        case "friday":
                                            if (reader.IsDBNull(1))
                                            {
                                                stud.markft = null;
                                            }
                                            else
                                            {
                                                stud.markft = reader.GetInt16(1);
                                            }
                                            stud.Datemarkft = reader.GetDateTime(3).ToUniversalTime();
                                            break;
                                    
                                    }
                                    
                                }

                                                         
                                
                                

                            }
                            else
                            {
                                Myclass stud = students.FirstOrDefault(x => x.StudentId == i);
                                DateTime dt = reader.GetDateTime(3);
                                stud.cbox = Sub.SelectedIndex + 1;
                                switch (dt.DayOfWeek.ToString().Trim().ToLower())
                                {
                                    case "monday":
                                        if (reader.IsDBNull(1))
                                        {
                                            stud.markpn = null;
                                        }
                                        else
                                        {
                                            stud.markpn = reader.GetInt16(1);
                                        }

                                        stud.Datemarkpn = reader.GetDateTime(3).ToUniversalTime();
                                        break;
                                    case "tuesday":
                                        if (reader.IsDBNull(1))
                                        {
                                            stud.markvt = null;
                                        }
                                        else
                                        {
                                            stud.markvt = reader.GetInt16(1);
                                        }
                                        stud.Datemarkvt = reader.GetDateTime(3).ToUniversalTime();
                                        break;
                                    case "wednesday":
                                        if (reader.IsDBNull(1))
                                        {
                                            stud.marksr = null;
                                        }
                                        else
                                        {
                                            stud.marksr = reader.GetInt16(1);
                                        }
                                        stud.Datemarksr = reader.GetDateTime(3).ToUniversalTime();
                                        break;
                                    case "thursday":
                                        if (reader.IsDBNull(1))
                                        {
                                            stud.markth = null;
                                        }
                                        else
                                        {
                                            stud.markth = reader.GetInt16(1);
                                        }
                                        stud.Datemarkth = reader.GetDateTime(3).ToUniversalTime();
                                        break;
                                    case "friday":
                                        if (reader.IsDBNull(1))
                                        {
                                            stud.markft = null;
                                        }
                                        else
                                        {
                                            stud.markft = reader.GetInt16(1);
                                        }
                                        stud.Datemarkft = reader.GetDateTime(3).ToUniversalTime();
                                        break;

                                }
                            }
                        }
                    }
                }
                await connection.CloseAsync();
            }

            

             StudentDG.Items = students;

      
            
            


        }
    }
}