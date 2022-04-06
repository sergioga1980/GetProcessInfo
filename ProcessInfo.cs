using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ProcessInfo
    {
        private string pid; // field
        private string parentId; // field
        private string osName;
        private string name;
        private string path;
        private string userSID;
        private string cmdLine;
        private string handle;
        private string creationDate;
        private string caption;
        private string csName;


        public string PID   // property
        {
            get { return pid; }   // get method
            set { pid = value; }  // set method
        }

        public string Handle   // property
        {
            get { return handle; }   // get method
            set { handle = value; }  // set method
        }

        public string CreationDate   // property
        {
            get { return creationDate; }   // get method
            set { creationDate = value; }  // set method
        }

        public string Caption   // property
        {
            get { return caption; }   // get method
            set { caption = value; }  // set method
        }

        public string CsName   // property
        {
            get { return csName; }   // get method
            set { csName = value; }  // set method
        }

        public string ParentId   // property
        {
            get { return parentId; }   // get method
            set { parentId = value; }  // set method
        }

        public string OSName   // property
        {
            get { return osName; }   // get method
            set { osName = value; }  // set method
        }

        public string Name   // property
        {
            get { return name; }   // get method
            set { name = value; }  // set method
        }

        public string Path   // property
        {
            get { return path; }   // get method
            set { path = value; }  // set method
        }

        public string UserSID   // property
        {
            get { return userSID; }   // get method
            set { userSID = value; }  // set method
        }

        public string CmdLine   // property
        {
            get { return cmdLine; }   // get method
            set { cmdLine = value; }  // set method
        }
    }
}

