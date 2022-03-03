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
    public class CustomerServices
    {
        private readonly Guid _userId;

        public CustomerServices(Guid userId)
        {
            _userId = userId;
        }

        public bool UserCreate(Customer model)
        {
            var entity =
                new CustomerData()
                {
                    UserId = model.UserId,
                    Password = model.Password,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customer.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<Customer> GetUser()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Customer
                        .Where(e => e.AdminId == _userId)
                        .Select(
                            e =>
                                new Customer
                                {
                                    UserId = e.UserId,
                                    UserName = e.UserName,
                                    Password = e.Password,
                                    PhoneNumber = e.PhoneNumber,
                                    Email = e.Email,
                                }
                        );

                return query.ToArray();
            }
        }

        public Customer GetUserById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customer
                        .Single(e => e.UserId == id && e.AdminId == _userId);
                return
                    new Customer
                    {
                        UserId = entity.UserId,
                        UserName = entity.UserName,
                        Password = entity.Password,
                        PhoneNumber = entity.PhoneNumber,
                    };

            }
        }

        public bool UpdateUser(Customer model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customer
                        .Single(e => e.UserId == model.UserId && e.AdminId == _userId);

                entity.UserId = model.UserId;
                entity.UserName = model.UserName;
                entity.Password = model.Password;
                entity.PhoneNumber = model.PhoneNumber;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteUser(int userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customer
                        .Single(e => e.UserId == userId && e.AdminId == _userId);

                ctx.Customer.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
