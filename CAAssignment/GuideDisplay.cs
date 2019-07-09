using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CAAssignment
{
    public partial class GuideDisplay : Form
    {
        private dbGuide db = new dbGuide();
        private Guide g = new Guide();
        private Path<Station>[] result;
        public string Message;

        // Initialize
        public GuideDisplay()
        {
            InitializeComponent();
            timer1.Interval = 1;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            foreach (string station in g.DisplayAllArray().Distinct().OrderBy(s => s))      // Add Stations to combo, Remove Duplicates via .Distinct & Sorting IEnumerable via .OrderBy
            {
                BoardStationbox.Items.Add(station);
                DestStationbox.Items.Add(station);
            }//end foreach
        }   //EndOfGuideDisplay

        // Clear
        private void ClearButton_Click(object sender, EventArgs e)                          
        {
            // Clear Everything
            BoardStationbox.Items.Clear();
            DestStationbox.Items.Clear();
            MessageBox.Clear();

            // Re-add Stations to combo
            foreach (string station in g.DisplayAllArray().Distinct().OrderBy(s => s))
            {
                BoardStationbox.Items.Add(station);
                DestStationbox.Items.Add(station);
            }//end foreach
        }   //EndOfClearButton_Click

        // Send it button Click
        private void SenditButton_Click(object sender, EventArgs e)
        {
            
            MessageBox.Clear();     // Clear Messagebox everytime user press button
            Message = "";


            if (BoardStationbox.Text.Equals(DestStationbox.Text))   // Validation for Same Station
            {
                MessageBox.Text = string.Format("You selected the same Station!");
            }
            else if (BoardStationbox.Text.Equals("") || DestStationbox.Text.Equals("")) // Validation for Empty String
            {
                MessageBox.Text = string.Format("Please select a station!");
            }
            else
            {
                string newLine = "\r\n\r\n";
                int count = 0;
                result = g.SearchForPath(BoardStationbox.Text, DestStationbox.Text, 2); // Returns List of Stations

                foreach (Path<Station> pt in result)    // Print Results
                {
                    if (count.Equals(0))
                    {
                        Message += "Full Route: " + newLine;
                        Message += g.PrintFullResult(pt) + newLine;
                        Message += "Number of Stops: " + (pt.Weight - 1) + newLine + newLine;
                        count++;
                    }
                    else
                    {
                        Message += "Alternative Route: " + newLine;
                        Message += g.PrintFullResult(pt) + newLine;
                        Message += "Number of Stops: " + (pt.Weight - 1) + newLine;
                    }
                }//end foreach
                Fare[] totalfare = db.GetFare(g.getStnCode(BoardStationbox.Text), g.getStnCode(DestStationbox.Text));
                if (totalfare[0] == null) // If data not found in database, will return null
                {
                    Message += "Fare cannot be generated due to lack of data.";
                }
                else
                {
                    Message += "Child Fare: " + totalfare[0].getChildFare() + "\r\n";
                    Message += "Adult Fare: " + totalfare[0].getStandardFare() + newLine;
                    Message += "Estimated Time Needed to your destination: " + totalfare[0].getTotalTime() + "mins";
                }
                Result r1 = new Result(Message);    
                r1.ShowDialog(); //Open Result WinForm
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Map map = new Map();
            map.ShowDialog();
        }

        private void GuideDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                db.CloseConn();
            }
            catch (Exception)
            {
                Console.WriteLine("Connection already closed.");
                Console.ReadKey();
            }
            ExitPopup Exit = new ExitPopup();
            Exit.ShowDialog();
            
        }

        private void BoardStationbox_SelectedIndexChanged(object sender, EventArgs e) { }
        private void DestStationbox_SelectedIndexChanged(object sender, EventArgs e) { }
        private void PictureBox1_Click(object sender, EventArgs e) { }
        private void Title_Click(object sender, EventArgs e) { }
        private void BoardLabel_Click(object sender, EventArgs e) { }
        private void DestLabel_Click(object sender, EventArgs e) { }
        private void TextBox1_TextChanged(object sender, EventArgs e) { }
        private void GuideDisplay_Load(object sender, EventArgs e) { }
        private void GoingToLabel_Click(object sender, EventArgs e) { }
    }
}

