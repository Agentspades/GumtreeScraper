using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using HtmlAgilityPack;
using IO.ClickSend.ClickSend.Api;
using IO.ClickSend.Client;
using IO.ClickSend.ClickSend.Model;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using BitlyAPI;
using Newtonsoft.Json.Linq;
using NLog;

namespace GumTreeScrape
{
    public partial class GUI : Form
    {
        List<Search> searchList = new List<Search>();

        //change the below to suit your application
        readonly string bitlyAccessToken = "CHANGE_ME"; // Bitly.com Access token if you cant find it google how to create one
        readonly string clickSendUser = "CHANGE_ME"; // API username same as clicksend user name found in dashboard
        readonly string clickSendPass = "CHANGE_ME"; // API Key from clicksend dashboard
        readonly string clickSendTo = "CHANGE_ME"; // number to send the message to must be the full number including country code (example: +61)
        readonly string clickSendFrom = "Agentspades"; // this can be anything you want dependant on your country
        readonly string searchUrl = "CHANGE_ME"; // Example link: https://www.gumtree.com.au/s-electronics-computer/gold-coast/
        readonly string trailingUrl = "CHANGE_ME"; // This is the last part of the url
        readonly string DOMClass = "user-ad-collection-new-design__wrapper--row"; // This might change in future 

        Control sentControl;
        Control costControl;
        public GUI()
        {
            InitializeComponent();
            sentControl = sent_TextBox;
            costControl = cost_TextBox;
        }
        
