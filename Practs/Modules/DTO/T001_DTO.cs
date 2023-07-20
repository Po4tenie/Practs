using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Practs.Modules.DTO
{
   
    //создание класса DTO, чтобы передавать инофрмацию из таблиц в него и уже показывать пользователю
    public class T001_DTO
    {
        [MaxLength(4)]
        public string? BURKS { get; set; }

        [MaxLength(25)]
        public string? BUTXT { get; set; }
    }
}
