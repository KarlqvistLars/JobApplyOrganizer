using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApplyOrganizer
{
    public class JobApplication
    {
        string _path;
        string _htmlname;
        string _contact;

        // Prototype constructor
        public JobApplication()
        {
        }
        public JobApplication(string path, string htmlname, string contact)
        {
            this._path = path;
            this._htmlname = htmlname;
            this._contact = contact;
        }

        public string Path { get; set; }
        public string Htmlname { get; set; }
        public string Contact { get; set; }

        public string ToFile() { return String.Format(" {0} {1} {2}", this.Path, this.Htmlname, this.Contact); }
    }

}

