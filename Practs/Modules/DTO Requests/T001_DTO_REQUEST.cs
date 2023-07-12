﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Practs.Modules.DTO_Requests
{
 
    public class T001_DTO_REQUEST
    {
        [MaxLength(4)]
        public string? BURKS { get; set; }

        [MaxLength(25)]
        public string? BUTXT { get; set; }
    }
}
