using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pawnshop.Classes
{
    [Serializable]
    public class Owner
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string surname;
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        private uint age;
        public uint Age
        {
            get { return age; }
            set { age = value; }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string number_phone;
        public string Number_phone
        {
            get { return number_phone; }
            set { number_phone = value; }
        }
    }
}
