using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public enum Weekday
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    
    [System.Serializable]
    public class Day
    {
        public int id;
        public Weekday weekday;
        public Class[] classes;
    }
}
