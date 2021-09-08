using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Threading.Thread;

namespace Monefy
{
    
    class Income
    {
       
        public string IncomeName { get; set; }
        public double Amount { get; set; }
    }

    
    class Account
    {
        public List<Income> income = new List<Income>();

        public string AccountName { get; set; }

        public void CreateIncome()  // Метод для создания нового типа прибыли
        {
            Console.WriteLine("Название прибыли: ");
            income.Add(new Income());
            income[income.Count - 1].IncomeName = Console.ReadLine();
            Console.Clear();
        }

        public void DeleteIncome() // Метод для удаления типов прибыли
        {
            this.PrintIncomeList();
            Console.WriteLine("Удалить категорию под номером: ");
            int choose = int.Parse(Console.ReadLine());
            income.RemoveAt(choose - 1);
            Console.Clear();
        }

        public void AddMoneyToIncome(double sum) // метод для добавления денег к определенному типу прибыли
        {
            
            bool end = true;
            while (end)
            {
                Console.Clear();
                this.PrintIncomeList();
                Console.WriteLine("Добавить к прибыли под номером: ");
                int choose = int.Parse(Console.ReadLine());
                Console.Clear();


                if (choose > 0 && choose <= income.Count)
                {
                    Console.WriteLine($"Прибыль: {income[choose - 1].IncomeName} ");
                    income[choose - 1].Amount += sum;
                    Console.WriteLine(income[choose - 1].Amount);
                    Sleep(1000);
                    Console.Clear();
                    end = false;
                }
                else Console.WriteLine($"Несуществующий номер ! ");

            }
        }

        public void DeleteMoneyFromIcome(double sum) // метод для удаления прибыли из определенного типа прибыли
        {
         
            bool end = true;
            while (end)
            {
                Console.Clear();
                this.PrintIncomeList();
                Console.WriteLine("Удалить из категорию под номером: ");
                int choose = int.Parse(Console.ReadLine());
                Console.Clear();
                if (choose > 0 && choose <= income.Count)
                {
                    Console.WriteLine($"Категория: {income[choose - 1].IncomeName} ");
                    if (income[choose - 1].Amount - sum >= 0)
                    {
                        income[choose - 1].Amount -= sum;
                    }
                    else Console.WriteLine("Отрицательная сумма!!!");
                    Console.WriteLine(income[choose - 1].Amount);
                    Sleep(1000);
                    Console.Clear();
                    end = false;
                }
                else Console.WriteLine($"Несуществующий номер ! ");
            }
        }

        private void PrintIncomeList() // метод печатающий все типы прибыли в пронумерованным порядке 
        {
            int i = 1;
            Console.WriteLine("Доход от: ");
            foreach (var item in income)
            {
                Console.WriteLine(i.ToString() + ": " + item.IncomeName, "\n");
                i++;
            }
        }

       
    }

    [Serializable]
    class AccountManagement
    {
        public List<Account> account = new List<Account>();
        public string currenyName = "RUB";

        public void CreatAccount() // Метод для создания счета
        {
            Console.WriteLine("Название счета: ");
            account.Add(new Account());
            account[account.Count - 1].AccountName = Console.ReadLine();
            Console.Clear();
        }

       public void DeleteAccount() // Метод для удаления счета 
        {
            
                this.PrintAccountList();
                Console.WriteLine("Удалить категорию под номером: ");
                int choose = int.Parse(Console.ReadLine());
            if (choose > 0 && choose <= account.Count)
            {
                account.RemoveAt(choose - 1);
                Console.Clear();
            }


        }

        public void CreateIncome()
        {
            Console.WriteLine("Добавить тип прибыли в: ");
            this.PrintAccountList();
            int choose = int.Parse(Console.ReadLine());
            if (choose > 0 && choose <= account.Count)
            {
                account[choose - 1].CreateIncome();
            }
        }  // Метод для добавления нового типа прибыли в счет

        public void DeleteIncome()
        {
            Console.WriteLine("Удалить тип прибыли из: ");
            this.PrintAccountList();
            int choose = int.Parse(Console.ReadLine());
            if (choose > 0 && choose <= account.Count)
            {
                account[choose - 1].DeleteIncome();
            }
        }  // Метод для удаления типа прибыли из счета

        public void AddMoneyToAccount (double sum)
        {
            bool end = true;
            while (end)
            {
                Console.Clear();
                Console.WriteLine("Добавить в счет: ");
                this.PrintAccountList();
                int choose = int.Parse(Console.ReadLine());
                if (choose > 0 && choose <= account.Count)
                {
                    account[choose - 1].AddMoneyToIncome(sum);
                    end = false;
                }
                else Console.WriteLine($"Несуществующий номер ! ");
            }
        }// Метод для добавления прибыли в определнный тип прибыли в определенном счету

        public void DeleteMoneyFromAccount(double sum)
        {
            bool end = true;
            while (end)
            {
                Console.Clear();
                Console.WriteLine("Удалить из счета: ");
                this.PrintAccountList();
                int choose = int.Parse(Console.ReadLine());
                if (choose > 0 && choose <= account.Count)
                {
                   account[choose - 1].DeleteMoneyFromIcome(sum);
                    end = false;
                }
                else Console.WriteLine($"Несуществующий номер ! ");

            }
        }// Метод для удаления прибыли из определенного тип прибыли из определенного счета

        public void Exchange (float coefficient)
        {
            foreach (var item in account)
            {
                
                foreach (var item1 in item.income)
                {
                    item1.Amount *= coefficient;
                }
            }
        } // Метод конвертирующий валюту счетов 
        private void PrintAccountList() // Метод выводящий все существующие счета
        {
            int i = 1;
            Console.WriteLine("Счета: ");
            foreach (var item in account)
            {
                Console.WriteLine(i.ToString() + ": " + item.AccountName, "\n");
                i++;
            }
        }

    }
}
