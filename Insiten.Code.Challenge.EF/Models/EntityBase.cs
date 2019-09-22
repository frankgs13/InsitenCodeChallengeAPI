using System;
using System.ComponentModel.DataAnnotations;

namespace Insiten.Code.Challenge.EF.Models
{
    public class EntityBase
    {
        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
