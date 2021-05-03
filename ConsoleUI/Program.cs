using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int _secim;
            bool _loop = true;          
            int _carModelId, _deleteModelId;            
                       
            MainLogo mainLogo = new MainLogo();
            MainMenuOperation mainMenuOperation = new MainMenuOperation();
            BrandOperation brandOperation = new BrandOperation();
            ColorOperation colorOperation = new ColorOperation();
            CarOperation carOperation = new CarOperation();
            ModelOperation modelOperation = new ModelOperation();
            UserOperation userOperation = new UserOperation();
            CustomerOperation customerOperation = new CustomerOperation();
            RentalOperation rentalOperation = new RentalOperation();
            BodyTypeOperation bodyTypeOperation = new BodyTypeOperation();
            FuelTypeOperation fuelTypeOperation = new FuelTypeOperation();
            GearTypeOperation gearTypeOperation = new GearTypeOperation();

            do
            {
                mainLogo.ProjectLogo();
                mainMenuOperation.MainMenu();

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("\n SEÇİMİNİZ : ");
                Console.ResetColor();
                string _tempString = Console.ReadLine();
                

                if (_tempString == "")
                {
                    _secim = 0;
                }
                else
                {
                    _secim = Convert.ToInt32(_tempString);
                }

                Console.WriteLine();

                switch (_secim)
                {
                    case 1:
                        brandOperation.ListToBrands();                        
                        Console.WriteLine();
                        colorOperation.ListToColors();
                        Console.WriteLine();
                        bodyTypeOperation.ListToBodyTypes();
                        Console.WriteLine();
                        fuelTypeOperation.ListToFuelTypes();
                        Console.WriteLine();
                        gearTypeOperation.ListToGearTypes();
                        Console.WriteLine();
                        modelOperation.ListToModels();
                        Console.WriteLine();

                        _carModelId = modelOperation.AddToModel();                     
                        carOperation.AddToCar(_carModelId);

                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 2:
                        carOperation.ListToCars();
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 3:
                        brandOperation.ListToBrands();
                        carOperation.ListToCarsByBrandId();
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 4:
                        colorOperation.ListToColors();
                        carOperation.ListToCarsByColorId();
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 5:
                        _carModelId = carOperation.UpdateToCar();
                        modelOperation.UpdateToModel(_carModelId);

                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 6:
                        _deleteModelId = carOperation.DeleteToCar();
                        modelOperation.DeleteToModel(_deleteModelId);
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 7:
                        brandOperation.ListToBrands();
                        brandOperation.AddToBrand();
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 8:
                        brandOperation.ListToBrands();
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 9:
                        colorOperation.ListToColors();
                        colorOperation.AddToColor();
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 10:
                        colorOperation.ListToColors();
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 11:
                        userOperation.AddToUser();
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 12:
                        userOperation.ListToUsers();
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 13:
                        userOperation.UpdateToUser();
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 14:
                        userOperation.DeleteToUser();
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 15:
                        userOperation.ListToUsers();
                        Console.WriteLine();
                        customerOperation.AddToCustomer();
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 16:
                        customerOperation.ListToCustomers();
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 17:
                        userOperation.ListToUsers();
                        Console.WriteLine();
                        customerOperation.ListToCustomers();
                        Console.WriteLine();
                        customerOperation.UpdateToCustomer();
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 18:
                        customerOperation.ListToCustomers();
                        Console.WriteLine();
                        customerOperation.DeleteToCustomer();
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 19:
                        carOperation.ListToCars();
                        customerOperation.ListToCustomerDetails();
                        Console.WriteLine();

                        rentalOperation.AddToRental();                        
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 20:
                        rentalOperation.ListToRentalDetails();                        
                        Console.WriteLine();                       
                        rentalOperation.UpdateToRentalReturnDate();
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 21:
                        rentalOperation.ListToRentalDetails();                        
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Hatalı seçim !!!");
                        Console.Write("\nMenüye dönmek için ENTER tuşuna basınız....");
                        Console.ReadLine();
                        break;
                    case 99:
                        _loop = false;
                        break;
                }
            } while (_loop);
                        
        }

    }
}
