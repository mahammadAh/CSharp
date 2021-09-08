using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
//using System.Text.Json;
using Json.Net;

namespace Monefy
{
    class SaveInFile
    {
       
        public void WriteToFile (string fileName, Secuirty sec)
        {
           
            File.WriteAllText(fileName, JsonConvert.SerializeObject(sec));
        }

        public void WriteToFile(string fileName, AccountManagement accMan)
        {
           
            File.WriteAllText(fileName, JsonConvert.SerializeObject(accMan));
        }


        public void WriteToFile(string fileName, CategoryManagement catMan)
        {
          
            File.WriteAllText(fileName, JsonConvert.SerializeObject(catMan));
        }




        public Secuirty ReadFromFile (string fileName, Secuirty sec)
        {
            string str = File.ReadAllText(fileName);
            var secuirty = JsonConvert.DeserializeObject<Secuirty>(str);
            return secuirty;
        }

        public  AccountManagement ReadFromFile(string fileName, AccountManagement accMng)
        {
            string str = File.ReadAllText(fileName);
            var accountManagement = JsonConvert.DeserializeObject<AccountManagement>(str);
            return accountManagement;
        }

        public  CategoryManagement ReadFromFile(string fileName, CategoryManagement catMan)
        {
            string str = File.ReadAllText(fileName);
            var categoryManagement = JsonConvert.DeserializeObject<CategoryManagement>(str);
            return categoryManagement;
        }
    }
}
