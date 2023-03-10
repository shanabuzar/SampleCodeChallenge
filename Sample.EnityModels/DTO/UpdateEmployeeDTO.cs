﻿
using Sample.Utilities.Enums;
using System;

namespace Sample.Repositories.DTO
{
    public class UpdateEmployeeDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }
}
