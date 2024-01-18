﻿namespace Homework1.API.Models.DTOs
{
    public class UserUpdateDtoRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int Age { get; set; }
    }
}
