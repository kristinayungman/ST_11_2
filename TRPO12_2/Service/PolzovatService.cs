using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO12_2.Data;

namespace TRPO12_2.Service
{
    public class PolzovatService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<Polzovat> Polzovats { get; set; } = new();

        public PolzovatService()
        {
            GetAll();
        }

        public void Add(Polzovat student)
        {
            /*var _polzovat = new Polzovat
            {
                Login = student.Login,
                Name = student.Name,
                Email = student.Email,
                Password = student.Password,
                CreateAt = DateTime.Now,
            };
            _db.Add<Polzovat>(_polzovat);
            Commit();
            Polzovats.Add(_polzovat);*/
            student.CreateAt = DateTime.Now;
            _db.Add(student);
            Commit();
            Polzovats.Add(student);

        }
        public int Commit() => _db.SaveChanges();
        public void GetAll()
        {
            var polzovats = _db.Polzovats.ToList();
            Polzovats.Clear();
            foreach (var polzovat in polzovats)
            {
                Polzovats.Add(polzovat);
            }
        }

        public void Remove(Polzovat polzovat)
        {
            _db.Remove<Polzovat>(polzovat);
            if (Commit() > 0)
                if (Polzovats.Contains(polzovat))
                    Polzovats.Remove(polzovat);
        }
    }
}