        /**************************************************************************
        Method:     add_Button_Click(object sender, EventArgs e)
        Purpose:    Adds the requested search term to the list if valid and updates the textBox
        Input:      object, EventArgs
        Output:     void
        **************************************************************************/
        private void add_Button_Click(object sender, EventArgs e)
        {
            //get the values from the textBox controls
            string input = search_TextBox.Text;
            int refresh = ValidateInput(refresh_TextBox.Text);
            string radius = GetRadius();
            if(input.Length == 0)
            {
                MessageBox.Show("You have to enter something", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }//end if
            //check if the search term already exists in the list or not
            if(searchList.BinarySearch(new Search { Term = input }, new SearchComparer()) < 0)
            {
                Search search = new Search { Term = input, Refresh = refresh, Radius = radius };
                searchList.Add(search);
                //updates the list of queries in the textBox
                UpdateList();
                return;
            }//end if
            //show message box if the search term already exists
            else
            {
                MessageBox.Show("The Search Term " + input + " already exists", "ERROR", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }//end else
        }//end add_Button_Click method()

        /**************************************************************************
        Method:     UpdateList()
        Purpose:    Updates the data in the TextBox
        Input:      void
        Output:     void
        **************************************************************************/
        public void UpdateList()
        {
            SearchComparer sc = new SearchComparer();
            //sort the List
            searchList.Sort(sc);
            current_TextBox.Text = "Search Query\t   Refresh\t\tRadius";
            current_TextBox.Text += Environment.NewLine;
            current_TextBox.Text += "===========================================";
            current_TextBox.Text += Environment.NewLine;
            //loop through each search term in the List object and add them to the textBox
            foreach(Search search in searchList)
            {
                string radius = search.Radius.Replace("r", "+");
                if(radius.Length == 0)
                {
                    radius = "+0";
                }
                current_TextBox.Text += (search.Term + "\t\t   " + search.Refresh / 60000 + "\t\t" + radius);
                current_TextBox.Text += Environment.NewLine;
            }//end foreach loop
        }//end UpdateList() method

        /**************************************************************************
        Method:     ValidateInput(string input)
        Purpose:    Validates the search term input
        Input:      string
        Output:     int
        **************************************************************************/
        public int ValidateInput(string input)
        {
            Random rnd = new Random();
            int rndNbr = rnd.Next(10000, 20000);
            if (input.All(char.IsDigit) && input.Length > 0)
            {
                int refresh = int.Parse(input) * 60000;
                return refresh + rndNbr;
            }//end if
            //if the value entered is not valid then default to 2 minutes
            else
            {
                return 120000 + rndNbr;
            }//end else
        }//end ValidateInput() method

        /**************************************************************************
        Method:     remove_Button_Click(object sender, EventArgs e)
        Purpose:    Removes a search term from the List if exists
        Input:      object, EventArgs
        Output:     void
        **************************************************************************/
        private void remove_Button_Click(object sender, EventArgs e)
        {
            //get the string from the textBox control
            string deleteStr = search_TextBox.Text;
            //get the index of the item in the List
            int index = searchList.BinarySearch(new Search { Term = deleteStr }, new SearchComparer());
            //checks if thge item index is valid if valid then removes the item from the list
            if(index >= 0)
            {
                searchList.RemoveAt(index);
                UpdateList();
            }//end if
            //show messageBox if the term doesnt exist
            else
            {
                MessageBox.Show("No Search Term Found for " + deleteStr, "ERROR", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }//end else
        }//end remove_Button_Click() method

        /**************************************************************************
        Method:     start_Button_Click(object sender, EventArgs e)
        Purpose:    Creates a new thread for each search term so each term can be run in parallel
        Input:      object, EventArgs
        Output:     void
        **************************************************************************/
        private void start_Button_Click(object sender, EventArgs e)
        {
            //loop through each serach term in the List
            foreach (Search search in searchList)
            {
                //create a new thread
                Thread newThread = new Thread(() => Monitor(search));
                //set as a background thread
                newThread.IsBackground = true;
                //start the new thread
                newThread.Start();
            }
            MessageBox.Show("Started Working", "Started", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }//end start_Button_Click() method

        /**************************************************************************
        Method:     Monitor(Search search)
        Purpose:    Loop that keeps running until application is closed looking for new links at each refresh interval
        Input:      Search
        Output:     void
        **************************************************************************/
        public void Monitor(Search search)
        {
            //declare variables
            string prevLink = "";
            //get the first link
            string currentFirstLink = GetLink(search, "0");
            //infinite loop untill application is ended
            while (true)
            {
                try 
                {
                    //wait before refreshing
                    Thread.Sleep(search.Refresh);
                    //get the next link
                    string newFirst = GetLink(search, "0");
                    //check if the new first listing matches either the current first or the previous first 
                    if (newFirst.Equals(currentFirstLink) || newFirst.Equals(prevLink))
                    {
                        //restart the loop
                        continue;
                    }//end if
                    //proceed to create and send the sms message
                    else
                    {
                        //get the price
                        string price = GetLink(search, "1");
                        //get the shortend link
                        string shortLink = LinkShorten(newFirst);
                        //Check if ther is a shortLink being returned
                        if(shortLink.Length == 0)
                        {
                            //exit the loop if no short link was returned
                            break;
                        }//end inner if
                        //assemble the message
                        string message = "New Listing for \"" + search.Term + "\"\nPrice: "
                          + price + "\n" + shortLink;
                        //send the sms message
                        SendMsg(message);
                        //set the prevLink to the current one
                        prevLink = currentFirstLink;
                        //update the current link with teh new link
                        currentFirstLink = newFirst;
                    }//end else
                }//end try block
                catch(Exception e)
                {
                    //log any errors to the file "errors.log" in the dir of the exe file
                    Logger logger = LogManager.GetLogger("fileLogger");
                    logger.Error(e.StackTrace);
                }//end catch
            }//end while loop
        }//end Monitor() method

        /**************************************************************************
        Method:     GUI_Load(object sender, EventArgs e)
        Purpose:    Sets the default textbox text when the form loads
        Input:      object, EventArgs
        Output:     void
        **************************************************************************/
        private void GUI_Load(object sender, EventArgs e)
        {
            //sets the textbox text to "0"
            sent_TextBox.Text = "0";
            cost_TextBox.Text = "0";
            Radius_ComboBox.SelectedIndex = 0;
        }//end GUI_Load() method

        /**************************************************************************
        Method:     stop_Button_Click(object sender, EventArgs e)
        Purpose:    Stops the application
        Input:      object, EventArgs
        Output:     void
        **************************************************************************/
        private void stop_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }//end stop_Button_Click() method

        /**************************************************************************
        Method:     ReadFile(string path)
        Purpose:    Reads a csv file of saved data
        Input:      string
        Output:     void
        **************************************************************************/
        public void ReadFile(string path)
        {
            try
            {
                //declare variables to store the information in the external file
                string line;
                TextFieldParser parser = new TextFieldParser(path);
                //loop till end of file
                while (!parser.EndOfData)
                {
                    //read the current line
                    line = parser.ReadLine();
                    //splt the string by the delimiter ','
                    string[] split = line.Split(',');
                    searchList.Add(new Search { Term = split[0], Refresh = int.Parse(split[1]), Radius = split[2] });
                }
            }
            catch(IOException e)
            {
                //show a message box incase of an error
                MessageBox.Show("There was an error loading your file.", "ERROR", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                //log the error
                Logger logger = LogManager.GetLogger("fileLogger");
                logger.Error(e.StackTrace);
            }//end catch
        }//end ReadFile() method

        /**************************************************************************
        Method:     SaveFile(string path)
        Purpose:    Saves the current data to the external file specified
        Input:      string
        Output:     void
        **************************************************************************/
        public void SaveFile(string path)
        {
            //declare a new List object to store the items in string form
            List<string> lines = new List<string>();
            foreach(Search search in searchList)
            {
                lines.Add(search.ToString());
            }
            try
            {
                //write the data to the external file
                File.WriteAllLines(path, lines);
            }
            catch (IOException e)
            {
                //show error box in case of errors
                MessageBox.Show("Error: there was an issue saving your file", "ERROR", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                //log the error
                Logger logger = LogManager.GetLogger("fileLogger");
                logger.Error(e.StackTrace);
            }//end catch
        }//end SaveFile() method

        /**************************************************************************
        Method:     openToolStripMenuItem_Click(object sender, EventArgs e)
        Purpose:    Allows the user to open a specific file
        Input:      object, EventArgs
        Output:     void
        **************************************************************************/
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //declare a new openFile dialog window and set defaults
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV File | *.csv";
            dialog.ShowDialog();
            string fileName = dialog.FileName;
            //only read the file if a file is opened
            if(fileName.Length > 0)
            {
                ReadFile(fileName);
                UpdateList();
            }
        }//end openToolStripMenuItem_Click() method

        /**************************************************************************
        Method:     saveToolStripMenuItem_Click(object sender, EventArgs e)
        Purpose:    Allows the user to save to a specific path
        Input:      object, EventArgs
        Output:     void
        **************************************************************************/
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //check if there is data to save
            if (searchList.Count > 0)
            {
                //declare a new saveFile dialog and set defaults
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "CSV file | *.csv";
                dialog.AddExtension = true;
                dialog.DefaultExt = ".csv";
                dialog.ShowDialog();
                string path = dialog.FileName;
                if (path.Length > 0)
                {
                    //save the file
                    SaveFile(path);
                }
            }//end if
            else
            {
                //show a messageBox incase of an error
                MessageBox.Show("There is no data to save", "ERROR", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }//end else
        }//end saveToolStripMenuItem_Click() method

        /**************************************************************************
        Method:     GetRadius()
        Purpose:    Gets the srtring of the radius selected in the comboBox
        Input:      void
        Output:     string
        **************************************************************************/
        private string GetRadius()
        {
            int index = Radius_ComboBox.SelectedIndex;
            switch (index)
            {
                case 0:
                    return "";
                case 1:
                    return "r2";
                case 2:
                    return "r5";
                case 3:
                    return "r10";
                case 4:
                    return "r20";
                case 5:
                    return "r50";
                case 6:
                    return "r100";
                case 7:
                    return "r250";
                case 8:
                    return "r500";
                default:
                    return "";
            }//end switch
        }//end GetRadius() method

        /**************************************************************************
        Method:     GetLink(Search search, string id)
        Purpose:    returns the top link from gumtree.com.au
        Input:      Search, string
        Output:     string
        **************************************************************************/
        private string GetLink(Search search, string id)
        {
            try
            {
                int topCount = 0;
                string firstLink = "";
                //assemble the search link
                string searchLink = searchUrl + search.Term.Replace(" ", "+")
                    + trailingUrl + search.Radius;
                //get the webpage
                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load(searchLink);
                //check if the webpage contains paid listings
                if (doc.DocumentNode.SelectNodes("//span[@class='user-ad-row-new-design__flag-top']") != null)
                {
                    HtmlNode[] topArr = doc.DocumentNode.SelectNodes("//span[@class='user-ad-row-new-design__flag-top']").ToArray();
                    //count paid listings
                    topCount = topArr.Count();
                }//end if
                 //get the nodes for the listings
                HtmlNode[] nodes = doc.DocumentNode.SelectNodes("//div[@class='" + DOMClass + "']//a").ToArray();
                //get the first listing after the paid ones
                firstLink = (nodes[topCount].Attributes["href"].Value.ToString());
                if (id.Equals("0"))
                {
                    return firstLink;
                }
                else if (id.Equals("1"))
                {
                    return GetPrice(topCount, nodes);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("There was an error loading gumtrees page\nCheck your params and try again", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger logger = LogManager.GetLogger("filelogger");
                logger.Trace(e.StackTrace);
            }
            return "";
        }//end GetLink() method

        /**************************************************************************
        Method:     GetPrice(int topCount, HtmlNode[] nodes)
        Purpose:    returns the price from the top link from gumtree.com.au
        Input:      int, HtmlNode[]
        Output:     string
        **************************************************************************/
        private string GetPrice(int topCount, HtmlNode[] nodes)
        {
            string price = "";
            price = nodes[topCount].Attributes["aria-label"].Value.ToString();
            //get the price value from the string
            int start = price.IndexOf("Price: ", 0) + 6;
            int end = price.IndexOf(".", start);
            price = price.Substring(start, end - start);
            return price;
        }//end GetPrice() method

        /**************************************************************************
        Method:     SendMsg(string msg)
        Purpose:    Sends the SMS message
        Input:      string
        Output:     void
        **************************************************************************/
        private void SendMsg(string msg)
        {
            try
            {
                //setup the config for the clicksend API
                var config = new Configuration()
                {
                    Username = clickSendUser,
                    Password = clickSendPass
                };
                //set the config to a smsApi object
                var smsApi = new SMSApi(config);
                //declare an object to hold the message data to be sent
                var smsList = new List<SmsMessage>
            {
                //sms message data
                new SmsMessage(
                    from: clickSendFrom,
                    to: clickSendTo,
                    body: msg,
                    source: "sdk"
                    )
            };//end message List
              //declare and initalize an smsCollection object using the smsList created above
                var smsCollection = new SmsMessageCollection(smsList);
                //send the sms data to the api and get the Json response
                var response = smsApi.SmsSendPost(smsCollection);
                //parse the Json respones
                JObject jResponse = JObject.Parse(response);
                //get the sms status and the cost and number of messages for the API transaction
                string status = jResponse["response_code"].ToString();
                JObject jObj = (JObject)jResponse["data"];
                decimal cost = decimal.Parse(jObj["total_price"].ToString());
                int msgCount = int.Parse(jObj["total_count"].ToString());
                //if message was successful then update the textBox controls otherwise show an error
                if (status.Equals("SUCCESS"))
                {
                    //update the textBox controls from any of the running threads
                    sentControl.BeginInvoke((MethodInvoker)delegate ()
                    {
                        sent_TextBox.Text = (int.Parse(sent_TextBox.Text) + msgCount).ToString();
                    });
                    costControl.BeginInvoke((MethodInvoker)delegate ()
                    {
                        cost_TextBox.Text = (decimal.Parse(cost_TextBox.Text) + cost).ToString();
                    });
                }//end if
                else
                {
                    MessageBox.Show("Text message not sent", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }//end else
            }
            catch(Exception e)
            {
                MessageBox.Show("There was an error when sending the SMS message\nCheck your params and try again", 
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger logger = LogManager.GetLogger("filelogger");
                logger.Trace(e.StackTrace);
            }
        }//end SendMsg() method

        /**************************************************************************
        Method:     LinkShorten(string link)
        Purpose:    returns a Bitly shortened URL
        Input:      string
        Output:     string
        **************************************************************************/
        private string LinkShorten(string link)
        {
            string shortLink = "";
            try
            {
                //hold the full gumtree link
                string longLink = "https://www.gumtree.com.au" + link;

                //shorten the link to reduce character count for messages
                var bitly = new Bitly(bitlyAccessToken);
                var linkResponse = bitly.PostShorten(longLink);
                shortLink = linkResponse.Result.Link;
            }
            catch(Exception e)
            {
                MessageBox.Show("There was error when shortening your URL\nCheck your params and try again.", 
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger logger = LogManager.GetLogger("filelogger");
                logger.Trace(e.StackTrace);
            }
            return shortLink;
        }//end LinkShorten() method
    }//end class
}//end namespace
