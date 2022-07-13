using DziennikOcen.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace DziennikOcen
{
    /// <summary>
    /// Logika interakcji dla klasy ShowGrades.xaml
    /// </summary>
    public partial class ShowGrades : Window
    {
        public ShowGrades()
        {
            InitializeComponent();
            var items = new ObservableCollection<Object>();
            using (var context = new DziennikOcenContext())
            {
                var query = context.Grades
                            .Join(context.Students, g => g.StudentId, s => s.Id, (g, s) => new { g, s })
                            .Join(context.Classes, gst => gst.g.ClassId, c => c.Id, (gts, c) => new { gts.g, gts.s, c })
                            .Select(m => new {
                                m.g.Id,
                                m.s.Name,
                                m.s.GroupSymbol,
                                m.g.Grade1,
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

    }
}
