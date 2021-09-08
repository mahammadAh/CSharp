using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Examenation_System.Model
{
   public class UserData
    {
        public string Login { get; set; } = "Login";

        public string Password { get; set; } = "Password";

        public string Name { get; set; } = "Name";

        public string Surname { get; set; } = "Surname";

        public string Image { get; set; } = "Image";

        public string Group { get; set; } = "Group";

        public string Status { get; set; } = "Status";

        public List<string> MarkList { get; set; } = new List<string>();

        

        public override string ToString()
        {
            return $"{Name}  {Surname}  {Status}  {Group}";
        }

        

    }
}
