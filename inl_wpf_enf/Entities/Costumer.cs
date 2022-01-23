using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace inl_wpf_enf.Entities
{
    [Index(nameof(Email), Name = "UQ__Costumer__A9D10534A7634331", IsUnique = true)]
    public partial class Costumer
    {
        public Costumer()
        {
            Errands = new HashSet<Errand>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [StringLength(100)]
        [Unicode(false)]
        public string Email { get; set; } = null!;
        [StringLength(12)]
        [Unicode(false)]
        public string MobileNumber { get; set; } = null!;
        public int AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Costumers")]
        public virtual Address Address { get; set; } = null!;
        [InverseProperty(nameof(Errand.Costumer))]
        public virtual ICollection<Errand> Errands { get; set; }
    }
}
