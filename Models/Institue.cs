namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Institue")]
    public partial class Institue
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
