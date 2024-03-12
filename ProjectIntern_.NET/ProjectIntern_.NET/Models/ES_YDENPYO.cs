using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectIntern_.NET.Models
{
    public class ES_YDENPYO
    {
        [Key]
        [Column("DENPYONO")]
        [Display(Name = "伝票番号")]
        [Required]
        public Int32 denpyoNO { get; set; }

        [Column("KAIKEIND")]
        [Display(Name = "年度")]
        public Int32 kaikeiND { get; set; }

        [Column("DENPYODT")]
        [Display(Name = "伝票日付")]
        [DataType(DataType.Date)]
        public DateTime denpyoDT { get; set; }

        [Column("UKETUKEDT")]
        [Display(Name = "申請日")]
        [DataType(DataType.Date)]
        public DateTime uketukeDT { get; set; }

        [Column("BUMONCD_YKANR")]
        [Display(Name = "起票部門")]
        public String bumonCD_YKANR { get; set; }

        [Column("BIKO")]
        [Display(Name = "出張目的(備考)")]
        public String biko { get; set; }

        [Column("SUITOKB")]
        [Display(Name = "出納方法")]
        public String suitoKB { get; set; }

        [Column("SHIHARAIDT")]
        [Display(Name = "支払予定日")]
        [DataType(DataType.Date)]
        public DateTime shiharaiDT { get; set; }

        [Column("KINGAKU")]
        [Display(Name = "行選択")]
        public Int32 kingaku { get; set; }

    }
}
