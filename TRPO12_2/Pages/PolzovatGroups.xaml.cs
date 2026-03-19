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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TRPO12_2.Service;

namespace TRPO12_2.Pages
{
    /// <summary>
    /// Логика взаимодействия для PolzovatGroups.xaml
    /// </summary>
    public partial class PolzovatGroups : Page
    {
        private readonly Polzovat _currentUser;
        public string Login => _currentUser.Login;
        public string Name => _currentUser.Name;
        public string Email => _currentUser.Email;
        private readonly UserInterestGroupService _uigService;
        private readonly GroupService _groupService;
        public InterestGroup SelectedGroup { get; set; }//для выбранной группы
        public DateTime? SelectedJoinDate { get; set; } = DateTime.Now;

        public PolzovatGroups(Polzovat user)
        {
            InitializeComponent();
            _currentUser = user;
            _uigService = new UserInterestGroupService();
            _groupService = (GroupService)FindResource("GroupService");

            DataContext = this;
            DatePickerJoinedAt.SelectedDate = DateTime.Now;
        }


        private void AddToGroup_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedGroup == null)
            {
                MessageBox.Show("Выберите группу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newRelation = new UserInterestGroup
            {
                UserId = _currentUser.Id,
                InterestGroupId = SelectedGroup.Id,
                JoinedAt = DateOnly.FromDateTime((SelectedJoinDate ?? DateTime.Now).Date),
                IsModerator = CheckBoxModerator.IsChecked == true
                // Убрали присваивание объектов Polzovat и InterestGroup, чтобы не было конфликтов трекинга
            };

            try
            {
                // 1. Добавляем в БД
                _uigService.Add(newRelation);

                // 2. ✅ БЕЗОПАСНОЕ ОБНОВЛЕНИЕ:
                // Получаем полный свежий список из БД для этого пользователя
                var freshRelations = _uigService.GetUserRelations(_currentUser.Id);

                // 3. Очищаем старую коллекцию и наполняем новой
                if (_currentUser.UserInterestGroups == null)
                {
                    _currentUser.UserInterestGroups = new System.Collections.ObjectModel.ObservableCollection<UserInterestGroup>();
                }

                _currentUser.UserInterestGroups.Clear();
                foreach (var item in freshRelations)
                {
                    _currentUser.UserInterestGroups.Add(item);
                }

                MessageBox.Show("Вы добавлены в группу!");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}\n{ex.InnerException?.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

