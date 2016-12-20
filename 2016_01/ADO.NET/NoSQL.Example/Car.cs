using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSQL.Example
{
    public class Car
    {
        public enum CarColor
        {
            Red,
            Blue,
            Black,
            Silver
        }


        public CarColor Color { get; set; }

        public int HP { get; set; }

        public string Name { get; set; }

        public int VMax { get; set; }

        public float? RimSize { get; set; }

        public override string ToString()
        {
            return $"{Name} PS:{HP} TopSpeed:{VMax} Color:{Color}";
        }


    }
}
