using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TRPO12_2.Service;

namespace TRPO12_2.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public PolzovatService service { get; set; } = new();
        public Polzovat? polzovat { get; set; } = null;
        public MainPage()
        {
            InitializeComponent();
        }

        private void go_form(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PolzovatFormPage());
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            if (polzovat == null)
            {
                MessageBox.Show("Выберите элемент из списка!");
                return;
            }
            NavigationService.Navigate(new PolzovatFormPage(polzovat));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (polzovat == null)
            {
                MessageBox.Show("Выберите запись!");
                return;
            }
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удалить?",
            MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                service.Remove(polzovat);
            }
        }
    }
}
