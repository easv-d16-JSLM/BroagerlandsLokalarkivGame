using System.ComponentModel.DataAnnotations;

namespace BLAG.Common.Models
{
    public abstract class ModelBase
    {
        [Required]
        public int Id { get; set; }
    }
}