using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ContellectTask_MahamedMamdouh.Models
{
    public partial class Contacts
    {
        [Key]
        public int ContactId { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]

        public int Phone { get; set; }
        [Required]

        public string Address { get; set; }
        public string Notes { get; set; }
    }
}
