using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy
{
    [Serializable]
    class Secuirty
    {
        
       public string password=null;
       string passwordCheck="0";
        public void SetPassword()
        {
            Console.WriteLine("Введите пароль: ");
            password = Console.ReadLine();
        } // Создание , Изменение пароля

        public bool Autirization ()
        {
            if (password==null)
            {
                return true;
            }
            Console.WriteLine("Введите ваш пароль");
            StringBuilder pass = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }

                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    pass.Remove((pass.Length - 1), 1);
                    Console.Write("\b \b");
                }
                else
                {
                    pass.Append(keyInfo.KeyChar);
                    Console.Write('*');
                }
            }
            passwordCheck = pass.ToString();

            if (passwordCheck == password)
            {
                return true;
            }
            else return false;
        } // Авторизация в системе

        public void DeletePassword()
        {
            password = null;
        } // Удаление пароля
    }
}
