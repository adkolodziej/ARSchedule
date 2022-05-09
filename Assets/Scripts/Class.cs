using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public enum Week
    {
        odd,
        even,
        both
    }
    public enum ClassType
    {
        exercises,
        lecture,
        seminar,
        project
    }

    [System.Serializable]
    public class Class
    {
        public Week week;
        public string subject;
        public ClassType type;
        public string teacher;
        public string group;
        public string startHour;
        public string endHour;
    }
}
