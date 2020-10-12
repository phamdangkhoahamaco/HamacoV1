using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HAMACO.Resources
{
    class clsItem
    {
         private string pstrValue = "";
        private string pstrName = "";

        public clsItem()
        {
            
        }

        public clsItem(string Value, string Name)
        {
            pstrValue = Value;
            pstrName = Name;
        }

        public string PstrValue
        {
            get { return pstrValue; }
            set { pstrValue = value; }
        }

        public string PstrName
        {
            get { return pstrName; }
            set { pstrName = value; }
        }
    }
}
