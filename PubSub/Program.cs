using System;

namespace PubSub
{
    class MyEventArgs : EventArgs
    {
        public int Value { get; set; }

        public MyEventArgs(int value) => Value = value;
    }
    
    class Pub
    {
        public event EventHandler<MyEventArgs> OnChange = delegate { };

        public void Raise()
        {
            OnChange(this, new MyEventArgs(42));
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // Create a publisher
            var p = new Pub();

            // Subscribe to the publisher's events
            p.OnChange += (sender, e) => Console.WriteLine($"Subscriber 1! Value: {e.Value}");
            p.OnChange += (sender, e) => Console.WriteLine($"Subscriber 2! Value: {e.Value}");

            p.Raise();
        }
    }
}