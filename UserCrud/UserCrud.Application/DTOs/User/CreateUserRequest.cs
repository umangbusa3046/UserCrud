using System;
using System.Collections.Generic;
using System.Text;

namespace UserCrud.Application.DTOs.User
{
    public sealed class CreateUserRequest
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
