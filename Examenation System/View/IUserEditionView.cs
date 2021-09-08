using Examenation_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examenation_System.View
{
    interface IUserEditionView
    {

       string UserName { get;  }
        string Surname { get;  }

        string Group { get; }

        string Login { get;  }

        string Password { get;  }

        string RepeatPasword { get; }

        string Image { get;  }

        bool Student { get; }

        bool Teacher { get;  }


        event Action Save;

        void FillUserInformation(UserData myUserData);
        
    }
}
