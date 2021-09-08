using Examenation_System.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examenation_System.Services
{
    class UserDataJsonRepository : IUserDataRepository
    {

       

        public void AddUser(UserData user)
        {
            var userList = Read();
            userList.Add(user);
            Write(userList);
        }

        public void RemoveUser(int index)
        {
            var userList = Read();
            userList.RemoveAt(index);
            Write(userList);
        }

        public List<UserData> GetAllTasks()
        {
            return Read();
        }


        public void AddMarkInList(string examResult, int userIndex)
        {
            var userList = Read();
            userList[userIndex].MarkList.Add(examResult);
            Write(userList);
        }
        private List<UserData> Read()
        {
            if (File.Exists("UserData.json"))
            {
                return JsonConvert.DeserializeObject<List<UserData>>(File.ReadAllText("UserData.json"));
            }
            return new List<UserData>();
        }

        public void Write(List<UserData> userList)
        {
            File.WriteAllText("UserData.json", JsonConvert.SerializeObject(userList));
        }

        
    }
}
