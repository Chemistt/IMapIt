using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/**
 * This class is mainly to display the results from the array into the combobox for users to choose and return the choosen result.
 * **/
namespace CAAssignment
{
    public class Station
    {
        string[] text = File.ReadAllLines(@"..\..\Original.txt");
        string name, code;
        public string[] Text
        {
            get { return text; }
            set { text = value; }
        }
        public Station() { }
        public Station(string n, string c)
        {
            name = n;
            code = c;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
    }
}