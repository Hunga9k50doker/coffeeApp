using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ServiceController : ApiController
    {
        // GET title
        [Route("api/ServiceController/hello")]
        [HttpGet]
        public IHttpActionResult Helo()
        {
            try
            {
              
                return Ok("19520101");
            }
            catch
            {
                return NotFound();
            }
        }
        // GET coffee
        [Route("api/ServiceController/GetAllItems")]
        [HttpGet]
        public IHttpActionResult GetAllItems()
        {
            try
            {
                DataTable result = Database.Database.ReadTable("Proc_GetAllItems");
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        // GET coffee by id
        [Route("api/ServiceController/GetItemById")]
        [HttpGet]
        public IHttpActionResult GetItemById(int macd)
        {
            try
            {
                Dictionary<string, object> param = new Dictionary<string, object>();
                param.Add("macd", macd);
                DataTable result = Database.Database.ReadTable("Proc_GetItemById", param);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

       //Add coffee
        [Route("api/ServiceController/AddCoffee")]
        [HttpPost]
        public IHttpActionResult AddCoffee(Coffee cf)
        {
            try
            {
                int kq = Database.Database.AddCoffee(cf);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/ServiceController/EditCoffee")]
        [HttpPost]
        public IHttpActionResult EditCoffee(Coffee lh)
        {
            try
            {
                int kq = Database.Database.EditCoffee(lh);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/ServiceController/DeleteCoffee")]
        [HttpPost]
        public IHttpActionResult DeleteCoffee(Coffee lh)
        {
            try
            {
                int kq = Database.Database.DeleteCoffee(lh);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/ServiceController/Login")]
        [HttpGet]
        public IHttpActionResult Login(string TenDangNhap, string MatKhau)
        {
            try
            {
                User nd = Database.Database.Login(TenDangNhap, MatKhau);

                return Ok(nd);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/ServiceController/Register")]
        [HttpPost]
        public IHttpActionResult Register(User nd)
        {
            try
            {
                User kq = Database.Database.AddUser(nd);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/ServiceController/AddCart")]
        [HttpPost]
        public IHttpActionResult AddCart(Cart gh)
        {
            try
            {
                int kq = Database.Database.AddCart(gh);

                return Ok(kq);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}

