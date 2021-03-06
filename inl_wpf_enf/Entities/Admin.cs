using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace inl_wpf_enf.Entities
{
    public partial class Admin
    {
        public Admin()
        {
            Errands = new HashSet<Errand>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [InverseProperty(nameof(Errand.Admins))]
        public virtual ICollection<Errand> Errands { get; set; }
    }
}
