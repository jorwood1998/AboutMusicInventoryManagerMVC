using AboutMusicInvMgr.Models.Store;
using AboutMusicInvMgrData;
using AboutMusicInvMgrModels.StoreModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AboutMusicInvMgrData.IdentityData;

namespace AboutMusicInvMgrServices
{
    public class StoreServices
    {
        private readonly Guid _userId;

        public StoreServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateStore(StoreCreate model)
        {
            var entity =
                new StoreData()
                {
                    AdminId = _userId,
                    StoreName = model.StoreName,
                    Location = model.Location,
                    State = model.State,
                    Hours = model.Hours,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    HasOnlineProducts = model.HasOnlineProducts,
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Stores.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<StoreList> GetStores()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Stores
                        .Select(
                        e =>
                            new StoreList
                            {
                                StoreId = e.StoreId,
                                StoreName = e.StoreName,
                                Location = e.Location,
                                State = e.State,
                                Hours= e.Hours,
                                PhoneNumber= e.PhoneNumber,
                                Email= e.Email,
                                HasOnlineProducts= e.HasOnlineProducts,
                            }
                        );
                return query.ToArray();
            }
        }
        public StoreDetail GetStoreById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Stores
                    .Single(e => e.StoreId == id);
                return

                    new StoreDetail
                    {
                        StoreId = entity.StoreId,
                        StoreName = entity.StoreName,
                        Location = entity.Location,
                        State = entity.State,
                        Hours = entity.Hours,
                        PhoneNumber = entity.PhoneNumber,
                        Email = entity.Email,
                        HasOnlineProducts = entity.HasOnlineProducts,
                    };
            }
        }
        public bool UpdateStore(StoreEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Stores
                        .Single(e => e.StoreId == model.StoreId);

                entity.StoreId = model.StoreId;
                entity.StoreName = model.Name;
                entity.Location = model.Location;
                entity.State = model.State;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Email = model.Email;
                entity.HasOnlineProducts = model.HasOnlineProducts;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteStore(int storeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Stores
                        .Single(e => e.StoreId == storeId && e.AdminId == _userId);

                ctx.Stores.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
