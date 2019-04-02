namespace SqlModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class V_everydaynews
    {
        [Key]
        public int eid { get; set; }

        public DateTime? edate { get; set; }

        [StringLength(20)]
        public string eauthor { get; set; }

        public DateTime? eupdate { get; set; }

        [StringLength(20)]
        public string eupdateuser { get; set; }

        [StringLength(50)]
        public string etitle { get; set; }

        [StringLength(200)]
        public string edigest { get; set; }

        public int? elook { get; set; }

        public int? esay { get; set; }

        public int? ewc { get; set; }

        [StringLength(1)]
        public string state { get; set; }

        [StringLength(1)]
        public string isvalid { get; set; }
    }
}
