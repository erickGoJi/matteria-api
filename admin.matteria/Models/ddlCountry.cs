using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace admin.matteria.Models
{
    public class ddlCountry
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo es obligatorio")]
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
