using System;
using UsersAPI.Interfaces;

namespace UsersAPI.Services
{
    /// <summary>
    /// Help make inputs valid
    /// </summary>
    public class GetValidInputService : IGetValidInputService
    {
        /// <summary>
        /// Turn any null input to empty string
        /// </summary>
        /// <param name="firstName">first name</param>
        /// <param name="lastName">last name</param>
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