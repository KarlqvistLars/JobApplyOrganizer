using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JobApplyOrganizer
{
    public class JobApplication
    {
        readonly string _path;
        readonly string _createDate;
        readonly string _htmlname;
        readonly string _contact;
        readonly string _name;
        readonly string _company;
        readonly string _tele;
        readonly string _mail;
        readonly string _url;
        // Prototype constructor
        public JobApplication()
        {
        }
        public JobApplication(string path, string createDate, string htmlname, string contact, string name, string company, string tele, string mail, string url)
        {
            this._path = path;
            this._createDate = createDate;
            this._htmlname = htmlname;
            this._contact = contact;
            this._name = name;
            this._company = company;
            this._tele = tele;
            this._mail = mail;
            this._url = url;
        }
        public string Path { get; set; }
        public string CreateDate { get; set; }
        public string Htmlname { get; set; }
        public string Contact { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Tele { get; set; }
        public string Mail { get; set; }
        public string URL { get; set; }
        public string SaveToFile() { return String.Format("JobApplication[{0},{1},{2},{3},{4},{5},{6},{7},{8}]", this._path, this._createDate, this._htmlname, this._contact, this._name, this._company, this._tele, this._mail, this._url); }
        public void LoadFromFile(String jobLoad) 
        {
            String[] parsStr = jobLoad.Split(',');
            Path = parsStr[0].Trim().Replace("JobApplication[","");
            CreateDate = parsStr[1].Trim();
            Htmlname = parsStr[2].Trim();
            Contact = parsStr[3].Trim();
            Name = parsStr[4].Trim();
            Company = parsStr[5].Trim();
            Tele = parsStr[6].Trim();
            Mail = parsStr[7].Trim();
            URL = parsStr[8].Trim().Replace("]","");
        }
    }
}

