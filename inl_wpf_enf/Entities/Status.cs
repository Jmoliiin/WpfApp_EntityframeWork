using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace inl_wpf_enf.Entities
{
    public partial class Status
    {
        public Status()
        {
            Errands = new HashSet<Errand>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string StatusType { get; set; } = null!;

        [InverseProperty(nameof(Errand.Satus))]
        public virtual ICollection<Errand> Errands { get; set; }
    }
}
