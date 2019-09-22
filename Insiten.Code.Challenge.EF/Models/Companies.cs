using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Insiten.Code.Challenge.EF.Models
{
    public partial class Companies : EntityBase
    {
        public Companies()
        {
            CompanyKeyContacts = new HashSet<CompanyKeyContacts>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }

        [Required]
        public int IdStatus { get; set; }
        public decimal? FinancialPerformance { get; set; }

        public virtual CompanyStatus IdStatusNavigation { get; set; }
        public virtual ICollection<CompanyKeyContacts> CompanyKeyContacts { get; set; }
    }
}
