using DziennikOcen.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using System.Windows;


namespace DziennikOcen
{
    /// <summary>
    /// Logika interakcji dla klasy ShowStudents.xaml
    /// </summary>
    public partial class ShowStudents : Window
    {
        public ShowStudents()
        {
            InitializeComponent();
            var items = new ObservableCollection<Student>();
            using (var context = new DziennikOcenContext())
            {
                var query = from s in context.Students orderby s.Id select s;
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
