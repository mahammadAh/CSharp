using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Threading.Thread;



namespace Monefy
{
  
    class Consumption  // Класс хранящий количество потраченных средств в день 
    {
        DateTime date ;

        public DateTime Date { get { return date; } set { date = value; } }
        public double Amount { get; set; }


    }


  
    class Category // Класс позволяющий создавать новые категории
    {   
        public string FuncName { get; set; }
        public List<Consumption> consumption =new List<Consumption>();

        public void AddDay () // Метод позволяющий создать новый день для записи потраченных средтсв
        {
            consumption.Add(new Consumption());
            consumption[consumption.Count-1].Date = DateTime.Now;
            consumption[consumption.Count-1].Amount = 0;

        }


    }

    [Serializable]
    class CategoryManagement
    {
      public  List<Category> category = new List<Category>();
        public void CreateCategory ()
        {
            category.Add(new Category());
            Console.WriteLine("Название категории: ");
            category[category.Count-1].FuncName = Console.ReadLine();
            Console.Clear();
        } // Метод создающий новые категории

        
        public void DeleteCategory ()
        {
            this.PrintCategoryList();
            Console.WriteLine("Удалить категорию под номером: ");
            int choose = int.Parse(Console.ReadLine());
            if (choose > 0 && choose <= category.Count)
            {
                category.RemoveAt(choose - 1);
            }
            Console.Clear();
        } // Метод удалющий категории

        public void AddSpentFunds (double sum) // Метод добавляющий в категории потраченные средтсва
        {
            bool end = true;
            while (end)
            {
                Console.Clear();
                this.PrintCategoryList();
                Console.WriteLine("Добавить в категорию под номером: ");
                int choose = int.Parse(Console.ReadLine());
                if (choose > 0 && choose <= category.Count)
                {
                    DateTime date = DateTime.Now;
                    bool check = true;
                    foreach (var item in category[choose - 1].consumption)
                    {
                        if (item.Date.Day == date.Day && item.Date.Month == date.Month && item.Date.Year == date.Year)
                        {
                            check = false;
                        }

                    }
                    if (check)
                    {
                        category[choose - 1].AddDay();
                    }
                    Console.Clear();
                    Console.WriteLine($"Категория: {category[choose - 1].FuncName} ");
                    category[choose - 1].consumption[category[choose - 1].consumption.Count - 1].Amount += sum;
                    Console.WriteLine(category[choose - 1].consumption[category[choose - 1].consumption.Count - 1].Amount);
                    Sleep(500);
                    Console.Clear();
                    end = false;
                }
                else Console.WriteLine($"Несуществующий номер ! ");


            }
        }

        public void PrintCategoryListWithMoneyAmount(DateTime date1 , DateTime date2) // Метод печатаюищй список категорий с количеством денег 
        {
            Console.Clear();
            int i = 1;
            double sum = 0;
            Console.WriteLine("Категории: ");
            foreach (var item in category)
            {
                sum = 0;


                foreach (var item1 in item.consumption)
                {
                    if (item1.Date.Date>=date1.Date && item1.Date.Date<= date2.Date )
                    {
                        sum+=item1.Amount;
                    }
                }
                Console.WriteLine(i.ToString() + ": " + item.FuncName + " - " + sum);
            }

            Console.WriteLine("Нажмите любую клавишу для выхода");
            Console.ReadLine();
        }

        public void DeleteSpentFunds(double sum) // Метод  удаляющий из категории потраченные средтсва (в случае ошибочного ввода)
        {
            bool end = true;
            while (end)
            {
                Console.Clear();
                this.PrintCategoryList();
                Console.WriteLine("Удалить из категорию под номером: ");
                int choose = int.Parse(Console.ReadLine());
                Console.Clear();
                if (choose > 0 && choose <= category.Count)
                {
                    Console.WriteLine($"Категория: {category[choose - 1].FuncName} ");
                    if (category[choose - 1].consumption[category[choose - 1].consumption.Count - 1].Amount - sum >= 0)
                    {
                        category[choose - 1].consumption[category[choose - 1].consumption.Count - 1].Amount -= sum;
                    }
                    else Console.WriteLine("Отрицательная сумма!!!");
                    Console.WriteLine(category[choose - 1].consumption[category[choose - 1].consumption.Count - 1].Amount);
                    Sleep(1000);

                    Console.Clear();
                    end = false;
                }
                else Console.WriteLine($"Несуществующий номер ! ");
            }
        } 

        private void PrintCategoryList()
        {
            int i = 1;
            Console.WriteLine("Категории: ");
            foreach (var item in category) 
            {
                Console.WriteLine(i.ToString()+": "+ item.FuncName, "\n");
                i++;
            }
        }  // Метод выводящий все существующие категории в пронумерованном порядке 


    }
}
