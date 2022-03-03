using AboutMusicInvMgrData;
using AboutMusicInvMgrModels.Models;
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

        public bool CreateProduct(Product model)
        {
            var entity =
                new ProductData()
                {
                    AdminId = _userId,
                    ProductId = model.ProductId,
                    Price = model.Price,
                    Description = model.Description,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<Product> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Products
                        .Select(
                        e =>
                            new Product
                            {
                                ProductId = e.ProductId,
                                Description = e.Description,
                                Price = e.Price,
                            }
                        );
                return query.ToArray();
            }
        }
        public Product GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(e => e.ProductId == id);
                return

                    new Product
                    {
                        ProductId = entity.ProductId,
                        Price = entity.Price,
                        Description = entity.Description,
                    };
            }
        }
        public bool UpdateProducts(Product model)
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
