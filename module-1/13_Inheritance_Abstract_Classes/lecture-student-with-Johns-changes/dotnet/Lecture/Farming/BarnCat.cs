using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    class BarnCat :Cat
    {
        public bool IsABitWild { get; } = true;

        public override string Name { get; } = "Barn Cat";
    }
}
