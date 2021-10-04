using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    class ProfileValidation
    {
        [Required]
        public int Profile_ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        [Required]
        public string Email_ID { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }


    }

    [MetadataType(typeof(ProfileValidation))]
    public partial class Profile
    { }
}
