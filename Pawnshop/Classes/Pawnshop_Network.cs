using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pawnshop.Classes
{
    [Serializable]
    public class Pawnshop_Network
    {
        private uint id;
        public uint Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string opening_date;
        public string Opening_date
        {
            get { return opening_date; }
            set { opening_date = value; }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string type;
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private double rating;
        public double Rating
        {
            get { return rating; }
            set { rating = value; }
        }
    }
}
