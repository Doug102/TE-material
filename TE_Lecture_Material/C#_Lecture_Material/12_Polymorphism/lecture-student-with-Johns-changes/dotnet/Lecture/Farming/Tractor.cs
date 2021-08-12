using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    class Tractor :IMakeSound
    {
        public string Name { get; } = "Tractor";
        public string Sound { get; } = "Vroom";

        public int GetAge()
        {
            return 12;
        }
    }
}
