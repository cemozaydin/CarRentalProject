using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class FuelTypeOperation
    {
        FuelTypeManager fuelTypeManager = new FuelTypeManager(new EfFuelTypeDal());

        public void ListToFuelTypes()
        {
            var result = fuelTypeManager.GetAll();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(result.Message);
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine(String.Format("| {0,-15}| {1,-45}|", "ID", "YAKIT TİPİ"));
            Console.WriteLine("-----------------------------------------------------------------");

            Console.ResetColor();
            foreach (var fuelType in result.Data)
            {
                Console.WriteLine(String.Format("| {0,-15}| {1,-45}|", fuelType.Id, fuelType.FuelTypeName));
            }
            Console.WriteLine("-----------------------------------------------------------------");

        }

    }
}
