using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pawnshop.Classes
{
    [Serializable]
    public class All__Network
    {
        public string _name;
        private List<Object> list = new List<Object>();
        public All__Network() { }
        public All__Network(string name)
        {
            _name = name;
        }
        public List<Object> List { get { return list; } }
    }
}
