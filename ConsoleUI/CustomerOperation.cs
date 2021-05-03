using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class CustomerOperation
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        public void ListToCustomers()
        {
            var result = customerManager.GetAll();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(result.Message);
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine(String.Format("| {0,-5}| {1,-10}| {2,-44}|", "ID", "USER ID", "COMPANY NAME"));
            Console.WriteLine("------------------------------------------------------------------");

            Console.ResetColor();
            foreach (var customer in result.Data)
            {
                Console.WriteLine("| {0,-5}| {1,-10}| {2,-44}|", customer.Id, customer.UserId, customer.CompanyName);
            }
            Console.WriteLine("------------------------------------------------------------------");
        }
        public void AddToCustomer()
        {
            string _companyName;
            int _userId;
            string _nullUserId;

            Console.Write("Kullanıcı ID : ");
            _nullUserId = Console.ReadLine();

            if (_nullUserId == "" || _nullUserId == null)
            {
                Console.WriteLine("Kullanıcı ID boş geçilemez...");

            }
            else
            {
                _userId = Convert.ToInt32(_nullUserId);
                Console.Write("Şirket Adı   : ");
                _companyName = Console.ReadLine();

                Customer customer = new Customer
                {
                    UserId = _userId,
                    CompanyName = _companyName
                };
                var result = customerManager.Add(customer);
                Console.WriteLine(result.Message);
            }

        }
        public void UpdateToCustomer()
        {
            int _customerId, _userId;
            string _companyName;

            Console.Write("Güncellenecek Kayıt ID   : ");
            _customerId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Yeni Kullanıcı ID        : ");
            _userId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Yeni Şirket Adı          : ");
            _companyName = Console.ReadLine();

            Customer customer = new Customer
            {
                Id = _customerId,
                UserId = _userId,
                CompanyName = _companyName
            };

            var result = customerManager.Update(customer);
            Console.WriteLine(result.Message);
        }
        public void DeleteToCustomer()
        {
            int _deletedCustomerId;

            Console.Write("Silmek istediğiniz Kayıt ID : ");
            _deletedCustomerId = Convert.ToInt32(Console.ReadLine());

            Customer deleteCustomer = new Customer { Id = _deletedCustomerId };

            var result = customerManager.Delete(deleteCustomer);
            Console.WriteLine(result.Message);
        }
        public void ListToCustomerDetails()
        {
            var result = customerManager.GetCustomerDetails();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(result.Message);
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("| {0,-15}| {1,-15}| {2,-15}| {3,-40}|", "MÜSTERİ ID", "MÜŞTERİ ADI", "MÜŞTERİ SOYADI", "ŞİRKET ADI"));
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Console.ResetColor();
            foreach (var customer in result.Data)
            {
                Console.WriteLine("| {0,-15}| {1,-15}| {2,-15}| {3,-40}|", customer.CustomerId, customer.UserName, customer.UserLastName, customer.CompanyName);
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------");
        }
    }
}
