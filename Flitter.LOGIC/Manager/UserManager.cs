using Flitter.DATA;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Flitter.LOGIC.Manager
{
    public class UserManager
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Get User by Email
        /// <summary>
        /// Takes a string with email of the User
        /// returns a list of Person with the email
        /// </summary>
        /// <param name="uemail"></param>
        /// <returns></returns>
        public static User Get_UserByEmail(string email)
        {
            log.Info("Usermanager-Get_UserbyEmail");

            User user = null;
            try
            {
                using (var db = new DB_FlitterEntities())
                {
                    user = db.Users.Where(u => u.Email == email).FirstOrDefault();
                    if (user == null)
                    {
                        log.Info("User doesn't exist");
                    }
                }
            }
            catch (Exception e)
            {
                Debugger.Break();
                log.Error("Get_UserbyEmail", e);
            }
            return user;
        }
        #endregion
    }
}
