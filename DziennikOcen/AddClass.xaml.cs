using System;
using System.Linq;
using System.Text;
using System.Windows;
using DziennikOcen.Model;

namespace DziennikOcen
{
    /// <summary>
    /// Logika interakcji dla klasy AddClass.xaml
    /// </summary>
    public partial class AddClass : Window
    {
        public AddClass()
        {
            InitializeComponent();
        }

        private async void submit(object sender, RoutedEventArgs e)
        {
            using (var context = new DziennikOcenContext())
            {
                Class x = new Class { ClassName = ClassName.Text };
                context.Classes.Add(x);
                await context.SaveChangesAsync();
            }
        }

        private void goBack(object sender, RoutedEventArgs e)
        {
            Window showClasses = new ShowClasses();
            showClasses.Show();
            this.Close();
        }
    }
}
