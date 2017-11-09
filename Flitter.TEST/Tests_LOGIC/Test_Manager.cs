using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flitter.DATA;

namespace Flitter.TEST.Tests_LOGIC
{
    [TestClass]
    public class Test_Manager
    {
        [TestMethod]
        public void TestGetUserbyemail()
        {
            string email = "Franz@Franz.at";
            User user = Flitter.LOGIC.Manager.UserManager.Get_UserByEmail(email);
            Assert.IsNotNull(user);
            Assert.AreEqual(email, user.Email);
        }
    }
}
