using System;
using System.Linq;
using Flitter.DATA;
using Flitter.LOGIC;
using log4net;


namespace Flitter.CONSOLE
{
    class Program
    {

        static void Main(string[] args)
        {
            //log4net.ILog log;

            //TEST IF DATABASECONNECTION WORKS 
            //using (FlitterDataEntities context= new FlitterDataEntities())
            //{
            //   bool yes = context.User.Any(u => u.LastName == "Huber");
            //    Console.WriteLine(yes);
            //    Console.ReadLine();


            //    for (int i = 0; i < 50; i++)
            //    {
            //        User user1 = new User();
            //        user1.LastName = "Maier" + i.ToString();
            //        user1.FirstName = "Daniele" + i.ToString();
            //        user1.UserName = "Dani" + i.ToString();
            //        user1.Zip = 1111 + i;
            //        user1.Email = "Dani@Dani.at" + i.ToString();
            //        user1.Active = true;
            //        user1.Address = "RockdenRing" + i.ToString();
            //        user1.City = "Wien" + i.ToString();
            //        user1.Company = "blablabla" + i.ToString();
            //        user1.EntryDate = DateTime.Now;
            //        context.User.Add(user1);
            //        context.SaveChanges();

            //    }
            //    foreach (var item in context.User)
            //    {
            //        Console.WriteLine(item.UserName);
            //    }
            //    Console.ReadLine();

            //    User user = new User();
            //    user.LastName = "Maier";
            //    user.FirstName = "Daniele";
            //    user.UserName = "Dani";
            //    user.Zip = 1111;
            //    user.Email = "Dani@Dani.at";
            //    user.Active = true;
            //    user.Address = "RockdenRing";
            //    user.City = "Wien";
            //    user.Company = "blablabla";
            //    user.EntryDate = DateTime.Now;
            //    context.User.Add(user);
            //    context.SaveChanges();





            //    foreach (var item in context.User)
            //    {
            //        Console.WriteLine(item.ID);
            //    }
            //    Console.ReadLine();

            //    foreach (var item in context.User)
            //    {
            //        Console.WriteLine(item.UserName);
            //    }
            //    Console.ReadLine();}




            ////Test if it Loggs
            //log4net.Config.XmlConfigurator.Configure();
            //log= LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //log.Error("blablabla");
            //log.Info("blablabla");

            //Getting UserTestData
            //UserAdministration.Register("Franz","Huber","Franzi","Franz@Franz.at","zumFranz","Wien","Zippererstrasse 3",1110,DateTime.Now,"11111");
            //UserAdministration.Register("Josef", "Voititschek", "Seppi", "Josef@Franz.at", "zumJosi", "Wien", "Zippererstrasse 3", 1110, DateTime.Now, "11111");
            //UserAdministration.Register("Thomas", "Renner", "Tom", "Tom@Franz.at", "Renner", "Wien", "Zippererstrasse 3", 1110, DateTime.Now, "11111");
            //UserAdministration.Register("Andreas", "Reiser", "Andi", "Andreas@Franz.at", "Andi", "Wien", "Zippererstrasse 3", 1110, DateTime.Now, "11111");
            //UserAdministration.Register("Mirimam", "Blierbl", "Blierbi", "Miriam@Franz.at", "anz", "Wien", "Zippererstrasse 3", 1110, DateTime.Now, "11111");
            //UserAdministration.Register("Sophie", "Krautstingr", "Krauti", "Sophie@Franz.at", "zumFr", "Wien", "Zippererstrasse 3", 1110, DateTime.Now, "11111");
            //UserAdministration.Register("Johannes", "Artinger", "Josi", "Josi@Franz.at", "zuanz", "Wien", "Zippererstrasse 3", 1110, DateTime.Now, "11111");

        }
    }
}
