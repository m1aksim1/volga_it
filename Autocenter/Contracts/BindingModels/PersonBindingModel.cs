﻿using DataModels;

namespace Contracts.BindingModels
{
    public class PersonBindingModel : IPersonModel
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int Id { get; set; }
    }
}