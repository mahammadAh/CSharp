using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy
{     // Класс реализирующий пункты , а также подпукнты основного меню в своих методах 
    class ProgramManagment
    {
        Menu menu = new Menu();
       

        public void Balance()
        {
            menu.Balance();
        } // Пункт Баланс

        public void Revenue()
        {
            bool work = true;
            while (work)
            {
                Console.Clear();
                Console.WriteLine("1.Добавить прибыль \n" +
                                  "2.Вычесть  прибыль\n" +
                                  "3.Выход");
                int choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        menu.Profit();
                        break;
                    case 2:
                        Console.Clear();
                        menu.DeleteProfit();
                        break;
                    case 3:
                        work = false;
                        break;
                    default:
                        break;


                }
            }
        } //  Пункт Прибыль

        public void Expenditure()
        {
            bool work = true;
            while (work)
            {
                Console.Clear();
                Console.WriteLine("1.Добавить расход \n" +
                                  "2.Вычесть расход\n" +
                                  "3.Выход");
                int choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        menu.Rate();
                        break;
                    case 2:
                        Console.Clear();
                        menu.DeleteRate();
                        break;
                    case 3:
                        work = false;
                        break;
                    default:
                        break;


                }
            }
        } //  Пункт Расход

        public void Category()
        {
            bool work = true;
            while (work)
            {
                Console.Clear();
                Console.WriteLine("1.Добавить категорию \n" +
                                  "2.Удалить категорию\n" +
                                  "3.Выход");
                int choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        menu.Category();
                        break;
                    case 2:
                        Console.Clear();
                        menu.Category();
                        break;
                    case 3:
                        work = false;
                        break;
                    default:
                        break;


                }
            }
        }  //  Пункт Категории

        public void Accounts()
        {
            bool work = true;
            while (work)
            {
                Console.Clear();
                Console.WriteLine("1.Добавить счет \n" +
                                  "2.Удалить счет\n" +
                                  "3.Типы прибыли\n" +
                                  "4.Выход");
                int choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        menu.Account();
                        break;
                    case 2:
                        Console.Clear();
                        menu.DeleteAccount();
                        break;
                    case 3:
                        RevenueType();
                        break;
                    case 4:
                        work = false;
                        break;
                    default:
                        break;


                }
            }
        } //  Пункт Счета

        public void RevenueType()
        {
            bool work = true;
            while (work)
            {
                Console.Clear();
                Console.WriteLine("1.Добавить тип прибыли \n" +
                                  "2.Удалить тип прибыли\n" +
                                  "3.Выход");
                int choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Console.Clear();
                        menu.Income();
                        break;
                    case 2:
                        Console.Clear();
                        menu.DeleteIncome();
                        break;
                    case 3:
                        work = false;
                        break;
                    default:
                        break;


                }
            }
        }   //  Подпункт тип прибыли

        public void PrintCategory()
        {
            menu.PrintCategory();
        }   // Пункт выводящий данные по категориям


        public void Setting()
        {
            bool work = true;
            while (work)
            {
                Console.Clear();
                Console.WriteLine("1.Пароль \n" +
                                  "2.Валюта \n" +                          
                                  "3.Выход");

                int choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Password();
                        break;
                    case 2:
                        Currency();
                        break;
                    case 3:
                        work = false;
                        break;
                    default:
                        break;


                }


            }
        }   // Пункт Настройки

        public void Password()
        {
            bool work = true;
            while (work)
            {
                Console.Clear();
                Console.WriteLine("1.Задать пароль \n" +
                                     "2.Удалить пароль \n" +
                                     "3.Выхд");

                int choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                       menu.Secuirty().SetPassword();
                        break;
                    case 2:
                        menu.Secuirty().DeletePassword();
                        break;
                    case 3:
                        work = false;
                        break;
                    default:
                        break;


                }
            }

        }  // Подпункт Пароль

        public bool LoginToSystem()
        {
            return menu.Secuirty().Autirization();
        }  // Метод контролирующий вход в систему

        public void Currency()
        {

            menu.CurrencyExchange();

        } // Подпункт Выюор Валюты

        public void Save()
        {
            menu.Save();
        }

        public void Start()
        {
            menu.Start();
        }



    }

}
