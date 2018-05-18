using System.ComponentModel.DataAnnotations;

namespace BLAG.Common.Models
{
    public class ModelBase
    {
        [Required]
        public int Id { get; set; }
    }
}