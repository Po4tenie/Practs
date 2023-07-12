using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Practs.Modules.Main
{
    
    public class T001
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(4)]
        public string? BURKS { get; set; }

        [MaxLength(25)]
        public string? BUTXT { get; set; }



    }
}