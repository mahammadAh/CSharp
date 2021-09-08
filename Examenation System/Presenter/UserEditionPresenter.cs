using Examenation_System.Model;
using Examenation_System.Services;
using Examenation_System.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examenation_System.Presenter
{
    class UserEditionPresenter
    {
        private IUserEditionView userEdition;
        private IUserDataRepository userData;
        int index;
        bool checkEdit = true;
        public UserEditionPresenter(IUserEditionView userEdition, IUserDataRepository userData)
        {
            this.userEdition = userEdition;
            this.userData = userData;
            this.userEdition.Save += Save;
        }


        public UserEditionPresenter(IUserEditionView userEdition, IUserDataRepository userData, int index)
        {
            this.userEdition = userEdition;
            this.userData = userData;
            this.index = index;
            this.userEdition.Save += Save;
            this.userEdition.FillUserInformation(userData.GetAllTasks()[index]);
            checkEdit = false;
        }

        public void Save()
        {
            if (checkEdit)
            {
                if (userEdition.Password == userEdition.RepeatPasword)
                {
                    bool check = true;
                    foreach (var item in userData.GetAllTasks())
                    {
                        if (item.Login == userEdition.Login)
                        {
                            check = false;
                        }
                    }

                    if (check)
                    {
                        UserData newUser = new UserData();

                        newUser.Name = userEdition.UserName;
                        newUser.Surname = userEdition.Surname;
                        newUser.Group = userEdition.Group;
                        newUser.Image = userEdition.Image;
                        newUser.Login = userEdition.Login;
                        newUser.Password = userEdition.Password;
                        if (userEdition.Student)
                        {
                            newUser.Status = "Student";
                        }
                        if (userEdition.Teacher)
                        {
                            newUser.Status = "Teacher";
                        }

                        userData.AddUser(newUser);

                    }
                    else
                    {
                        MessageBox.Show("This login exists");

                    }

                }
                else
                {
                    MessageBox.Show("Passwords do not match");

                }
            }



            else
            {

                if (userEdition.Password == userEdition.RepeatPasword)
                {
                    bool check = true;
                    for (int i = 0; i < userData.GetAllTasks().Count; i++)
                    {
                        if (userData.GetAllTasks()[i].Login == userEdition.Login && i != index)
                        {
                            check = false;
                        }
                    }

                    if (check)
                    {
                        UserData user = new UserData();

                        user.Name = userEdition.UserName;
                        user.Surname = userEdition.Surname;
                        user.Group = userEdition.Group;
                        user.Login = userEdition.Login;
                        user.Password = userEdition.Password;
                        user.Image = userEdition.Image;
                        user.Status = userData.GetAllTasks()[index].Status;

                        List<string> markList = new List<string>();

                        foreach (var item in userData.GetAllTasks()[index].MarkList)
                        {
                            markList.Add(item);
                        }

                        user.MarkList = markList;

                        userData.AddUser(user);
                        userData.RemoveUser(index);
                    }
                    else
                    {
                        MessageBox.Show("This login exists");

                    }

                }
                else
                {
                    MessageBox.Show("Passwords do not match");

                }
            }



        }
    }

}