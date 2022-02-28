using AboutMusicInvMgr.Models.Product;
using AboutMusicInvMgrData;
using AboutMusicInvMgrModels.ProductModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AboutMusicInvMgrData.IdentityData;

namespace AboutMusicInvMgrServices
{
    public class ProductServices
    {
        private readonly Guid _userId;

        public ProductServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new ProductData()
                {
                    AdminId = _userId,
                    ProductId = model.ProductId,
                    Price = model.Price,
                    Description = model.Description,
                    ProductName = model.ProductName,
                    ModelNumber = model.ModelNumber,
                    Location = model.Location,
                    IsAvalibleOnline = model.IsAvalibleOnline,
                    Manufacturer = model.Manufacturer,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Products
                        .Select(
                        e =>
                            new ProductListItem
                            {
                                ProductId = e.ProductId,
                                ProductName= e.ProductName,
                                Description = e.Description,
                                Price = e.Price,
                                Manufacturer = e.Manufacturer,
                                IsAvalibleOnline= e.IsAvalibleOnline,
                                ModelNumber= e.ModelNumber,
                                Location= e.Location,
                            }
                        );
                return query.ToArray();
            }
        }
        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(e => e.ProductId == id);
                return

                    new ProductDetail
                    {
                        ProductId = entity.ProductId,
                        Price = entity.Price,
                        Description = entity.Description,
                        ProductName = entity.ProductName,
                        ModelNumber = entity.ModelNumber,
                        Location = entity.Location,
                        IsAvailableOnline = entity.IsAvalibleOnline,
                        Manufacturer = entity.Manufacturer,
                    };
            }
        }
        public bool UpdateProducts(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId == model.ProductId);

                entity.ProductId = model.ProductId;
                entity.Price = model.Price;
                entity.Description = model.Description;
                entity.ProductName = model.ProductName;
                entity.ModelNumber = model.ModelNumber;
                entity.Location = model.Location;
                entity.IsAvalibleOnline = model.IsAvalibleOnline;
                entity.Manufacturer = model.Manufacturer;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProduct(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId == productId && e.AdminId == _userId);

                ctx.Products.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
