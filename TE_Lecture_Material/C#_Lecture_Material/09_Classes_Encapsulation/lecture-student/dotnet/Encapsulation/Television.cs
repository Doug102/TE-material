using System;
using System.Collections.Generic;
using System.Text;

namespace Encapsulation.Classes
{
    public class Television
    {

        //public int serialNumber = 0;
        private int numberOfReportedFire = 0;
        public List<string> availablePowerConnectors =
            new List<string> {"US", "GB", "EU", "JP"};

        // short form property
        public int SerialNumber 
        {
            get;
            set;
        }

        public bool IsULListed
        {
            get;
        }

        // long form property
        private int volume = 0;
        
        public int Volume
        {
            get
            {
                return volume;
            }

            set
            {
                if (value > 10)
                {
                    value = 10;
                }
                else if (value < 0)
                {
                    value = 0;
                }
                volume = value;
            }
        }

        public int Channel { get; set; }


        public bool SetVolumeAndChannel(int volume, int channel)
        {
            bool result = false;

            Volume = volume;
            Channel = channel;

            result = true;
            return result;
        }

        // default constructor
        public Television()
        {
         
        }


    }
}
