using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a1.Models
{
    [TypeLite.TsClass]
    public class IvhunimAndActions
    {
        public List<Ivhunim> Ivhunim { get; set; }
        public List<RolesAction> Actions { get; set; }
    }
}