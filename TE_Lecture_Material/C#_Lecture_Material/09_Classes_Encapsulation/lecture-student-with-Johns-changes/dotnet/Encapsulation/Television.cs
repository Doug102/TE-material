using System;
using System.Collections.Generic;
using System.Text;

namespace Encapsulation
{
    public class Television
    {
        //public int serialNumber = -0;
        private int numberOfReportedFires = 0;

        public List<string> availablePowerConnectors = 
            new List<string>  {"US", "GB", "EU", "JP"};
   
        //short-form property
        public int SerialNumber
        {
            get;
            set;
        }

        public bool IsULListed
        {
            get;
        }


        //long-form property
        private int volume = 0;

        public int Volume
        {
            get
            {
                return volume;
            }

            set
            {
                volume = value;
            }
        }

    }
}
