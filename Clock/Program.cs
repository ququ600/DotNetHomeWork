using System;

namespace Clock
{
    public class Clock
    {
        public event EventHandler Tick;
        public event EventHandler Alarm;
        public void onTickComing(string msg)
        {
            if (Tick != null)
            {
                Tick(this, new EventArgs());
            }
        }
        public void onAlarmComing(string msg)
        {
            if (Alarm != null)
            {
                Alarm(this, new EventArgs());
            }
        }

    }
    public class Sleeper
    { 
        public string Name;
        public Sleeper(string name)
        {
            Name = name;
        }
        public void sleeping(object c, EventArgs e)
        {
            Console.WriteLine("滴答滴答，{0}还在睡觉", this.Name);
        }
        public void alarmed(object c,EventArgs e)
        {
            Console.WriteLine(this.Name + "被闹钟吵醒了");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            Sleeper sleeper1 = new Sleeper("小孟");
            clock.Tick += new EventHandler(sleeper1.sleeping);
            clock.Alarm += new EventHandler(sleeper1.alarmed);
            clock.onTickComing("dddd");
            clock.onAlarmComing("dddd");
            Console.WriteLine("Hello World!");
        }
    }
}
