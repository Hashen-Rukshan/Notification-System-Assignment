using System;


public interface INotification
{
    void Send(string message);
}


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


public abstract class NotificationFactory
{

    public abstract INotification CreateNotification();

    
    public void Notify(string message)
    {
        INotification notification = CreateNotification();
        notification.Send(message);
    }
}


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
        
        NotificationFactory emailFactory = new EmailFactory();
        emailFactory.Notify("Your system has been updated.");

        NotificationFactory smsFactory = new SMSFactory();
        smsFactory.Notify("Your verification code is 90210.");

        NotificationFactory pushFactory = new PushFactory();
        pushFactory.Notify("You have a new message.");
    }
}