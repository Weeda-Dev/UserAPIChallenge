using System;

namespace UsersAPI.Utilities
{
    public class ValidInputHelper
    {
        internal void TurnNullToEmptyString(ref string firstName, ref string lastName)
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