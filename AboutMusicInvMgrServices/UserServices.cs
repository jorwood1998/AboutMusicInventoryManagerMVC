using AboutMusicInvMgr.Models.User;
using AboutMusicInvMgrData;
using AboutMusicInvMgrModels.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AboutMusicInvMgrData.IdentityData;

namespace AboutMusicInvMgrServices
{
    public class UserServices
    {
        private readonly Guid _userId;

        public UserServices(Guid userId)
        {
            _userId = userId;
        }

        public bool UserCreate(UserCreate model)
        {
            var entity =
                new UserData()
                {
                    AdminId = _userId,
                    UserId = model.UserId,
                    Password = model.Password,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.User.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserList> GetUser()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .User
                        .Where(e => e.AdminId == _userId)
                        .Select(
                            e =>
                                new UserList
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

        public UserDetail GetUserById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .User
                        .Single(e => e.UserId == id && e.AdminId == _userId);
                return
                    new UserDetail
                    {
                        UserId = entity.UserId,
                        UserName = entity.UserName,
                        Password = entity.Password,
                        PhoneNumber = entity.PhoneNumber,
                    };

            }
        }

        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .User
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
                        .User
                        .Single(e => e.UserId == userId && e.AdminId == _userId);

                ctx.User.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
