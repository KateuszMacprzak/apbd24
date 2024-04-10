using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.Month < dateOfBirth.Month ||
                (DateTime.Now.Month == dateOfBirth.Month && DateTime.Now.Day < dateOfBirth.Day))
            {
                age--;
            }

            ;

            if ((string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)) || (!email.Contains("@") && !email.Contains(".")) || (age<21) || client.Type == "VeryImportantClient")
            {
                return false;
            }
            

            if (client.Type == "ImportantClient")
            {
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit * 2;
                }
            }
            else
            {
                user.HasCreditLimit = true;
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
                }
            }

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
