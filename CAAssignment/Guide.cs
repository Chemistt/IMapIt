using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/**
 * This class is logic for the line transfers, including no of stops and getter for element index in the array and station code E.G NS3, CC6, DT9
 */
namespace CAAssignment
{
    public class Guide
    {
        private Station s = new Station();
        private Line l = new Line();
        private dbGuide db = new dbGuide();
        private ArrayList aryPath;
        private Graph<Station> graph;

        public Guide()
        {
            ObjCreation();
            InitAllStation();
        }
        public List<string> getStnCodesOnlyList(string input)   //Get a list of Lines
        {
            List<string> codeList = new List<string>();
            foreach (Station element in l.AllStationList)
            {
                if (element.Name.Equals(input))
                {
                    codeList.Add(element.Code.Substring(0, 2));
                }
            }
            return codeList;
        }
        public int getIndex(string input, string inputcode)     //Get station index
        {
            string index = "";
            foreach (Station element in l.AllStationList)
            {
                if (element.Name.Equals(input) && (element.Code.Substring(0, 2).Equals(inputcode)))
                {
                    index = element.Code.Substring(2);
                }
            }
            return Convert.ToInt32(index);
        }
        public string getStnCode(string input)                  //Get station code
        {
            foreach (Station element in l.AllStationList)
            {
                if (element.Name == input)
                {
                    return element.Code;
                }
            }
            return null;
        }
        public string[] DisplayAllArray()                       //Display All Stations direct from textfile
        {
            string station = "";
            int count = 0;
            for (int i = 0; i < s.Text.Length; i++)
            {
                if (s.Text[i].Equals("(end)") || s.Text[i].Equals("(start)"))
                {
                    continue;
                }
                else
                {
                    if (count == 0)
                    {
                        station += s.Text[i + 1];
                        i++;
                        count++;
                    }
                    else
                    {
                        station += "\n" + s.Text[i + 1];
                        i++;
                    }
                }
            }
            string[] StationDisplayArray = station.Split('\n');
            return StationDisplayArray;
        }
        public void ObjCreation()                               //Create Station Objects
        {
            List<Station> AllStationList = new List<Station>();

            AllStationList = db.ObjCreation();  //Read from database

            // Getting DistinctLine
            List<string> AllLine = new List<string>();
            foreach (var element in AllStationList)
            {
                AllLine.Add(element.Code.Substring(0, 2));
            }
            var DistinctLine = AllLine.Distinct().ToList();
            //Should create DistinctLine.Count() amount of list
            var ListofUniqueLines = new List<Line>();
            for (int i = 0; i < DistinctLine.Count(); i++)    //Loop adding of station
            {
                var UniqueLine = new List<Station>();
                for (int j = 0; j < AllStationList.Count(); j++)    //Adding of station
                {
                    if (DistinctLine[i].Equals(AllStationList[j].Code.Substring(0, 2)))
                    {
                        UniqueLine.Add(AllStationList[j]);
                    }
                }

                ListofUniqueLines.Add(new Line(DistinctLine[i], UniqueLine));   // List of List of Station Objects

            }

            l.AllStationList = AllStationList;
            l.ListOfListStations = ListofUniqueLines;
        }
        public void InitAllStation()
        {
            graph = new Graph<Station>();
            for (int i = 0; i < l.AllStationList.Count(); i++)
            {
                Node<Station> node = new Node<Station>(l.AllStationList[i].Name, l.AllStationList[i]);
                graph.AddNode(node);
            }
            foreach (var line in l.ListOfListStations)
            {
                for (int i = 0; i < line.ListofStations.Count() - 1; i++)
                {
                    graph.AddUndirectedEdge(line.ListofStations[i].Name, line.ListofStations[i + 1].Name);
                }
            }
        }
        public Path<Station>[] SearchForPath(string BoardStationID, string DestStationID, int numOfPathsToReturn)
        {
            //Return null if the start and end station are the same
            if (BoardStationID == DestStationID)
            {
                return null;
            }

            //Execute Search
            DepthFirstSearch(BoardStationID, DestStationID);

            //Return Path Arry
            Path<Station>[] returnPath;

            //If the number of possible Paths is less than the number of paths to return
            if (aryPath.Count < numOfPathsToReturn)
            {
                //Return the number of paths of found
                return aryPath.ToArray(typeof(Path<Station>)) as Path<Station>[];
            }
            else
            { //Number of paths found more than paths to return

                //Initialize Path array to the number of paths to return
                returnPath = new Path<Station>[numOfPathsToReturn];

                for (int i = 0; i < numOfPathsToReturn; i++)
                {
                    returnPath[i] = aryPath[i] as Path<Station>;
                }
            }
            return returnPath;
        }
        private void DepthFirstSearch(string startNodeID, string endNodeID)
        {
            //Initialize Arraylist to store all results
            aryPath = new ArrayList();

            //Initialize Path variable to store the path
            Path<Station> currPath = new Path<Station>();

            //Execute DFS
            var Node = graph.GetNodeByID(startNodeID);
            DepthFirst2(Node, endNodeID, currPath);

            //Sort the Paths in List based on weight variable
            aryPath.Sort();

        }//end DepthFirstSearch
        private void DepthFirst2(Node<Station> currNode, string endNodeID, Path<Station> visited)
        {
            //Add Current node to Path
            visited.Add(currNode);

            //Get All the neighbouring nodes of the Current Node
            NodeList<Station> neighbour = currNode.Neighbour;

            //Iterate through all the neighbours
            foreach (Node<Station> nextNode in neighbour)
            {

                //Continue if Node is already on list
                if (visited.Contains(nextNode))
                {
                    continue;
                }

                //Neighbour node found to be destination node
                if (nextNode.ID == endNodeID)
                {

                    //Add Node to Path
                    visited.Add(nextNode);

                    //Save Path to a List
                    aryPath.Add(new Path<Station>(visited.PathList));

                    //Remove Destination Node From Path
                    visited.RemoveLast();

                    //Break out of for-each
                    continue;
                }

                //Recursion of DFS with NextNode as current Node
                DepthFirst2(nextNode, endNodeID, visited);

                //Remove last visited node
                visited.RemoveLast();

            }//end foreach


        }//end DepthFirst2
        public string PrintFullResult(Path<Station> result)
        {
            string returnResult = "";
            const string marker = " > ";

            for (int i = 0; i < result.PathList.Count - 1; i++)
            {
                returnResult += result.PathList[i].ID.ToString() + marker;
            }
            return returnResult + result.PathList.GetLast().ID.ToString();
        }
    }
}