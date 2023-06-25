using System;

Thread t1 = new Thread(
    () =>
    {
        Singleton instance = Singleton.GetSingleton(1);
        Console.WriteLine(instance.Id);

    }
    );
Thread t2 = new Thread(
    () =>
    {
        Singleton instance = Singleton.GetSingleton(2);
        Console.WriteLine(instance.Id);

    }
    );
Thread t3 = new Thread(
    () =>
    {
        Singleton instance = Singleton.GetSingleton(3);
        Console.WriteLine(instance.Id);

    }
    );
Thread t4 = new Thread(
    () =>
    {
        Singleton instance = Singleton.GetSingleton(4);
        Console.WriteLine(instance.Id);

    }
    );
t3.Start();
t4.Start();

t3.Join();
t4.Join();

t1.Start();
t2.Start();

t1.Join();
t2.Join();



// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

     class Singleton
{
    public int Id { get; private set; }
    private static Singleton? singleton;
    private static readonly object _lock = new object();
    private Singleton() { }

    public static Singleton GetSingleton(int Id)
    {

        if(singleton==null)
        {
            lock (_lock)
            {
                if(singleton==null)
                singleton = new Singleton();
                singleton.Id = Id;
            }
        }
        return singleton;
    }
    



}


