using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO12_2
{
    public class UserInterestGroup : ObservableObject
    {
        private int _userId;
        public int UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        private Polzovat _polzovat;
        public Polzovat Polzovat
        {
            get => _polzovat;
            set => SetProperty(ref _polzovat, value);
        }

        private int _interestGroupId;
        public int InterestGroupId
        {
            get => _interestGroupId;
            set => SetProperty(ref _interestGroupId, value);
        }
        private InterestGroup _interestGroup;
        public InterestGroup InterestGroup
        {
            get => _interestGroup;
            set => SetProperty(ref _interestGroup, value);
        }

        private DateOnly _joinedAt;
        public DateOnly JoinedAt
        {
            get => _joinedAt;
            set => SetProperty(ref _joinedAt, value);
        }

        private bool _isModerator;
        public bool IsModerator
        {
            get => _isModerator;
            set=> SetProperty(ref _isModerator, value);
        }

    }
}
