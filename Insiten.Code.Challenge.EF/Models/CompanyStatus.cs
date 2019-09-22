using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Insiten.Code.Challenge.EF.Models
{
    public partial class CompanyStatus : EntityBase
    {
        public CompanyStatus()
        {
            Companies = new HashSet<Companies>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Companies> Companies { get; set; }
    }
}
