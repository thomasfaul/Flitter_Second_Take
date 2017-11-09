using System;
using System.Linq;
using System.Diagnostics;
using Flitter.DATA;
using System.Reflection;
using log4net;
using log4net.Config;



namespace Flitter.LOGIC
{

    #region Enums
    public enum RegisterResult
    {
        NotSet,
        Successful,
        UsernameExists
    }
    public enum LoginResult
    {
        NotSet,
        Successful,
        InvalidPassword,
        InvalidEmail
    } 
    #endregion

    public class UserAdministration
    {
        public static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #region Register
        /// <summary>
        /// Registers a new user in data storage
        /// adds three static user decks with randomized deck names
        /// returns true if successful, otherelse false
        /// throws exception on invalid data
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="company"></param>
        /// <param name="city"></param>
        /// <param name="address"></param>
        /// <param name="zip"></param>
        /// <returns>RegisterResult</returns>
        /// <exception cref="ArgumentException">invalid data within parameters</exception>
        /// <exception cref="Exception">in case of a database error</exception>
        public static RegisterResult Register(string username,string email, string firstname, string lastname, string address,  string city,int? zip, string company,  DateTime birthdate,string password)
        {
            XmlConfigurator.Configure();
            log.Info("UserAdministration - Register");

            RegisterResult result = RegisterResult.NotSet;

            if (string.IsNullOrEmpty(firstname))
                throw new ArgumentException($"{nameof(firstname)} is null or empty");
            if (string.IsNullOrEmpty(lastname))
                throw new ArgumentException($"{nameof(lastname)} is null or empty");
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException($"{nameof(username)} is null or empty");
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException($"{nameof(email)} is null or empty");
            if (string.IsNullOrEmpty(company))
                throw new ArgumentException($"{nameof(company)} is null or empty");
            if (string.IsNullOrEmpty(city))
                throw new ArgumentException($"{nameof(city)} is null or empty");
            if (string.IsNullOrEmpty(city))
                throw new ArgumentException($"{nameof(address)} is null or empty");
            if (zip==null)
                throw new ArgumentException($"{nameof(zip)} is null or empty");
            try
            {
                using (var context = new DB_FlitterEntities())
                {
                    User user = context.Users.FirstOrDefault(x => x.Email.Equals(email));

                    if (user != null)
                    {
                        result = RegisterResult.UsernameExists;
                        log.Debug($"Email {email} exists");
                    }
                    else
                    {
                        string userSalt = Tools.Hash_And_Salt.GenerateSalt();

                        Data data = new Data();
                        data.BirthDate = birthdate;
                        data.Salt = userSalt;

                        Role role = new Role();
                        role.UserRole = "PLAYER";

                        Avatar avatar = new Avatar();
                        avatar.Pic = new byte[1]{0};


                        data.PassWord = Tools.Hash_And_Salt.GenerateHash(password+userSalt);
                        user = new User()
                        {
                            FirstName = firstname,
                            LastName = lastname,
                            UserName = username,
                            Email = email,
                            Company = company,
                            City = city,
                            Address = address,
                            Zip = zip ?? 0,
                            Active = true,
                            EntryDate = DateTime.Now,
                            IDLocation = 2,
                            LastLogIn=DateTime.Now,
                            Data = data,
                            Role= role,
                            Avatar=avatar
                        };
                        context.Users.Add(user);
                        context.SaveChanges();
                        result = RegisterResult.Successful;
                        log.Debug($"Username {username} registered!");

                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("UserAdministration - Register - Exception", ex);
                if (ex.InnerException != null)
                    log.Error("UserAdministration - Register - Exception (inner)", ex.InnerException);

                Debugger.Break();
                throw ex;
            }

            return result;
        }
        #endregion

        #region Login

        /// <summary>
        /// Returns login status for given credentials
        /// </summary>
        /// <param name="email">email to login</param>
        /// <param name="password">password to login</param>
        /// <exception cref="ArgumentException">in case any parameter is null or empty</exception>
        /// <exception cref="Exception">in case of a database error</exception>
        /// <returns>login status for given credentials</returns>
        public static LoginResult Login(string email, string password)
        {
            log.Info("UserAdministration - Login");

            LoginResult result = LoginResult.NotSet;

            if (string.IsNullOrEmpty(email))
                throw new ArgumentException($"{nameof(email)} is null or empty");
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException($"{nameof(password)} is null or empty");

            try
            {
                string dbUserPassword = null;
                string dbUserSalt = null;

                using (var context = new DB_FlitterEntities())
                {
                    User user = context.Users.Where(u => u.Email == email).FirstOrDefault();
                    Data data = context.Data.Where(u => u.ID == user.ID).FirstOrDefault();
                    if (user == null)
                    {
                        log.Info($"{user.UserName} does not exists");
                    }
                    if (data == null)
                    {
                        log.Info($"{user.UserName} privat Data does not exists");
                    }
                    dbUserPassword = data.PassWord;
                    dbUserSalt = data.Salt;

                    log.Info("Entered Pass = " + password);

                    password = Tools.Hash_And_Salt.GenerateHash(password + dbUserSalt);

                    log.Info("HashPass = " + password);

                    if (user != null)
                    {
                        if (dbUserPassword == password)
                        {
                            result = LoginResult.Successful;
                            log.Debug($"User {user.UserName} logged in successfully");
                        }
                        else
                        {
                            result = LoginResult.InvalidPassword;
                            log.Debug($"User {user.UserName} entered invalid Password");
                        }
                    }
                    else
                    {
                        result = LoginResult.InvalidEmail;
                        log.Debug($"User {user.UserName} entered invalid Email");
                    }

                }
            }
            catch (Exception ex)
            {
                log.Error("UserAdministration - Login - Exception", ex);
                if (ex.InnerException != null)
                    log.Error("UserAdministration - Login - Exception (inner)", ex.InnerException);

                Debugger.Break();
                throw ex;
            }

            return result;
        } 
        #endregion
    }
}
