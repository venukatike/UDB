using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace UDB.Model
{
    public class Person
    {
        public string FirstName { get; set; }
        public string  LastName{ get; set; }
        public string DateOfBirth{ get; set; }
        public string  Gender{ get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
