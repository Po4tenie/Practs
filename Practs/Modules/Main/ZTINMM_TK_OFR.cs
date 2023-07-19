using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Practs.Modules.Main
{
   
    public class ZTINMM_TK_OFR //Создание таблицы ZTINMM_TK_OFR
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(12)]
        public string? KONKURS_ID { get; set; }

        [MaxLength(12)]
        public string? LOT_ID { get; set; }

        public int TABIX { get; set; }

        [MaxLength(10)]
        public string? LIFNR { get; set; }

        [MaxLength(132)]
        public string? LIFNR_NAME { get; set; }

        public DateTime OFR_DATE { get; set; }

        public TimeSpan OFR_TIME { get; set; }

        public decimal PRICE_NDS { get; set; }

        public decimal PRICE_S_NDS { get; set; }

        public DateTime DELIVER_DATE { get; set; }

        public TimeSpan DELIVER_TIME { get; set; }

        [MaxLength(1)]
        public string? WIN_FLG { get; set; }

    }
}