using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace inl_wpf_enf.Entities
{
    public partial class Errand
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Heading { get; set; } = null!;
        [StringLength(100)]
        public string Descriptions { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }
        public int CostumerId { get; set; }
        public int AdminsId { get; set; }
        public int SatusId { get; set; }

        [ForeignKey(nameof(AdminsId))]
        [InverseProperty(nameof(Admin.Errands))]
        public virtual Admin Admins { get; set; } = null!;
        [ForeignKey(nameof(CostumerId))]
        [InverseProperty("Errands")]
        public virtual Costumer Costumer { get; set; } = null!;
        [ForeignKey(nameof(SatusId))]
        [InverseProperty(nameof(Status.Errands))]
        public virtual Status Satus { get; set; } = null!;
    }
}
