using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaMVC.Core.Models
{
    public class Slider : BaseEntity
    {
        [Required(ErrorMessage = "Enter the information correctly!!!")]
        [StringLength(50,ErrorMessage = "Title can contain a maximum of 50 characters!!!")]
        public string Title { get; set; } = null;
        [StringLength(20,ErrorMessage = "Subtitle can contain a maximum of 25 characters!!!")]
        public string SubTitle { get; set; } = null;
        public string Description { get; set; } = null;
        public string ImageUrl { get; set; } = null!;
        [NotMapped]
        public IFormFile ImageFile { get; set; } = null!;
    }
}
