using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("RolesMainTableColumns")]
    public partial class RolesMainTableColumns
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        [StringLength(20)]
        public string ColumnName { get; set; }
        public int OrderNumber { get; set; }
    }
}