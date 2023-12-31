﻿using System.ComponentModel.DataAnnotations;

namespace Practs.Modules.DTO
{
    //создание класса DTO, чтобы передавать инофрмацию из таблиц в него и уже показывать пользователю
    public class ZTINMM_TK_H_DTO
    {
        [Key]
        public int KONKURS_ID { get; set; } // перестановка счетчика с CHAR на INT из-за ошибки FrameworkCore

        [MaxLength(40)]
        public string? KONKURS_NR { get; set; }

        [MaxLength(255)]
        public string? KONKURS_NAME { get; set; }

        [MaxLength(4)]
        public string? BURKS { get; set; }

        [MaxLength(3)]
        public string? ORG_KEY { get; set; }

        [MaxLength(5)]
        public string? STAT { get; set; }

        public DateTime CRT_DATE { get; set; }

        public TimeSpan CRT_TIME { get; set; }

        [MaxLength(12)]
        public string? CRT_USER { get; set; }
    }
}
