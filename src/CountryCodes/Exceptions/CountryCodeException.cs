using System;
using System.Runtime.Serialization;

namespace CountryCodes.Content.Exceptions
{
    public class CountryCodeException : Exception
    {
        public CountryCodeException(string message) : base(message)
        {
            
        }
        protected CountryCodeException(SerializationInfo info,StreamingContext context)
            :base(info,context){}
        
    }
}