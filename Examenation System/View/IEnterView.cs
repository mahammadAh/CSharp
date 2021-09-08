using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examenation_System.View
{
    interface IEnterView
    {
         string Login { get;  }
        string Password { get; }

        event Action Enter;
    }
}
