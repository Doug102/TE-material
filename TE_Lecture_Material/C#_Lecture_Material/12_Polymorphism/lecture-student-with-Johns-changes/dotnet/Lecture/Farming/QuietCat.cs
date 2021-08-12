using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    class QuietCat : IMakeSound
    {
        public string Name { get; } = "Quiet Cat";
        public string Sound { get; } = "";

        public int GetAge()
        {
            return 1;
        }
    }
}
