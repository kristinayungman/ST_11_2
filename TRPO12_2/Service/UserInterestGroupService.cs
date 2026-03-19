using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO12_2.Data;

namespace TRPO12_2.Service
{
    public class UserInterestGroupService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public int Commit() => _db.SaveChanges();
        public void Add(UserInterestGroup courceStudent)
        {
            var _courceStundent = new UserInterestGroup
            {
                UserId = courceStudent.UserId,
                Polzovat = courceStudent.Polzovat,
                InterestGroupId = courceStudent.InterestGroupId,
                InterestGroup = courceStudent.InterestGroup,
                JoinedAt = courceStudent.JoinedAt,
                IsModerator = courceStudent.IsModerator,
            };
            _db.Add<UserInterestGroup>(_courceStundent);
            // _db.SaveChanges();
            Commit(); // Сохраняем сразу
        }
        public List<UserInterestGroup> GetUserRelations(int userId)
        {
            return _db.UserInterestGroups
                      .Include(r => r.InterestGroup) // Подгружаем информацию о группе
                      .Where(r => r.UserId == userId)
                      .ToList();
        }

    }
}
