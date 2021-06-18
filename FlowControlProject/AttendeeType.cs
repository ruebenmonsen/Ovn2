using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowControlProject
{
    class AttendeeType
    {
        private int price;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public AttendeeType(string description, int price)
        {
            this.description = description;
            this.price = price;
        }
    }
}
