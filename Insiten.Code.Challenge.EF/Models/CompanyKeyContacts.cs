using System;
using System.ComponentModel.DataAnnotations;

namespace Insiten.Code.Challenge.EF.Models
{
    public partial class CompanyKeyContacts : EntityBase
    {
        public int Id { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual Companies Company { get; set; }
    }
}
