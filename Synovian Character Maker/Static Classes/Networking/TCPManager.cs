using System;
using System.Text;
using System.Text.Json;
using System.Net;
using System.Net.Sockets;
using Synovian_Character_Maker.DataClasses.Static;
using Synovian_Character_Maker.DataClasses.Instanced;
using Synovian_Character_Maker.Forms.Experimental;

namespace Synovian_Character_Maker.Static_Classes.Networking.TCP
{
    public class TCPManager
    {
        public TCPManager(bool useLAN = false, bool askForIP = false)
        {
            if (IP == "" && askForIP)
            {
                IPRequest iPRequest = new IPRequest();
                iPRequest.ShowDialog();
                hostname = iPRequest.IP;
            }
            else if (IP == "" && useLAN && !askForIP)
            {
                hostname = GetLocalIPAddress();
            }
            else
            {
                hostname = IP;
            }
        }

        ~TCPManager()
        {

        }

        public bool SendSheet(CharacterSheet sheet)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(hostname, port);
                NetworkStream ns = client.GetStream();

                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };

                SheetSubmission sheetSubmission = new SheetSubmission();
                sheetSubmission.ShowDialog();

                string author = sheetSubmission.authorName;
                bool overrideSub = sheetSubmission.overrideSubmission;

                SubmissionDetails submissionDetails = new SubmissionDetails(author, DateTime.Now.ToString(), overrideSub);
                TCP_DataPack tCP_DataPack = new TCP_DataPack(sheet,submissionDetails);

                string jsonString = JsonSerializer.Serialize(tCP_DataPack);
                byte[] bytes = Encoding.ASCII.GetBytes(jsonString);

                ns.Write(bytes, 0, bytes.Length);
                ns.Close();
                client.Close();
                return true;
            }
            catch(Exception e)
            {
                ExceptionHandles.ExceptionHandle(e);
                return false;
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            ExceptionHandles.ExceptionHandle(new Exception("TCP : EXCEPTION : No network adapters with an IPv4 address in the system!"));
            return "";
        }

        private const string IP = "";
        private string hostname = "";
        private const int port = 13;
        //private bool LAN = false;
    }

    public struct TCP_DataPack
    {
        public CharacterSheet characterSheet { get; set; }
        public SubmissionDetails submissionDetails { get; set; }

        public TCP_DataPack(CharacterSheet _characterSheet, SubmissionDetails _submissionDetails)
        {
            characterSheet = _characterSheet;
            submissionDetails = _submissionDetails;
        }
    }

    public struct SubmissionDetails
    {
        public string Author { get; set; }
        public string Date { get; set; }
        public bool OverrideSubmission { get; set; }

        public SubmissionDetails(string author, string date, bool override_sub)
        {
            Author = author;
            Date = date;
            OverrideSubmission = override_sub;
        }

        public SubmissionDetails(string author, bool override_sub)
        {
            Author = author;
            Date = DateTime.Now.ToString();
            OverrideSubmission = override_sub;
        }
    }
}
