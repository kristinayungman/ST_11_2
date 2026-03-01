using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO12_2
{
    public class Passport : ObservableObject
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);

        }
        private int _series;
        public int Series
        {
            get => _series;
            set => SetProperty(ref _series, value);
        }
        private int _number;
        public int Number
        {
            get => _number;
            set => SetProperty(ref _number, value);
        }
        private int _polzovatId;
        public int PolzovatId
        {
            get => _polzovatId;
            set => SetProperty(ref _polzovatId, value);
        }
        private Polzovat _student;
        public Polzovat Student
        {
            get => _student;
            set => SetProperty(ref _student, value);
        }
    }
}