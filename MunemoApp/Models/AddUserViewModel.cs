﻿namespace MunemoApp.Models
{
    public class AddUserViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Province { get; set; }
        public string Gender { get; set; }
        public bool Facilitator { get; set; }
    }
}
