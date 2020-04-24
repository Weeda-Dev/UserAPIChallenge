using System;
using UsersAPI.Interfaces;

namespace UsersAPI.Utilities
{
    public class ValidInputService : IValidInputService
    {
        public void TurnNullToEmptyString(ref string firstName, ref string lastName)
        {
            if (String.IsNullOrEmpty(firstName))
            {
                firstName = "";
            }

            if (String.IsNullOrEmpty(lastName))
            {
                lastName = "";
            }
        }
    }
}