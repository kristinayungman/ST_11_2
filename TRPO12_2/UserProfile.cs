using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO12_2
{
   public class UserProfile : ObservableObject
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);

        }
        private string? _avatarUrl;
        public string? AvatarUrl
        {
            get => _avatarUrl;
            set => SetProperty(ref _avatarUrl, value);
        }
        private string? _phone;
        public string? Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }
        private DateTime _birthday;
        public DateTime Birthday
        {
            get => _birthday;
            set => SetProperty(ref _birthday, value);
        }
        private string? _bio;
        public string? Bio
        {
            get => _bio;
            set => SetProperty(ref _bio, value);
        }
        private int _polzovatId;
        public int PolzovatId
        {
            get => _polzovatId;
            set => SetProperty(ref _polzovatId, value);
        }
        private Polzovat _polzovat;
        public Polzovat Polzovat
        {
            get => _polzovat;
            set => SetProperty(ref _polzovat, value);
        }
    }
}
