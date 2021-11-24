using _57blocks.Logic.Models;
using _57blocks.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace _57blocks.Logic.Core
{
    public class UserLoginHelper
    {
        public static bool ValidUserLogin(InsertLoginModel item)
        {
            bool result = false;
            try
            {
                using (BlockEntities context = new BlockEntities())
                {
                    var currenItem = context.UserLogin.Where(o => o.Email == item.Email && o.Password == item.Password).FirstOrDefault();
                    if (currenItem != null)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return result;
        }

        public static bool InsertUserLogin(InsertLoginModel item)
        {
            bool result = false;
            try
            {
                using (BlockEntities context = new BlockEntities())
                {
                    UserLogin user = new UserLogin();
                    user.Email = item.Email;
                    user.Password = item.Password;
                    context.UserLogin.Add(user);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return result;
        }

        public static bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static string GenerateToken(InsertLoginModel item)
        {
            try
            {
                using (BlockEntities context = new BlockEntities())
                {
                    var currenItem = context.UserLogin.Where(o => o.Email == item.Email && o.Password == item.Password).FirstOrDefault();
                    if (currenItem != null)
                    {
                        string token = Guid.NewGuid().ToString();
                        currenItem.Token = token;
                        currenItem.LastLogin = DateTime.Now;
                        context.SaveChanges();
                        return token;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return string.Empty;
        }

        public static bool Login(string email, string password, string token)
        {
            bool result = false;
            try
            {
                UserLogin userLogin = new UserLogin();
                using (BlockEntities context = new BlockEntities())
                {
                    userLogin = context.UserLogin.Where(o => o.Email == email && o.Password == password && o.Token == token).FirstOrDefault();
                }
                if (userLogin != null)
                {
                    DateTime dateValid = userLogin.LastLogin.Value.AddMinutes(20);
                    if (dateValid > DateTime.Now)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return result;
          
        }
    }
}
