﻿using DataModels;

namespace Contracts.ViewModels
{
    public class PersonViewModel : IPersonModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
        public double Balance { get; set; }
        public long Id { get; set; }
    }
}