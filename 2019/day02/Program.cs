using System;
using System.Linq;

namespace day02
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = System.IO.File.ReadAllText("data.txt");
            Console.WriteLine(part1(text));
            Console.WriteLine(part2(text));

        }

        static int part1(string text)
        {
            var values = text.Split(',').Select(x=> Convert.ToInt32(x)).ToList();
            values[1] = 12;
            values[2] = 2;

            for(int i =0; i<values.Count();i+=4)
            {
                var opcode = values[i];
                if(opcode == 99) 
                    break;
                

                var firstValue = values[values[i+1]];
                var secondValue = values[values[i+2]];
                var thirdValue = values[i+3];
                

                if(opcode == 1)
                    values[thirdValue] = firstValue+secondValue;
                else if(opcode == 2)
                    values[thirdValue] = firstValue*secondValue;
            }

            return values[0];
        }

        static int part2(string text)
        {   
            
            for(var noun =0; noun < 99; noun++)
            for(var verb = 0; verb < 99; verb++)
            {
                var values = text.Split(',').Select(x=> Convert.ToInt32(x)).ToList();
                values[1] = noun;
                values[2] = verb;

                for(int i =0; i<values.Count();i+=4)
                {
                    var opcode = values[i];
                    if(opcode == 99) 
                        break;
                    

                    var firstValue = values[values[i+1]];
                    var secondValue = values[values[i+2]];
                    var thirdValue = values[i+3];
                    

                    if(opcode == 1)
                        values[thirdValue] = firstValue+secondValue;
                    else if(opcode == 2)
                        values[thirdValue] = firstValue*secondValue;
                        

                    values[i] +=4;
                }
                if(values[0] == 19690720)
                    return 100*noun + verb;
                
                
            }
            return -1;
        }
    }
}
