using System;

namespace hris.Seed.Domain.Exceptions._PhoneNumberType
{
    public class PhoneNumberTypeNotFoundException : Exception
    {
        public PhoneNumberTypeNotFoundException(string message) : base(message) { }
    }
}
