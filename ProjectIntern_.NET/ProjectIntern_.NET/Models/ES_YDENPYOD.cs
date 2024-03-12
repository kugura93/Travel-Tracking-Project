using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectIntern_.NET.Models
{
     
    public class ES_YDENPYOD
    {
        
        [Column("GYONO")]
        [Display(Name = "行番号")]
        [Required]
        public Int32 gyoNO { get; set; }
        [Column("DENPYONO")]
        [Display(Name = "伝票番号")]
        public Int32 denpyoNO { get; set; }
        [Column("IDODT")]
        [Display(Name = "移動年月日")]
        [DataType(DataType.Date)]
        public DateTime idoDT { get; set; }
        [Column("SHUPPATSUPLC")]
        [Display(Name = "出発地")]
        public String shuppatsuPLC { get; set; }
        [Column("MOKUTEKIPLC")]
        [Display(Name = "目的地")]
        public String mokutekiPLC { get; set; }
        [Column("KEIRO")]
        [Display(Name = "経路")]
        public String keiro { get; set; }
        [Column("KINGAKU")]
        [Display(Name = "金額")]
        public Int32 kingaku { get; set; }
    }
}
