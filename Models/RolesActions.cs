using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("RolesActions")]
    public partial class RolesActions
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        [StringLength(20)]
        public string Action { get; set; }
    }
}