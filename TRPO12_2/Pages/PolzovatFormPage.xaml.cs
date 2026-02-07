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
    /// Логика взаимодействия для PolzovatFormPage.xaml
    /// </summary>
    public partial class PolzovatFormPage : Page
    {
        private PolzovatService _service = new();
        public Polzovat _polzovat = new();
        bool isEdit = false;
        public PolzovatFormPage(Polzovat? _editPolzovat = null)
        {
            InitializeComponent();
            if (_editPolzovat != null)
            {
                _polzovat = _editPolzovat;
                isEdit = true;
            }
            else
            {
                 _polzovat.CreateAt = DateTime.Now;
            }
            DataContext = _polzovat;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit)
                _service.Commit();
            else
                _service.Add(_polzovat);
            NavigationService.GoBack();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
