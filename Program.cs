using System;

// Product Interface
public interface INotification
{
    void Send(string message);
}

// Concrete Products
public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending Email: {message}");
    }
}

public class SMSNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}

public class PushNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending Push Notification: {message}");
    }
}
// Abstract Creator
public abstract class NotificationFactory
{
    // The Factory Method
    public abstract INotification CreateNotification();

    // Core logic that relies on the factory method
    public void Notify(string message)
    {
        INotification notification = CreateNotification();
        notification.Send(message);
    }
}
// Concrete Creators
public class EmailFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new EmailNotification();
    }
}

public class SMSFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new SMSNotification();
    }
}

public class PushFactory : NotificationFactory
{
    public override INotification CreateNotification()
    {
        return new PushNotification();
    }
}
class Program
{
    static void Main(string[] args)
    {
        // 1. Client creates a specific factory
        NotificationFactory emailFactory = new EmailFactory();
        // 2. Client calls the core method, which dynamically instantiates the EmailNotification
        emailFactory.Notify("Your system has been updated.");

        NotificationFactory smsFactory = new SMSFactory();
        smsFactory.Notify("Your verification code is 90210.");

        NotificationFactory pushFactory = new PushFactory();
        pushFactory.Notify("You have a new message.");
    }
}