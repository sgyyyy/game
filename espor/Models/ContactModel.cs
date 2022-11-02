using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace espor.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Name is Required")]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Email ID is Required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Subject is Required")]
        public string Subject { get; set; }


        [Required(ErrorMessage = "Message is Required")]
        public string Message { get; set; }

    }
}
