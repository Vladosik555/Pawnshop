using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pawnshop.Classes
{
    [Serializable]
    internal class Goods
    {
        private string jewelry;
        public string Jewelry
        {
            get { return jewelry; }
            set { jewelry = value; }
        }
        private string appliances;
        public string Appliances
        {
            get { return appliances; }
            set { appliances = value; }
        }
        private string antiques;
        public string Antiques
        {
            get { return antiques; }
            set { antiques = value; }
        }
        private string fur;
        public string Fur
        {
            get { return fur; }
            set { fur = value; }
        }
        private string car;
        public string Car
        {
            get { return car; }
            set { car = value; }
        }
    }
}
