using AboutMusicInvMgr.Models.User;
using AboutMusicInvMgrServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AboutMusicInventoryManagerMVC.Controllers
{
    public class UserController : ApiController
    {
        //Post(Create)

        private UserServices CreateUserService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var UserService = new UserServices(userId);
            return UserService;


        }


        [HttpPost]
        public IHttpActionResult Post(UserCreate user)
        {

            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var service = CreateUserService();
            if (!service.UserCreate(user)) { return InternalServerError(); }
            return Ok($"New account '{user.UserId}' created!");
        }


        [HttpGet]
        public IHttpActionResult Get()
        {
            UserServices productService = CreateUserService();
            var user = productService.GetUser();
            return Ok(user);

        }

        //Get By ID
        public IHttpActionResult GetById(int id)
        {
            UserServices service = CreateUserService();
            var user = service.GetUserById(id);
            return Ok(user);
        }

        //Put (update)
        [HttpPut]
        public IHttpActionResult Put(UserEdit user)

        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.UpdateUser(user)) return InternalServerError();

            return Ok($" User '{user.UserId}' was updated");

        }

        //Delete (delete)

        public IHttpActionResult Delete(int id)
        {
            var service = CreateUserService();
            if (!service.DeleteUser(id)) return InternalServerError();
            return Ok($"Successfully Deleted User {id} ");
        }
    }
}