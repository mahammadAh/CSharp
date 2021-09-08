using Examenation_System.Model;
using Examenation_System.Services;
using Examenation_System.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Examenation_System.Presenter
{
    class EnterPresenter
    {
       private IEnterView enter;
        private IUserDataRepository userData;
      
        
        public EnterPresenter(IEnterView enter ,IUserDataRepository userData)
        {
            this.enter = enter;
            this.userData = userData;
         
            enter.Enter += Enter;
        }

        public void Enter ()
        {
           
            for (int i=0; i< userData.GetAllTasks().Count; i++)
            {
                if (userData.GetAllTasks()[i].Login==enter.Login && userData.GetAllTasks()[i].Password==enter.Password)
                {
                    switch (userData.GetAllTasks()[i].Status)
                    {
                        case "Administrator":
                            Program.EnterAdministration(userData.GetAllTasks()[i]);
                            
                            break;
                        case "Teacher":
                            Program.EnterTeacher(userData.GetAllTasks()[i]);

                            break;
                        case "Student":
                            Program.EnterStudent(userData.GetAllTasks()[i]);
                            
                            break;
                    }

                }
            }
        }
    }
}
