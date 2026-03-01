using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO12_2
{
    public class Polzovat : ObservableObject
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _login;
        public string Login
        {
            get => _login;
            set => SetProperty(ref _login, value);
        }
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private DateTime _created;
        public DateTime CreateAt
        {
            get => _created;
            set => SetProperty(ref _created, value);
        }
        private Passport _passport;
        public Passport Passport
        {
            get => _passport;
            set => SetProperty(ref _passport, value);
        }

        private UserProfile _profile;
        public UserProfile Profile
        {
            get => _profile;
            set => SetProperty(ref _profile, value);
        }

        private int _roleId;
        public int RoleId
        {
            get => _roleId;
            set => SetProperty(ref _roleId, value);
        }
        private Role _role;
        public Role Role
        {
            get => _role;
            set => SetProperty(ref _role, value);
        }

    }
}
