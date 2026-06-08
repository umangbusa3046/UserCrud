using System;
using System.Collections.Generic;
using System.Text;

namespace UserCrud.Domain.Entities
{
    public sealed class User
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateTime CreatedOn { get; set; }
    }
}
