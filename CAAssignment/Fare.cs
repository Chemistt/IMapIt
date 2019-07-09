using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAssignment
{
    public class Fare
    {
        private string stationToStationCode;  //variable storing station to station 
        private string childFare;  //variable storing fare for ezlink
        private string StandardFare;  //variable storing fare for standard pass
        private string totalTime;  //variable storing total time

        public Fare() { }  //default constructor

        public Fare(string sToSCode, string ChildFare, string sFare, string tTime)
        {
            stationToStationCode = sToSCode;  //variable storing station to station string
            childFare = ChildFare;  //variable storing fare for ezlink
            StandardFare = sFare;  //variable storing fare for standard pass
            totalTime = tTime;  //variable storing travel time
        }

        public string getStationToStationCode()  //getter for StationToStationCode
        {
            return stationToStationCode;
        }

        public string getChildFare()  //getter for EZlink fare
        {
            return childFare;
        }

        public string getStandardFare()  //getter for Standard fare
        {
            return StandardFare;
        }

        public string getTotalTime()  //getter for total time
        {
            return totalTime;
        }
    }
}
