using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class UserOperation
    {
        UserManager userManager = new UserManager(new EfUserDal());
        public void DeleteToUser()
        {
            int _deleteUserId;
            ListToUsers();
            Console.WriteLine();

            Console.Write("Silmek istediğiniz Kayıt ID : ");
            _deleteUserId = Convert.ToInt32(Console.ReadLine());

            User deleteUser = new User { Id = _deleteUserId };

            var result = userManager.Delete(deleteUser);
            Console.WriteLine(result.Message);
        }

        public void UpdateToUser()
        {
            string _firstName, _lastName, _email, _password;
            int _updateUserId;

            ListToUsers();
            Console.WriteLine();

            Console.Write("Güncellenecek UserID : ");
            _updateUserId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Adı          :");
            _firstName = Console.ReadLine();
            Console.Write("Soyadı       :");
            _lastName = Console.ReadLine();
            Console.Write("Email        :");
            _email = Console.ReadLine();
            Console.Write("Şifre        :");
            _password = Console.ReadLine();

            User user = new User
            {
                Id = _updateUserId,
                FirstName = _firstName,
                LastName = _lastName,
                Email = _email,
                //PasswordHash = _password
            };

            var result = userManager.Update(user);
            Console.WriteLine(result.Message);
        }

        public void ListToUsers()
        {
            var result = userManager.GetAll();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(result.Message);
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("| {0,-5}| {1,-20}| {2,-20}| {3,-25}|", "ID", "AD", "SOYAD", "EMAIL"));
            Console.WriteLine("-------------------------------------------------------------------------------");

            Console.ResetColor();
            foreach (var user in result.Data)
            {
                Console.WriteLine(String.Format("| {0,-5}| {1,-20}| {2,-20}| {3,-25}|", user.Id, user.FirstName, user.LastName, user.Email));
            }
            Console.WriteLine("-------------------------------------------------------------------------------");

        }

        public void AddToUser()
        {
            string _firstName, _lastName, _email, _password;

            Console.Write("Kullanıcı Adı        : ");
            _firstName = Console.ReadLine();
            Console.Write("Kullanıcı Soyadı     : ");
            _lastName = Console.ReadLine();
            Console.Write("Kullanıcı Email      : ");
            _email = Console.ReadLine();
            Console.Write("Kullanıcı Şifre      : ");
            _password = Console.ReadLine();

            User user = new User
            {
                FirstName = _firstName,
                LastName = _lastName,
                Email = _email,
                //Password = _password
            };

            var result = userManager.Add(user);
            Console.WriteLine(result.Message);
        }
    }
}
