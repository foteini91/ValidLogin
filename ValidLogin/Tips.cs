namespace ValidLogin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tips
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public virtual Users Users { get; set; }
    }
}
