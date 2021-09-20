using System;
using System.Runtime.Serialization;

namespace CountryCodes.Content.Exceptions
{
    [Serializable]
    public class CountryNotFoundException : Exception
    {
        public CountryNotFoundException(string message) : base(message)
        {
            
        }
        protected CountryNotFoundException(SerializationInfo info,StreamingContext context)
            :base(info,context){}
    }
}