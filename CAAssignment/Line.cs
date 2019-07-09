using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * This class is mainly for getters and setters and common variables
 * **/
namespace CAAssignment
{
    class Line
    {
        public Line() { }
        List<Station> listOfStations = new List<Station>();
        List<Station> allStationList = new List<Station>();
        List<Line> listOfListStations = new List<Line>();
        string lineCode;
        public Line(string c, List<Station> s)
        {
            listOfStations = s;
            lineCode = c;
        }
        public string LineCode
        {
            get { return lineCode; }
            set { lineCode = value; }
        }
        public List<Station> ListofStations
        {
            get { return listOfStations; }
            set { listOfStations = value; }
        }
        public List<Station> AllStationList
        {
            get { return allStationList; }
            set { allStationList = value; }
        }
        public List<Line> ListOfListStations
        {
            get { return listOfListStations; }
            set { listOfListStations = value; }
        }
    }
}
