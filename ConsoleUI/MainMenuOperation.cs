using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class MainMenuOperation
    {
        public void MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine(String.Format(@" _________________________________________ ANA MENÜ ___________________________________________________"));
            Console.WriteLine(String.Format("| {0,50}{1,-50} |", "", ""));
            Console.WriteLine(String.Format("| {0,-50}{1,-50} |", " [ 1 ] - Araç Ekleme", "[ 11] - Kullanıcı Ekleme"));
            Console.WriteLine(String.Format("| {0,-50}{1,-50} |", " [ 2 ] - Araç Listeleme - <Tamamı>", "[ 12] - Kullanıcı Listeleme"));
            Console.WriteLine(String.Format("| {0,-50}{1,-50} |", " [ 3 ] - Araç Listeleme - <Markasına Göre>", "[ 13] - Kullanıcı Güncelleme"));
            Console.WriteLine(String.Format("| {0,-50}{1,-50} |", " [ 4 ] - Araç Listeleme - <Rengine Göre>", "[ 14] - Kullanıcı Silme"));
            Console.WriteLine(String.Format("| {0,-50}{1,-50} |", " [ 5 ] - Araç Güncelleme", "[ 15] - Müşteri Ekleme"));
            Console.WriteLine(String.Format("| {0,-50}{1,-50} |", " [ 6 ] - Araç Silme", "[ 16] - Müşteri Listeleme"));
            Console.WriteLine(String.Format("| {0,-50}{1,-50} |", " [ 7 ] - Marka Ekleme", "[ 17] - Müşteri Güncelleme"));
            Console.WriteLine(String.Format("| {0,-50}{1,-50} |", " [ 8 ] - Marka Listeleme", "[ 18] - Müşteri Silme"));
            Console.WriteLine(String.Format("| {0,-50}{1,-50} |", " [ 9 ] - Renk Ekleme", "[ 19] - Araç Kirala"));
            Console.WriteLine(String.Format("| {0,-50}{1,-50} |", " [ 10] - Renk Listeleme", "[ 20] - Araç Kiralama Güncelle"));
            Console.WriteLine(String.Format("| {0,-50}{1,-50} |", "", "[ 21] - Araç Kiralama Listesi"));
            Console.WriteLine(String.Format("| {0,50}{1,-50} |", "", ""));
            Console.WriteLine(String.Format("| {0,50}{1,-50} |", "", ""));
            Console.WriteLine(String.Format("| {0,50}{1,-50} |", "[ 99] - ÇIKIŞ", ""));
            Console.WriteLine(String.Format("| {0,50}{1,-50} |", "", ""));
            Console.WriteLine(String.Format(@"|______________________________________________________________________________________________________|"));
        }
    }
}
