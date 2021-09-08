using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Monefy
{

    

    class Program
    {

       

        static void Main(string[] args)
        {

            // Основное меню 
            ProgramManagment program = new ProgramManagment();
            program.Start();
            if (program.LoginToSystem()) { 
            bool work = true;
                while (work)
                {
                    {
                        Console.Clear();
                        program.Balance();
                        Console.WriteLine("1.Доход \n" +
                                          "2.Росход \n" +
                                          "3.Категории \n" +
                                          "4.Счета \n" +
                                          "5.Просмотр данных \n" +
                                          "6.Настройки \n" +
                                          "7.Выход");
                    }
                    int choose = int.Parse(Console.ReadLine());
                    switch (choose)
                    {
                        case 1:

                            program.Revenue(); // Доход
                            break;
                        case 2:
                            program.Expenditure(); // Росход
                            break;
                        case 3:
                            program.Category(); // Категории
                            break;
                        case 4:
                            program.Accounts(); // Счета
                            break;
                        case 5:
                            program.PrintCategory(); // Просмотр данных по категориям
                            break;
                        case 6:
                            program.Setting(); // Настройки
                            break;
                        case 7:
                            work = false;
                            break;
                        default:
                            break;


                    }
                }
            }
            program.Save();
        }
       
    }
}
