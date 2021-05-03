using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class RentalOperation
    {
        RentalManager rentalManager = new RentalManager(new EfRentalDal());

        public void AddToRental()
        {
            string _tempCustomer;
            int _carId, _customerId;
            DateTime _rentDate;
            DateTime? _returnDate;

            Console.Write("Kiralaması yapacak 'Müşteri ID' : ");
            _tempCustomer = Console.ReadLine();
            if (_tempCustomer != null)
            {
                Console.Write("Kiralanacak Araç ID         : ");
                _carId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Kiralama Tarihi[aa/gg/yyyy] : ");
                _rentDate = Convert.ToDateTime(Console.ReadLine());
                _returnDate = null;
                _customerId = Convert.ToInt32(_tempCustomer);

                Rental rental = new Rental
                {
                    CarId = _carId,
                    CustomerId = _customerId,
                    RentDate = _rentDate,
                    ReturnDate = _returnDate
                };

                var result = rentalManager.Add(rental);
                Console.WriteLine(result.Message);

            }
        }

        public void UpdateToRentalReturnDate()
        {
            int _updateRentalId;
            DateTime _returnDateUpdate;

            Console.Write("Araç iadesi yapılacak 'KIRALAMA ID' : ");
            _updateRentalId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Aracın İade Tarihi [aa/gg/yyyy]     : ");
            _returnDateUpdate = Convert.ToDateTime(Console.ReadLine());

            Rental rental = new Rental
            {
                Id = _updateRentalId,
                ReturnDate = _returnDateUpdate
            };

            var result = rentalManager.UpdateReturnDate(rental);
            Console.WriteLine(result.Message);
        }
        public void ListToRentalDetails()
        {
            var result = rentalManager.GetRentalDetails();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(result.Message);
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("| {0,-3}| {1,-20}| {2,-40}| {3,-30}| {4,-15}| {5,-12}| {6,-12}| {7,-23}| {8,-23}|", "ID", "MÜŞTERİ ADI-SOYADI", "ŞİRKET ADI", "MODEL", "MARKA", "RENK", "KİRA BEDELİ", "KİRA TARİHİ", "İADE TARİHİ"));
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
            foreach (var rental in result.Data)
            {
                Console.WriteLine(String.Format("| {0,-3}| {1,-20}| {2,-40}| {3,-30}| {4,-15}| {5,-12}| {6,-12}| {7,-23}| {8,-23}|",
                                                    rental.RentalId, rental.CustomerName + " " + rental.CustomerLastName,
                                                    rental.CustomerCompanyName, rental.ModelName, rental.BrandName, rental.ColorName, rental.DailyPrice,
                                                    rental.RentDate.ToShortDateString(), rental.ReturnDate
                                                ));
            }
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        //public void AddToRental(RentalManager rentalManager)
        //{
        //    string _tempCustomer;
        //    int _carId, _customerId;
        //    DateTime _rentDate;
        //    DateTime? _returnDate;

        //    Console.Write("Kiralaması yapacak 'Müşteri ID' : ");
        //    _tempCustomer = Console.ReadLine();
        //    if (_tempCustomer != null)
        //    {
        //        Console.Write("Kiralanacak Araç ID         : ");
        //        _carId = Convert.ToInt32(Console.ReadLine());
        //        Console.Write("Kiralama Tarihi[aa/gg/yyyy] : ");
        //        _rentDate = Convert.ToDateTime(Console.ReadLine());
        //        _returnDate = null;
        //        _customerId = Convert.ToInt32(_tempCustomer);

        //        Rental rental = new Rental
        //        {
        //            CarId = _carId,
        //            CustomerId = _customerId,
        //            RentDate = _rentDate,
        //            ReturnDate = _returnDate
        //        };

        //        var result = rentalManager.Add(rental);
        //        Console.WriteLine(result.Message);

        //    }
        //}
        //public void UpdateToRentalReturnDate(RentalManager rentalManager)
        //{
        //    int _updateRentalId;
        //    DateTime _returnDateUpdate;

        //    Console.Write("Araç iadesi yapılacak 'KIRALAMA ID' : ");
        //    _updateRentalId = Convert.ToInt32(Console.ReadLine());
        //    Console.Write("Aracın İade Tarihi [aa/gg/yyyy]     : ");
        //    _returnDateUpdate = Convert.ToDateTime(Console.ReadLine());

        //    Rental rental = new Rental
        //    {
        //        Id = _updateRentalId,
        //        ReturnDate = _returnDateUpdate
        //    };

        //    var result = rentalManager.UpdateReturnDate(rental);
        //    Console.WriteLine(result.Message);
        //}
        //public void ListToRentalDetails(RentalManager rentalManager)
        //{
        //    var result = rentalManager.GetRentalDetails();

        //    Console.ForegroundColor = ConsoleColor.DarkGreen;
        //    Console.WriteLine(result.Message);
        //    Console.ForegroundColor = ConsoleColor.DarkYellow;

        //    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        //    Console.WriteLine(String.Format("| {0,-3}| {1,-20}| {2,-40}| {3,-30}| {4,-15}| {5,-12}| {6,-12}| {7,-23}| {8,-23}|", "ID", "MÜŞTERİ ADI-SOYADI", "ŞİRKET ADI", "MODEL", "MARKA", "RENK", "KİRA BEDELİ", "KİRA TARİHİ", "İADE TARİHİ"));
        //    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");

        //    Console.ResetColor();
        //    foreach (var rental in result.Data)
        //    {
        //        Console.WriteLine(String.Format("| {0,-3}| {1,-20}| {2,-40}| {3,-30}| {4,-15}| {5,-12}| {6,-12}| {7,-23}| {8,-23}|",
        //                                            rental.RentalId, rental.CustomerName + " " + rental.CustomerLastName,
        //                                            rental.CustomerCompanyName, rental.ModelName, rental.BrandName, rental.ColorName, rental.DailyPrice,
        //                                            rental.RentDate.ToShortDateString(), rental.ReturnDate
        //                                        ));
        //    }
        //    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        //}
    }
}
