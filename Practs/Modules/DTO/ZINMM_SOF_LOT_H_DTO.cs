﻿using System.ComponentModel.DataAnnotations;

namespace Practs.Modules.DTO
{
    //создание класса DTO, чтобы передавать инофрмацию из таблиц в него и уже показывать пользователю
    public class ZINMM_SOF_LOT_H_DTO
    {
        [Key]
        public int LOT_ID { get; set; }

        [MaxLength(12)]
        public string? KONKURS_ID { get; set; }

        [MaxLength(30)]
        public string? LOT_NR { get; set; }

        [MaxLength(132)]
        public string? LOT_NAME { get; set; }

        [MaxLength(4)]
        public string? EKORG { get; set; }

        public decimal FINAN_LIMIT_WVAT { get; set; } //тип СУММА
        public decimal FINAN_LIMIT_WOVAT { get; set; } //тип СУММА

        [MaxLength(2)]
        public string? VAT_RATE { get; set; }

        [MaxLength(1)]
        public string? CALC_NDS { get; set; }

    }
}
