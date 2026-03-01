using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TRPO12_2
{
    public class Group : ObservableObject
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
        private ObservableCollection<Polzovat> _polzovats;
        public ObservableCollection<Polzovat> Polzovats
        {
            get => _polzovats;
            set => SetProperty(ref _polzovats, value);
        }
    }
}
