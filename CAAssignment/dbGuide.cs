using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace CAAssignment
{
    public class dbGuide
    {
        string[] faretxt = File.ReadAllLines(@"..\..\fares.txt");
        string[] mrttxt = File.ReadAllLines(@"..\..\Original.txt");
        Fare Fare = new Fare();
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-BMS568Q4\SQLEXPRESS;" + "Database=dbFares;" + "Integrated Security=true");
        SqlCommand cmd = new SqlCommand();
        public dbGuide()
        {
            OpenConn();
            cmd.Connection = conn;
            CreateTable();
        }
        public void OpenConn()
        {
            conn.Open();
        }
        public void CloseConn()
        {
            conn.Close();
        }
        public void CreateTable()
        {
            try
            {
                cmd.CommandText = "SELECT * from FARES";
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                cmd.CommandText = "CREATE TABLE FARES (StationToStation VARCHAR(100) not null, ChildFare VARCHAR(10) not null, AdultFare VARCHAR(10) not null, Time VARCHAR(10) not null, Primary key(StationToStation))";
                cmd.ExecuteNonQuery();
                for (int i = 0; i < faretxt.Length; i += 4)
                {
                    if ((faretxt[i].Substring(0, 2) == "CC") ||  //checking for non-existing lines and empty spaces in text file
                       (faretxt[i].Substring(0, 2) == "NE") ||
                       (faretxt[i].Substring(0, 2) == "NS") ||
                       (faretxt[i].Substring(0, 2) == "DT") ||
                       (faretxt[i].Substring(0, 2) == "CG") ||
                       (faretxt[i].Substring(0, 2) == "EW"))
                    {
                        cmd.CommandText = "INSERT INTO FARES (StationToStation, ChildFare, AdultFare, Time)" + "Values ('" + faretxt[i] + "','" + faretxt[i + 1] + "','" + faretxt[i + 2] + "', '" + faretxt[i + 3] + "')";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            try
            {
                cmd.CommandText = "SELECT * from MRT";
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                cmd.CommandText = "CREATE TABLE MRT (Code VARCHAR(10) not null, Name VARCHAR(100) not null)";
                cmd.ExecuteNonQuery();
                for (int i = 0; i < mrttxt.Length;)
                {
                    if (mrttxt[i].Equals("(end)") || mrttxt[i].Equals("(start)"))
                    {
                        i++;
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO MRT (Code,Name)" + "Values ('" + mrttxt[i] + "','" + mrttxt[i + 1] + "')";
                        cmd.ExecuteNonQuery();
                        i += 2;
                    }
                }
            }

        }

        public Fare[] GetFare(string BoardCode, string DestCode)
        {
            Fare[] returnarray = new Fare[1]; // return that cotains the stationtostation,ezlinkfare,standardfare and totaltime from database

            int check1 = calculatearraysize("SELECT COUNT(*) from FARES" + " where StationToStation like ('%" + BoardCode
                + "') and StationToStation like ('%" + DestCode + "%')");  //checking if StationToStationCode starts with boarding station code

            int check2 = calculatearraysize("SELECT COUNT(*) from FARES" + " where StationToStation like ('%" + DestCode
                + "') and StationToStation like ('%" + BoardCode + "%')");  //checking if StationToStationCode starts with destination station code

            int check3 = calculatearraysize("SELECT COUNT(*) from FARES" + " where StationToStation like ('%" + BoardCode
                + "') and StationToStation like ('%" + DestCode + "%') and StationToStation like ('" + DestCode + "/%')");


            int check4 = calculatearraysize("SELECT COUNT(*) from FARES" + " where StationToStation like ('%" + DestCode
                + "') and StationToStation like ('%" + BoardCode + "%') and StationToStation like ('" + BoardCode + "/%')");


            if (check1 == 1)
            {
                SqlCommand fareprice = new SqlCommand("SELECT StationToStation, ChildFare, AdultFare, Time from FARES" + " where StationToStation like ('%" + BoardCode
                + "') and StationToStation like ('" + DestCode + "%')", conn);
                SqlDataReader fareReader = fareprice.ExecuteReader();
                try
                {
                    while (fareReader.Read())
                    {
                        returnarray[0] = new Fare(Convert.ToString(fareReader[0]), Convert.ToString(fareReader[1]), Convert.ToString(fareReader[2]), Convert.ToString(fareReader[3])); //setting the array with data by using datareader
                    }
                }
                catch (Exception) { }
                fareReader.Close();
            }
            else if (check2 == 1)
            {
                SqlCommand fareprice = new SqlCommand("SELECT StationToStation, ChildFare, AdultFare, Time from FARES" + " where StationToStation like ('%" + BoardCode
                + "') and StationToStation like ('%" + DestCode + "%')", conn);
                SqlDataReader fareReader = fareprice.ExecuteReader(); // using datareader to pass data to array
                try
                {
                    while (fareReader.Read())
                    {
                        returnarray[0] = new Fare(Convert.ToString(fareReader[0]), Convert.ToString(fareReader[1]), Convert.ToString(fareReader[2]), Convert.ToString(fareReader[3])); //setting the array with data by using datareader
                    }
                }
                catch (Exception) { }
                fareReader.Close();
            }
            else if (check3 == 1)
            {
                SqlCommand fareprice = new SqlCommand("SELECT StationToStation, ChildFare, AdultFare, Time from FARES" + " where StationToStation like ('%" + BoardCode
                + "') and StationToStation like ('" + DestCode + "%') and StationToStation like ('" + DestCode + "/%')", conn);
                SqlDataReader fareReader = fareprice.ExecuteReader(); // using datareader to pass data to array
                try
                {
                    while (fareReader.Read())
                    {
                        returnarray[0] = new Fare(Convert.ToString(fareReader[0]), Convert.ToString(fareReader[1]), Convert.ToString(fareReader[2]), Convert.ToString(fareReader[3])); //setting the array with data by using datareader
                    }
                }
                catch (Exception) { }
                fareReader.Close(); // closing datareader connection
            }
            else if (check4 == 1)
            {
                SqlCommand fareprice = new SqlCommand("SELECT StationToStation, ChildFare, AdultFare, Time from FARES" + " where StationToStation like ('%" + DestCode
                + "') and StationToStation like ('" + BoardCode + "%') and StationToStation like ('" + BoardCode + "/%')", conn);
                SqlDataReader fareReader = fareprice.ExecuteReader(); // using datareader to pass data to array
                try
                {
                    while (fareReader.Read())
                    {
                        returnarray[0] = new Fare(Convert.ToString(fareReader[0]), Convert.ToString(fareReader[1]), Convert.ToString(fareReader[2]), Convert.ToString(fareReader[3])); //setting the array with data by using datareader
                    }
                }
                catch (Exception) { }
                fareReader.Close(); // closing datareader connection
            }
            return returnarray;
        }
        public int calculatearraysize(string query)
        {
            SqlCommand counter = new SqlCommand(query, conn);
            SqlDataReader counterReader = counter.ExecuteReader();
            int count = 0;
            while (counterReader.Read())
            {
                count = Convert.ToInt16(counterReader[0]);
            }
            counterReader.Close();
            return count;
        }
        public List<Station> ObjCreation()
        {
            string sql = "SELECT Code, Name from MRT";
            SqlCommand StationInfo = new SqlCommand(sql , conn);
            SqlDataReader stnReader = StationInfo.ExecuteReader();
            List<Station> readArr = new List<Station>();
            try
            {
                int i = 0;
                while (stnReader.Read())
                {
                    readArr.Add(new Station(Convert.ToString(stnReader[i + 1]), Convert.ToString(stnReader[i])));
                }
            }
            catch (Exception) { }
            stnReader.Close();
            return readArr;
        }

    }
}
