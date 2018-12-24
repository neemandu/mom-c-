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

    public static class InstituesNames
    {
        public static readonly string AYA_NEEMAN = "איה נאמן";
        public static readonly string NEXT_STEP = "הצעד הבא";
    }
}
