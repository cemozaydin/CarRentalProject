using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class BrandOperation
    {
        BrandManager brandManager = new BrandManager(new EfBrandDal());

        public void AddToBrand()
        {
            string _brandName;
            Console.Write("\nEklemek istediğiniz yeni Marka Adı : ");
            _brandName = Console.ReadLine();

            Brand brand = new Brand
            {
                BrandName = _brandName
            };

            brandManager.Add(brand);
        }
        public void ListToBrands()
        {
            var result = brandManager.GetAll();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(result.Message);
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("-------------------------");
            Console.WriteLine(String.Format("| {0,-5}| {1,-15}|", "ID", "MARKA"));
            Console.WriteLine("-------------------------");

            Console.ResetColor();
            foreach (var brands in result.Data)
            {
                Console.WriteLine(String.Format("| {0,-5}| {1,-15}|", brands.Id, brands.BrandName));
            }
            Console.WriteLine("-------------------------");
        }        
    }
}
