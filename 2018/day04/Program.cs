using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace day_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("data.txt");
            var guards = PrepareGuards(lines);
            Console.WriteLine("Part1 First attempt - : " + 672492 + " too high");
            Console.WriteLine("Part1 First attempt - : " + 319218 + " too high");
            Console.WriteLine("Part2 First attempt - : " + 108973 + " too high");
            


             Console.WriteLine(Part1(guards));
             Console.WriteLine(Part2(guards));
            
        }

        public static List<Guard> PrepareGuards(string[] path){
            Dictionary<DateTime,String> parsed = new Dictionary<DateTime, string>();
            //[1518-03-18 00:03] Guard #3529 begins shift
            var dateFormat = "[yyyy-MM-dd HH:mm]";
            for(int i =0; i < path.Length; i++)
            {
                var line = path[i];
                var date = DateTime.ParseExact(line.Substring(0,18),dateFormat,CultureInfo.InvariantCulture);
                var msg = line.Split(']')[1];
                parsed.Add(date,msg);
            }

            List<Guard> guards = new List<Guard>();
            Guard lastGuard = null;
            foreach(var parsedLine in parsed.OrderBy( x=> x.Key))
            {
                if(parsedLine.Value.Contains("Guard")){
                    short guardNum = GetGuardNumber(parsedLine.Value);
                    var guard = guards.FirstOrDefault(x=> x.Number == guardNum);
                    if(guard == null)
                    {
                        guard = new Guard(){Number = guardNum};
                        guards.Add(guard);
                    }
                    lastGuard = guard;
                    lastGuard.Events.Add(new Event(){Date = parsedLine.Key,EventType = EventEnum.BeginsShift});
                }
                else if(parsedLine.Value.Contains("wakes"))
                    lastGuard.Events.Add(new Event(){Date = parsedLine.Key,EventType = EventEnum.WakesUp});
                else
                    lastGuard.Events.Add(new Event(){Date = parsedLine.Key,EventType = EventEnum.FallAsleep});
            }
            return guards;
        }

        public static int Part1(List<Guard> guards)
        {
            var sleepestGuard = guards.Select(x=> x.GetMinutesAsleep()).OrderBy(x=> x.Item2).Last();
            return sleepestGuard.Item1 * sleepestGuard.Item3;
        }
        
        public static int Part2(List<Guard> guards)
        {
            var sleepestGuard0 = guards.Select(x=> x.GetMinutesAsleep()).ToList();
            var sleepestGuard1 = sleepestGuard0.OrderBy(x=> x.Item4).ToList();
            var sleepestGuard = sleepestGuard1.Last();
            return sleepestGuard.Item1 * sleepestGuard.Item3;
        }
        public static short GetGuardNumber(string line){
            int pTo = line.LastIndexOf(" begins");

            return Convert.ToInt16(line.Substring(8, pTo - 8));
        }
    }
    
    public class Guard{
        public short Number {get;set;}
        public List<Event> Events = new List<Event>();

        public override string ToString(){
            return String.Format("{0}, {1}",Number.ToString(),Events.Count);
        }

        public Tuple<int,int,int,int> GetMinutesAsleep(){
            int minutesSlept = 0;

            Dictionary<int,int> minutesAndSlept = new Dictionary<int, int>();
            for(int i =0;i< 60;i++) minutesAndSlept.Add(i,0);

            foreach(var fallingAsleep in Events.Where( x=> x.EventType == EventEnum.FallAsleep))
            {
                var wakingup = Events.Where( x=> x.EventType == EventEnum.WakesUp).Where( x=> x.Date > fallingAsleep.Date).OrderBy(x=> x.Date).First();
                minutesSlept += wakingup.Date.Minute - fallingAsleep.Date.Minute;
                for(int i = fallingAsleep.Date.Minute; i < wakingup.Date.Minute;i++)
                {
                    minutesAndSlept[i] +=1;
                }
            }

            var minuteMostSlept = minutesAndSlept.OrderBy( x=> x.Value).Last();
                


            
            return new Tuple<int,int, int, int>(Number,minutesSlept,minuteMostSlept.Key,minuteMostSlept.Value);
        }
    }

    public class Event{
        public DateTime Date{get;set;}
        public EventEnum EventType {get;set;}
        
        public override string ToString(){
            return String.Format("{0}, {1}",Date.ToString(),EventType);
        }
    }
    public enum EventEnum{
        FallAsleep,
        WakesUp, 
        BeginsShift
    }
}
