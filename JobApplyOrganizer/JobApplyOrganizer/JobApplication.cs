using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplyOrganizer
{
    public class JobApplication
    {
        readonly string _path;
        readonly string _htmlname;
        readonly string _contact;
        readonly string _name;
        readonly string _company;
        // Prototype constructor
        public JobApplication()
        {
        }
        public JobApplication(string path, string htmlname, string contact, string name, string company)
        {
            this._path = path;
            this._htmlname = htmlname;
            this._contact = contact;
            this._name = name;
            this._company = company;
        }
        public string Path { get; set; }
        public string Htmlname { get; set; }
        public string Contact { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string ToFile() { return String.Format(" {0} {1} {2}", this.Path, this.Htmlname, this.Contact); }
    }

}

