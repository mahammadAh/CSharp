using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy
{
    class Menu
    {
         CategoryManagement myCategory = new CategoryManagement();
         AccountManagement myAccount = new AccountManagement();
        CurrencyExchange currencyExchange = new CurrencyExchange();
        Secuirty secuirty = new Secuirty();
        SaveInFile saveInFile = new SaveInFile();

        public void Balance () 
        {
            double sum=0;

            foreach (var item in myAccount.account)
            {
                foreach( var item1 in item.income)
                {
                    sum += item1.Amount;
                }
            }
            Console.WriteLine("Баланс:" + sum + ' ' + myAccount.currenyName);
        }   // Вычисление баланса и вывод на экран 

        public void Profit () // Реализация вызова методов Записи прибыли
        {
            Console.WriteLine("Введите сумму: ");
            double sum = double.Parse(Console.ReadLine());
            myAccount.AddMoneyToAccount(sum);
        }

        public void DeleteProfit() //  Реализация вызова методовУдаление прибыли
        {
            Console.WriteLine("Введите сумму: ");
            double sum = double.Parse(Console.ReadLine());
            myAccount.DeleteMoneyFromAccount(sum);
        }

        public void Rate () // Реализация вызова методов   Записи расходов
        {
            Console.WriteLine("Введите сумму: ");
            double sum = double.Parse(Console.ReadLine());
            myAccount.DeleteMoneyFromAccount(sum);
            myCategory.AddSpentFunds(sum);
        }


        public void DeleteRate() //  Реализация вызова методов  Удаления Расходов 
        {
            Console.WriteLine("Введите сумму: ");
            double sum = double.Parse(Console.ReadLine());
            myCategory.DeleteSpentFunds(sum);
            myAccount.AddMoneyToAccount(sum);
        }

        public void Transfer()
        {
            Console.WriteLine("Введите сумму: ");
            double sum = double.Parse(Console.ReadLine());
            myAccount.DeleteMoneyFromAccount(sum);
            myAccount.AddMoneyToAccount(sum);

        } //  Реализация вызова методов перевода денег с счета на счет

        public void Category() //  Реализация вызова методов Добавлеине котегорий
        {
            myCategory.CreateCategory();
        }

        public void DeleteCategory() //  Реализация вызова методов Удалине категорий
        {
            myCategory.DeleteCategory();
        }

        public void Account()
        {
            myAccount.CreatAccount();

        } //  Реализация вызова методов создания счета

        public void DeleteAccount()
        {
            myAccount.DeleteAccount();
        } // Реализация вызова методов удаления счета

        public void Income()
        {
            myAccount.CreateIncome();
        }  // Реализация вызова методов создания типа прибыли на определенном счету

       public void DeleteIncome()
        {
            myAccount.DeleteIncome();
        } //  Реализация вызова методов удаления типа прибыли на определенном счету

        public void PrintCategory()
        {
            Console.Clear();
            Console.WriteLine("Просмотр расходов за \n  1.День \n 2. Неделю \n 3. Месяц \n 4. Год \n 5. Ввесте произвольную дату  \n6.Выход \n");
            int num = int.Parse(Console.ReadLine());
            DateTime date1=DateTime.Now, date2=DateTime.Now;
           
            switch (num)
            {
                case 1:
                    date2 = DateTime.Now;
                    date1 = date2;
                    break;
                case 2:
                    date2 = DateTime.Now;
                    date1 = date2;
                    date1.AddDays(-7);
                    break;
                case 3:
                    date2 = DateTime.Now;
                    date1 = date2;
                    date1.AddMonths(-1);
                    break;
                case 4:
                    date2 = DateTime.Now;
                    date1 = date2;
                    date1.AddYears(-1);
                    break;
                case 5:
                    date1 = DateTime.Parse(Console.ReadLine());
                    date2 = DateTime.Parse(Console.ReadLine());
                    break;
                case 6:
                    break;
            }
            myCategory.PrintCategoryListWithMoneyAmount(date1,date2);
            
        }   // Реализаци вызова метода Вывод категорий и просмотр затрат по периодам времени

        public void CurrencyExchange()
        {
            Console.Clear();
            Console.WriteLine("Перевести в: ");
            List<string> currencyName = new List<string>() { "AUD", "AZN", "GBP", "AMD", "BYN", "BGN", "BRL", "HUF", "HKD", "DKK", "USD", "EUR", "INR", "KZT", "CAD", "KGS", "CNY", "MDL", "NOK", "PLN", "RON", "XDR", "SGD", "TJS", "TRY", "TMT", "UZS", "UAH", "CZK", "SEK", "CHF", "ZAR", "KRW", "JPY" , "RUB"};
            float coefficient;
            int i = 1;
            foreach (var item in currencyName)
            {
                Console.WriteLine(i + ": " + item + "\n");
                i++;
            }
            int choose = int.Parse(Console.ReadLine());
            coefficient=currencyExchange.Exchange(myAccount.currenyName, currencyName[choose - 1]);
            myAccount.currenyName = currencyName[choose - 1];
            myAccount.Exchange(coefficient);



        } //  Реализаци вызова метода перевод с одной валюты на другую

        public Secuirty Secuirty ()
        {
            return secuirty;
        }
        public void Save()
        {
           
            saveInFile.WriteToFile("myAccount.json", myAccount);
            saveInFile.WriteToFile("myCategory.json", myCategory);
            saveInFile.WriteToFile("secuirty.json", secuirty);

        }

        public void Start()
        {
            myAccount= saveInFile.ReadFromFile("myAccount.json", myAccount);
            myCategory = saveInFile.ReadFromFile("myCategory.json", myCategory);
            secuirty = saveInFile.ReadFromFile("secuirty.json", secuirty);
        }

    }
}
