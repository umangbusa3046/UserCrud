using System;
using System.Collections.Generic;
using System.Text;

namespace UserCrud.Application.Exceptions
{
    public sealed class BadRequestException
    : Exception
    {
        public BadRequestException(string message)
            : base(message)
        {
        }
    }
}
