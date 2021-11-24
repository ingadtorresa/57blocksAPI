using _57blocks.Logic.Core;
using _57blocks.Logic.Models;
using _57blocks.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;

namespace _57blocks.API.Controllers
{
    public class UserLoginController : ApiController
    {
        protected TaskFactory _taskFactory = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());

        [HttpPost]
        public async Task<IHttpActionResult> InsertLogin(InsertLoginModel item)
        {
            if (item != null && item.Email != null && item.Password != null)
            {
                bool validUser = await _taskFactory.StartNew(() => UserLoginHelper.IsValidEmail(item.Email));
                if (validUser)
                {
                    validUser = await _taskFactory.StartNew(() => UserLoginHelper.ValidUserLogin(item));
                    if (!validUser)
                    {
                        Regex rx = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#?\]])([A-Za-z\d!@#?\]]|[^ ]){10,20}$");
                        if (rx.IsMatch(item.Password))
                        {
                            validUser = await _taskFactory.StartNew(() => UserLoginHelper.InsertUserLogin(item));
                            if (validUser)
                            {
                                return Ok();
                            }
                            else
                            {
                                return BadRequest("Error in Insert");
                            }
                        }
                        else
                        {
                            return BadRequest("Password is not valid");
                        }
                    }
                    else
                    {
                        return BadRequest("User already exists");
                    }
                }
                else
                {
                    return BadRequest("The Email or Password provided are invalid");
                }
            }
            else
            {
                return BadRequest("The Email or Password provided are invalid");
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> GenerateToken(InsertLoginModel item)
        {
            if (item != null && item.Email != null && item.Password != null)
            {
                bool validUser = await _taskFactory.StartNew(() => UserLoginHelper.ValidUserLogin(item));
                if (validUser)
                {
                    string token = await _taskFactory.StartNew(() => UserLoginHelper.GenerateToken(item));
                    return Ok(new {token = token });
                }
                else
                {
                    return BadRequest("User already no exists");
                }
            }
            else
            {
                return BadRequest("The Email or Password provided are invalid");
            }
        }


        [HttpPost]
        public async Task<IHttpActionResult> Login(LoginModel item)
        {
            if (item != null && item.Email != null && item.Password != null && item.Token != null)
            {
                bool valid = await _taskFactory.StartNew(() => UserLoginHelper.Login(item.Email, item.Password, item.Token));
                if (valid)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("the token is not valid or the period has expired, generate the token");
                }
            }
            else
            {
                return BadRequest("The Email or Password provided are invalid");
            }
        }
    }
}
