using AboutMusicInvMgr.Models.Store;
using AboutMusicInvMgrServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AboutMusicInventoryManagerMVC.Controllers
{
    public class StoreController : ApiController
    {
        //Post(Create)

        private StoreServices CreateStoreService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var StoreService = new StoreServices(userId);
            return StoreService;


        }


        [HttpPost]
        public IHttpActionResult Post(StoreCreate store)
        {

            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var service = CreateStoreService();
            if (!service.CreateStore(store)) { return InternalServerError(); }
            return Ok($"New location '{store.StoreId}' added!");
        }


        [HttpGet]
        public IHttpActionResult Get()
        {
            StoreServices storeService = CreateStoreService();
            var product = storeService.GetStores();
            return Ok(product);

        }

        //Get By ID
        public IHttpActionResult GetById(int id)
        {
            StoreServices services = CreateStoreService();
            var store = services.GetStoreById(id);
            return Ok(store);
        }

        //Put (update)
        [HttpPut]
        public IHttpActionResult Put(StoreEdit store)

        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateStoreService();

            if (!service.UpdateStore(store)) return InternalServerError();

            return Ok($" Item '{store.StoreId}' was updated");

        }

        //Delete (delete)

        public IHttpActionResult Delete(int id)
        {
            var service = CreateStoreService();
            if (!service.DeleteStore(id)) return InternalServerError();
            return Ok($"Successfully Deleted Store {id} ");
        }
    }
}