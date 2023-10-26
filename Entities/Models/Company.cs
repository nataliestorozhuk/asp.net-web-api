using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Company
    {
        [Column("CompanyID")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Company name id a required field")]
        [MaxLength(60, ErrorMessage ="Maximum length for the Name is 60 characters.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Company adress is a required field")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters.")]
        public string? Address { get; set; }
        public string? Country { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
