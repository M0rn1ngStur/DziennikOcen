using DziennikOcen.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace DziennikOcen
{
    /// <summary>
    /// Logika interakcji dla klasy ShowAttendances.xaml
    /// </summary>
    public partial class ShowAttendances : Window
    {
        public ShowAttendances()
        {
            InitializeComponent();
            var items = new ObservableCollection<Object>();
            using (var context = new DziennikOcenContext())
            {
                var query = context.Attendances
                            .Join(context.Students, a => a.StudentId, s => s.Id, (a, s) => new {a, s})
                            .Join(context.Classes, atst => atst.a.ClassId, c => c.Id, (asts, c) => new { asts.a, asts.s, c })
                            .Select(m => new { 
                                m.a.Id,
                                m.s.Name,
                                m.s.GroupSymbol,
                                Date = m.a.Date.ToString("dd.MM.yyyy"),
                                m.a.Attendance1,
                                m.c.ClassName
                            });
                foreach (var x in query)
                {
                    items.Add(x);
                }
            }
            List.ItemsSource = items;
        }

        private void goBack(object sender, RoutedEventArgs e)
        {
            Window mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void newAttendance(object sender, RoutedEventArgs e)
        {
            Window addAttendance = new AddAttendance();
            addAttendance.Show();
            this.Close();
        }
    }
}
