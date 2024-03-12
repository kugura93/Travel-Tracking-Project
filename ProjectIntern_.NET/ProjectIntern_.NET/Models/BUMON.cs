using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectIntern_.NET.Models
{
    public class BUMON
    {
        [Key]
        [Column("BUMONCD")]
        [Display(Name = "部門コード")]
        [Required]
        public String bumonCD { get; set; }
        [Column("BUMONNM")]
        [Display(Name = "部門名")]
        public String bumonNM { get; set; }
    }
}
