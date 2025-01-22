using System;

namespace hris.Seed.Domain.Exceptions
{
    public class PhoneNumberTypeNotFoundException : Exception
    {
        public PhoneNumberTypeNotFoundException(string message) : base(message) { }
    }
}
