using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceData.Model
{
    //    public class User
    //    {
    //        public int Id { get; set; }
    //        public int UserId { get; set; }
    //        public string Username{ get; set; }
    //        public string FirstName { get; set; }
    //        public string SurName { get; set; }
    //        public string Address { get; set; }
    //        public int PhoneNume { get; set; }
    //        public byte ProfilePicture { get; set; }
    //    }
    public class User : IdentityUser
    {
        public string ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


    }
}
