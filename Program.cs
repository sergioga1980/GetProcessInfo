using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Eventing;
using Microsoft.Windows.EventTracing;
using Microsoft.Windows.EventTracing.Processes;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Process");
            ManagementObjectCollection collection = searcher.Get();

            string path = string.Empty;
            string name = string.Empty;
            string pid = string.Empty;
            string parent_id = string.Empty;
            string processname = String.Empty;
            string userSID = String.Empty;
            string cmdLine = String.Empty;
            string osName = String.Empty;
            string creationDate = String.Empty;
            string csName = String.Empty;
            string caption = String.Empty;
            string handle = String.Empty;
            string hash = String.Empty;


            foreach (ManagementObject item in collection)
                        {
                            ProcessInfo processInfoNew = new ProcessInfo();
                            string[] outParameters = new String[2];
                            try
                            {
                                pid = Convert.ToString(item["ProcessId"]);
                                parent_id = Convert.ToString(item["ParentProcessId"]);               
                                path = Convert.ToString(item["ExecutablePath"]);
                                name = Convert.ToString(item["Name"]);
                                item.InvokeMethod("GetOwnerSid", (object[])outParameters);
                                userSID = (string)outParameters[0];
                                cmdLine = Convert.ToString(item["CommandLine"]);
                                osName = Convert.ToString(item["OSName"]);
                                creationDate = Convert.ToString(item["CreationDate"]);
                                csName = Convert.ToString(item["CSName"]);
                                caption = Convert.ToString(item["Caption"]);
                                handle = Convert.ToString(item["Handle"]);
                }
                            catch (Exception ex)
                            { }

                using (var sha = new System.Security.Cryptography.SHA256Managed())
                {
                    byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(csName + "");
                    byte[] hashBytes = sha.ComputeHash(textBytes);

                    // Convert back to a string, removing the '-' that BitConverter adds
                     hash = BitConverter
                        .ToString(hashBytes)
                        .Replace("-", String.Empty);

                 
                    }

                    processInfoNew.PID = pid;
                            processInfoNew.ParentId = parent_id;
                            processInfoNew.OSName = osName;
                            processInfoNew.Name = name;
                            processInfoNew.Path = path;
                            processInfoNew.UserSID = userSID;
                            processInfoNew.CreationDate = creationDate;
                            processInfoNew.CmdLine = cmdLine;
                            processInfoNew.CsName = hash;
                            processInfoNew.Caption = caption;
                            processInfoNew.Handle = handle;


                string jsonString = JsonSerializer.Serialize(processInfoNew);

                            string pathToStore = @"c:\Desarrollo\test.json";

                            using (var tw = new StreamWriter(pathToStore, true))
                            {
                                tw.WriteLine(jsonString.ToString());
                                tw.Close();
                            }

                        }

            // EventLogSession session = new EventLogSession();

            // var providers = session.GetProviderNames().ToList();

      
        




        Console.ReadLine();
        }
    }
}
