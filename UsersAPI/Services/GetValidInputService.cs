using System;
using UsersAPI.Interfaces;

namespace UsersAPI.Services
{
    public class GetValidInputService : IGetValidInputService
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