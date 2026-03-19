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

namespace TRPO12_2.Pages
{
    /// <summary>
    /// Логика взаимодействия для GroupForm.xaml
    /// </summary>
    public partial class GroupForm : Page
    {
        InterestGroup _role = new();
        Service.GroupService service = new();
        bool IsEdit = false;
        public GroupForm(InterestGroup? role = null)
        {

            InitializeComponent();
            if (role != null)
            {
                service.LoadRelation(role, "UserInterestGroups");
                _role = role;
                IsEdit = true;
            }
            DataContext = _role;
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void save(object sender, RoutedEventArgs e)
        {
            if (Validation.GetHasError(TitleTextBox))
            {
                 MessageBox.Show("Исправьте ошибки в форме", "Ошибка валидации",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (IsEdit)
                service.Commit();
            else
                service.Add(_role);
            back(sender, e);
        }
    }
}