using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flitter.LOGIC;
using Flitter.DATA;

namespace Flitter.TEST.Tests_LOGIC
{
    /// <summary>
    /// Summary description for Test_Registration
    /// </summary>
    [TestClass]
    public class Test_Administration
    {
        [TestMethod]
        public void TestIfaRegistrationofanUserWorks()
        {
            string email= $"User{(DateTime.Now).ToString()}@bla.at";
            UserAdministration.Register("Franzi",email,"Franz", "Huber", "Zippererstrasse 3", "Wien",  1110, "zumFranz", DateTime.Now, "11111");
            User user= Flitter.LOGIC.Manager.UserManager.Get_UserByEmail(email);
            Assert.IsNotNull(user);
            Assert.AreEqual(email, user.Email);
        }
    }
}
