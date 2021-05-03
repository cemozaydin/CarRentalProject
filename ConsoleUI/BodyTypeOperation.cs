using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class BodyTypeOperation
    {
        BodyTypeManager bodyTypeManager = new BodyTypeManager(new EfBodyTypeDal());

        public void ListToBodyTypes()
        {
            var result = bodyTypeManager.GetAll();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(result.Message);
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine(String.Format("| {0,-15}| {1,-45}|", "ID", "KASA TİPİ"));
            Console.WriteLine("-----------------------------------------------------------------");

            Console.ResetColor();
            foreach (var bodyType in result.Data)
            {
                Console.WriteLine(String.Format("| {0,-15}| {1,-45}|", bodyType.Id, bodyType.BodyTypeName));
            }
            Console.WriteLine("-----------------------------------------------------------------");

        }

    }
}
