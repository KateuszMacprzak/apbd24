namespace LegacyApp;

public class LegacyAppTests
{
    var userService = new UserService();
    string invalidEmail = "testemail.com"; // brak @ i .
    string firstName = "Jan";
    string lastName = "Kowalski";
    DateTime dateOfBirth = new DateTime(1990, 1, 1);
    int clientId = 1; // Zakładamy, że istnieje klient o tym ID, w przeciwnym razie należałoby dostosować test

    // Act
    var result = userService.AddUser(firstName, lastName, invalidEmail, dateOfBirth, clientId);

    // Assert
    Assert.IsFalse(result, "Metoda AddUser powinna zwrócić `false` dla nieprawidłowego adresu email.");
}