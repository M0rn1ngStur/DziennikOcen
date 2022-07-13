using DziennikOcen.Model;
using System;
using System.Linq;
using System.Text;

using System.Windows;


namespace DziennikOcen
{
    /// <summary>
    /// Logika interakcji dla klasy AddAttendance.xaml
    /// </summary>
    public partial class AddAttendance : Window
    {
        public AddAttendance()
        {
            InitializeComponent();
        }

        private async void submit(object sender, RoutedEventArgs e)
        {
            using (var context = new DziennikOcenContext())
            {
                Attendance x = new Attendance { StudentId = int.Parse(StudentId.Text), Attendance1 = bool.Parse(Attendance1.Text), ClassId = int.Parse(ClassId.Text), Date = Convert.ToDateTime(Date.Text) };
                context.Attendances.Add(x);
                await context.SaveChangesAsync();
            }
        }

        private void goBack(object sender, RoutedEventArgs e)
        {
            Window showAttendences = new ShowAttendances();
            showAttendences.Show();
            this.Close();
        }
    }
}
