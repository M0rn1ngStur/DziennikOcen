using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using DziennikOcen.Model;

namespace DziennikOcen
{
    /// <summary>
    /// Logika interakcji dla klasy ShowClasses.xaml
    /// </summary>
    public partial class ShowClasses : Window
    {
        public ShowClasses()
        {
            InitializeComponent();
            var items = new ObservableCollection<Class>();
            using (var context = new DziennikOcenContext())
            {
                var query = from c in context.Classes orderby c.Id select c;
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

        private void newClass(object sender, RoutedEventArgs e)
        {
            Window addClass = new AddClass();
            addClass.Show();
            this.Close();
        }
    }
}
