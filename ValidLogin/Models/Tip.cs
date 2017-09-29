namespace ValidLogin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tip")]
    public partial class Tip
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public virtual User User { get; set; }
    } 
}
