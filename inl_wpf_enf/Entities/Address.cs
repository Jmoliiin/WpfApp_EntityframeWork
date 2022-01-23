using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace inl_wpf_enf.Entities
{
    public partial class Address
    {
        public Address()
        {
            Costumers = new HashSet<Costumer>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string StreetName { get; set; } = null!;
        [StringLength(5)]
        [Unicode(false)]
        public string PostalCode { get; set; } = null!;
        [StringLength(50)]
        public string City { get; set; } = null!;
        [StringLength(50)]
        public string Country { get; set; } = null!;

        [InverseProperty(nameof(Costumer.Address))]
        public virtual ICollection<Costumer> Costumers { get; set; }
    }
}
