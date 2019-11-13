using System;

namespace PubSub
{
    class Pub
    {
        public Action OnChange { get; set; }

        public void Raise()
        {
            if (OnChange != null)
            {
                OnChange();
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // Create a publisher
            var p = new Pub();

            // Subscribe to the publisher's events
            p.OnChange += () => Console.WriteLine("Subscriber 1!");
            p.OnChange += () => Console.WriteLine("Subscriber 2!");

            p.Raise();

            Console.WriteLine("Press enter to terminate!");

            Console.ReadLine();
        }
    }
}