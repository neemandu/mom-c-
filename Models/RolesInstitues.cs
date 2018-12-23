using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("RolesInstitues")]
    public partial class RolesInstitues
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int InstitueId { get; set; }
    }
}