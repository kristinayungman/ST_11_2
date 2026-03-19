using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO12_2.Data;

namespace TRPO12_2.Service
{
    public class GroupService
    {

        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<InterestGroup> InterestGroups { get; set; } = new();
        public int Commit() => _db.SaveChanges();
        public void Add(InterestGroup cource)
        {
            var _cource = new InterestGroup
            {
                Id = cource.Id,
                Title = cource.Title,
            };
            _db.Add<InterestGroup>(_cource);
            Commit();
            InterestGroups.Add(_cource);
        }
        public void GetAll()
        {
            var cources = _db.InterestGroups.Include(g => g.UserInterestGroups).ToList();  

            InterestGroups.Clear();
            foreach (var cource in cources)
            {
                InterestGroups.Add(cource);
            }
        }
       public GroupService()
        {
            GetAll();
        }
        public void Remove(InterestGroup cource)
        {
            _db.Remove<InterestGroup>(cource);
            if (Commit() > 0)
                if (InterestGroups.Contains(cource))
                    InterestGroups.Remove(cource);
        }
        public void LoadRelation(InterestGroup role, string relation)
        {
            var entry = _db.Entry(role);
            var navigation = entry.Metadata.FindNavigation(relation)
            ?? throw new InvalidOperationException($"Navigation '{relation}' not found");
            if (navigation.IsCollection)
            {
                entry.Collection(relation).Load();
            }
            else
            {
                entry.Reference(relation).Load();
            }
        }
    }
}
