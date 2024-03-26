using LegacyApp;
namespace LegacyAppTests;

public class Tests
{

    [Test]
    public void TestCreateUserWithAgeUnder21()
    {
        var userService = new UserService();
        string firstName = "jan";
        string lastName = "kowalski";
        string email = "jan.kowalski@example.com";
        DateTime dateOfBirth = DateTime.Now.AddYears(-20);
        int clientId = 1;
        
        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);
        Assert.IsFalse(result);
    }
    [Test]
    public void TestCreateUserWithEmptyFirstName()
    {
        var userService = new UserService();
        string firstName = "";
        string lastName = "kowalski";
        string email = "jan.kowalski@example.com";
        DateTime dateOfBirth = DateTime.Now.AddYears(-20);
        int clientId = 1;
        
        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);
        Assert.IsFalse(result);
    }
    
    [Test]
    public void TestCreateUserWithNullFirstName()
    {
        var userService = new UserService();
        string firstName = null;
        string lastName = "kowalski";
        string email = "jan.kowalski@example.com";
        DateTime dateOfBirth = DateTime.Now.AddYears(-20);
        int clientId = 1;
        
        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);
        Assert.IsFalse(result);
    }
    [Test]
    public void TestCreateUserWithEmptyLastName()
    {
        var userService = new UserService();
        string firstName = "jan";
        string lastName = "";
        string email = "jan.kowalski@example.com";
        DateTime dateOfBirth = DateTime.Now.AddYears(-20);
        int clientId = 1;
        
        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);
        Assert.IsFalse(result);
    }
    
    [Test]
    public void TestCreateUserWithNullLastName()
    {
        var userService = new UserService();
        string firstName = "jan";
        string lastName = null;
        string email = "jan.kowalski@example.com";
        DateTime dateOfBirth = DateTime.Now.AddYears(-20);
        int clientId = 1;
        
        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);
        Assert.IsFalse(result);
    }
    
    [Test]
    public void TestCreateUserWhereEmailDoesNotContainAtSign()
    {
        var userService = new UserService();
        string firstName = "jan";
        string lastName = "kowalski";
        string email = "jan.kowalski_example.com";
        DateTime dateOfBirth = DateTime.Now.AddYears(-20);
        int clientId = 1;
        
        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);
        Assert.IsFalse(result);
    }
    
    [Test]
    public void TestCreateUserWhereEmailDoesNotContainDot()
    {
        var userService = new UserService();
        string firstName = "jan";
        string lastName = "kowalski";
        string email = "jan.kowalski@example_com";
        DateTime dateOfBirth = DateTime.Now.AddYears(-20);
        int clientId = 1;
        
        var result = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);
        Assert.IsFalse(result);
    }
}