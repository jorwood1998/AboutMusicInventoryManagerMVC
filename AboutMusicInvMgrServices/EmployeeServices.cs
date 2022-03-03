using AboutMusicInvMgrData;
using AboutMusicInvMgrModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AboutMusicInvMgrData.IdentityData;

namespace AboutMusicInvMgrServices
{
    public class EmployeeServices
    {
        private readonly Guid _userId;

        public EmployeeServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEmployee(Employee model)
        {
            var entity =
                new EmployeeData()
                {
                    Id = model.Id,
                    LastName = model.LastName,
                    FirstName = model.FirstName,
                    HireDate = model.HireDate,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Employee.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<Employee> GetEmployee()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Employee
                        .Select(
                        e =>
                            new Employee
                            {
                                Id = e.Id,
                                LastName = e.LastName,
                                FirstName = e.FirstName,
                                HireDate = e.HireDate,
                            }
                        );
                return query.ToArray();
            }
        }
        public Employee GetStoreById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Employee
                    .Single(e => e.Id == id);
                return

                    new Employee
                    {
                        Id = entity.Id,
                        LastName = entity.LastName,
                        FirstName = entity.FirstName,
                        HireDate = entity.HireDate,
                    };
            }
        }
        public bool UpdateStore(Employee model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Employee
                        .Single(e => e.Id == model.Id);

                entity.Id = model.Id;
                entity.LastName = model.LastName;
                entity.FirstName = model.FirstName;
                entity.HireDate = model.HireDate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteStore(int storeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Employee
                        .Single(e => e.Id == storeId);

                ctx.Employee.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
