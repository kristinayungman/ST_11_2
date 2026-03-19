using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO12_2
{
   public class InterestGroup : ObservableObject
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string? _description;
        public string? Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }


        /*private ObservableCollection<Polzovat> _polzovats;
        public ObservableCollection<Polzovat> Polzovats
        {
            get => _polzovats;
            set => SetProperty(ref _polzovats, value);
        }*/
        private ObservableCollection<UserInterestGroup> _userInterestGroup;
        public ObservableCollection<UserInterestGroup> UserInterestGroups
        {
            get => _userInterestGroup;
            set => SetProperty(ref _userInterestGroup, value);
        }

    }
}
