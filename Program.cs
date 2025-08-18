using System;
using System.Diagnostics;
public record UserProfile
{
    public string UserName { get; init; } = null!;
    // Using init-only properties to allow setting during object initialization
    // but not after the object is created.
    public string Role { get; private init; } = null!;
    public DateTime? DateOfBirth { get; init; }

    public static UserProfile CreateUser(string userName, DateTime? dateOfBirth = null)
    {
        return new UserProfile { UserName = userName, Role = "User", DateOfBirth = dateOfBirth };
    }

    public static UserProfile CreateAdmin(string userName,string role, DateTime? dateOfBirth = null)
    {
        return new UserProfile { UserName = userName, Role = role, DateOfBirth = dateOfBirth };
    }

    public string GetGreeting() => this switch
    {
        { Role: "Admin" } => $"Welcome back, Admin {UserName}!",
        { Role: "User" } => $"Hello, {UserName}! Enjoy your stay.",
        _ => "Hello! Welcome to our platform."
    };

}

public static class Program
{
    public static void Main()
    {

        var user = UserProfile.CreateUser("Alice", new DateTime(1990, 1, 1));
        Console.WriteLine(user.GetGreeting());
        Console.ReadLine();

        /* var info = new UserProfile
         {
             UserName = "Volkan",
             Role = "Admin"
             // DateOfBirth = DateTime.Now.ToString("d") ?? "Not provided"
         };*/
        
        var info=UserProfile.CreateAdmin("Volkan", "Admin", new DateTime(1990, 1, 1));
        Console.WriteLine(info.GetGreeting());


        Console.WriteLine($"User Info: {info.UserName}, Role: {info.Role}, Date of Birth: {info.DateOfBirth}");
        Console.ReadLine();
   
        //var admin = UserProfile.CreateAdmin("Bob", new DateTime(1985, 5, 15));
        //Console.WriteLine(admin.GetGreeting());

        // Demonstrating that the properties are immutable after creation
        // user.UserName = "Charlie"; // This line would cause a compile-time error

    }
}