using Examenation_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examenation_System.Services
{
    interface IUserDataRepository
    {
        List<UserData> GetAllTasks();

        void AddUser(UserData user);

        void RemoveUser(int index);

        void Write(List<UserData> userList);

        void AddMarkInList(string examResult, int userIndex);
    }
}
