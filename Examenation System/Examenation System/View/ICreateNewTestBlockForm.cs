using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examenation_System.View
{
    interface ICreateNewTestBlockForm
    {
        string BLockName { get; }

        event Action Add;
    }
}
