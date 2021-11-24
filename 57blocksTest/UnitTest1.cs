using _57blocks.Logic.Core;
using _57blocks.Logic.Models;
using _57blocks.Model.Models;
using NUnit.Framework;

namespace _57blocksTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestValidUserLogin()
        {
            InsertLoginModel userLogin = new InsertLoginModel();
            userLogin.Email = "andres@abc.com";
            userLogin.Password = "123";

            bool result = UserLoginHelper.ValidUserLogin(userLogin);
        }
    }
}