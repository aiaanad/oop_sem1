namespace ZhirMaxing.Models;

using ZhirMaxing.Interfaces;

public class User: IUser, IObserver
{
    private int _id;
    public User(int id)
    {
        _id = id;
    }

    public int UserId => _id;
    public void Update(string message)
    {
        Console.WriteLine(message);
    }
}

