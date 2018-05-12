namespace DataAccessLayer
{
    using Entities.Entities.DAL;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class DataBase : DbContext
    {
       

        public DataBase()
            : base("name=MyModel")
        {
            Database.SetInitializer(new CustomDbInitiaslizer());
            //Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<User> users { get; set; }
        public virtual DbSet<Recrutier> recruters { get; set; }
        public virtual DbSet<Vacansy> vacansies { get; set; }
        public virtual DbSet<Summary> summaries { get; set; }
        public virtual DbSet<Admin> admins { get; set; }
        public class CustomDbInitiaslizer : DropCreateDatabaseAlways<DataBase>
        {
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc aliquam molestie augue, gravida lobortis metus luctus eu.";
            protected override void Seed(DataBase context)
            {
               
                var sm = new Summary() { Info = text, Name = "Sergiy Popovych", Position = "Junior .Net Developer", Salary = 300 };
                context.users.Add(new User() { Login = "Slink", Password = "1", UserSummary = sm });

                var sm1 = new Summary() { Info = text, Name = "Andrey Ivanov", Position = "Manager", Salary = 200 };
                context.users.Add(new User() { Login = "User1", Password = "2", UserSummary = sm1 });
                var sm2 = new Summary() { Info = text, Name = "Simon Short", Position = "Bussines analytic", Salary = 800 };
                context.users.Add(new User() { Login = "User2", Password = "2", UserSummary = sm2 });
                var sm3 = new Summary() { Info = text, Name = "Kristian Cummings", Position = "Doctor", Salary = 600 };
                context.users.Add(new User() { Login = "User3", Password = "2", UserSummary = sm3 });
                var sm4 = new Summary() { Info = text, Name = "Thomas McGee", Position = "Teacher", Salary = 400 };
                context.users.Add(new User() { Login = "User4", Password = "2", UserSummary = sm4 });
                var sm5 = new Summary() { Info = text, Name = "Bennett Rice", Position = "Junior .Net Developer", Salary = 400 };
                context.users.Add(new User() { Login = "User5", Password = "2", UserSummary = sm5 });
                var sm6 = new Summary() { Info = text, Name = "Patrick Marsh", Position = "Junior .Net Developer", Salary = 200 };
                context.users.Add(new User() { Login = "User6", Password = "2", UserSummary = sm6 });
                var sm7 = new Summary() { Info = text, Name = "John Briggs", Position = "Gardener", Salary = 600 };
                context.users.Add(new User() { Login = "User7", Password = "2", UserSummary = sm7 });
                var sm8 = new Summary() { Info = text, Name = "Asher Flowers", Position = "Firefighter", Salary = 800 };
                context.users.Add(new User() { Login = "User8", Password = "2", UserSummary = sm8 });
                var sm9 = new Summary() { Info = text, Name = "Peter Arnold", Position = "Musician", Salary = 400 };
                context.users.Add(new User() { Login = "User9", Password = "2", UserSummary = sm9 });
                var sm10 = new Summary() { Info = text, Name = "Peter Arnold", Position = "Police officer", Salary = 700 };
                context.users.Add(new User() { Login = "User10", Password = "2", UserSummary = sm10 });



               
                var vc = new Vacansy() { Description = text, Purpose = "Junior .Net Developer", Remote = false, Salary = 600 };
                var vc1 = new Vacansy() { Description = text, Purpose = "Teacher", Remote = false, Salary = 500 };
                var vac = new List<Vacansy>();


                vac.Add(vc);
                vac.Add(vc1);

                context.recruters.Add(new Recrutier() { Login = "Recr", Password = "12345", vacansies = vac });

                vc = new Vacansy() { Description = text, Purpose = "Police officer", Remote = false, Salary = 700 };
                vc1 = new Vacansy() { Description = text, Purpose = "Musician", Remote = false, Salary = 300 };
                vac = new List<Vacansy>();

              

                vac.Add(vc);
                vac.Add(vc1);

                context.recruters.Add(new Recrutier() { Login = "Recr1", Password = "1", vacansies = vac });
                vc = new Vacansy() { Description = text, Purpose = "Firefighter", Remote = false, Salary = 600 };
                vc1 = new Vacansy() { Description = text, Purpose = "Gardener", Remote = false, Salary = 350 };
                vac = new List<Vacansy>();

              

                vac.Add(vc);
                vac.Add(vc1);

                context.recruters.Add(new Recrutier() { Login = "Recr2", Password = "2", vacansies = vac });
                vc = new Vacansy() { Description = text, Purpose = "Doctor", Remote = false, Salary = 670 };
                vc1 = new Vacansy() { Description = text, Purpose = "Bussines analytic", Remote = false, Salary = 400 };
                var vc2 = new Vacansy() { Description = text, Purpose = "Manager", Remote = false, Salary = 650 };
                vac = new List<Vacansy>();

              

                vac.Add(vc);
                vac.Add(vc1);
                vac.Add(vc2);

                context.recruters.Add(new Recrutier() { Login = "Recr3", Password = "3", vacansies = vac });
                context.admins.Add(new Admin() { Login = "Admin", Password = "1" });

                context.SaveChanges();
            }
        }
    }

  
}