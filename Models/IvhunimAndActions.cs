using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class IvhunimAndActions
    {
        public List<Ivhunim> Ivhunim { get; set; }
        public List<RolesActions> Actions { get; set; }
        public List<string> Columns { get; set; }
    }
}