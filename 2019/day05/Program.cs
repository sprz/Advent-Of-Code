using System;
using System.Linq;

namespace day05
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = System.IO.File.ReadAllText("data.txt");
            Console.WriteLine(part1(text, 1));
            Console.WriteLine(part2(text,5));
        }
        
        static int part1(string text, int id)
        {
            var paramoutput = 0;
            var values = text.Split(',').Select(x=> Convert.ToInt32(x)).ToList();

            for(int i =0; i<values.Count();)
            {
                if(values[i] == 99) 
                    break;

                var paramModes = GetParamModes(values[i]);
                var opcode = paramModes[0];
                int firstValue=0, secondValue=0,thirdValue=0;

                firstValue = values[i+1];
                
                if(opcode < 3)
                {
                    secondValue = values[i+2];
                    thirdValue = values[i+3];

                    if(paramModes[1] == 0)
                    firstValue = values[firstValue];
                    if(paramModes[2] == 0)
                    secondValue = values[secondValue];  
                }
                

                if(opcode == 1)
                    values[thirdValue] = firstValue+secondValue;
                else if(opcode == 2)
                    values[thirdValue] = firstValue*secondValue;
                else if(opcode == 3)
                    values[firstValue] = id;
                else if(opcode == 4)
                    {
                        if(values[values[i+1]] != 0)
                        {
                            paramoutput = values[values[i+1]];
                            Console.WriteLine(i + ": " + paramoutput);
                        }
                    }
                else 
                    break;
                
                if(opcode < 3) 
                    i+=4;
                else    
                    i+=2;
            }

            return paramoutput;
        }

        
        static int part2(string text, int id)
        {
           // text = "3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99";
            
            var paramoutput = 0;
            var values = text.Split(',').Select(x=> Convert.ToInt32(x)).ToList();

            for(int i =0; i<values.Count();)
            {
                if(values[i] == 99) 
                    break;

                var paramModes = GetParamModes(values[i]);
                var opcode = paramModes[0];
                int firstValue=0, secondValue=0,thirdValue=0;

                firstValue = values[i+1];

                if(opcode != 3 && opcode != 4)
                {
                    secondValue = values[i+2];
                    thirdValue = values[i+3];
                    if(paramModes[1] == 0)
                    firstValue = values[firstValue];
                    if(paramModes[2] == 0)
                    secondValue = values[secondValue];  
                }           

                if(opcode == 1)
                {
                    values[thirdValue] = firstValue+secondValue;
                    i+=4;
                }
                else if(opcode == 2)
                {
                    values[thirdValue] = firstValue*secondValue;
                    i+=4;
                }
                else if(opcode == 3)
                {
                    values[firstValue] = id;
                    i+=2;
                }
                else if(opcode == 4)
                {
                    if(values[values[i+1]] != 0)
                    {
                        paramoutput = values[values[i+1]];
                        Console.WriteLine(i + ": " + paramoutput);
                    }
                    i+=2;
                }
                else if(opcode == 5)
                {
                    if(firstValue != 0)
                        i=secondValue;
                    else
                        i+=3;

                }
                else if(opcode == 6)
                {
                    if(firstValue == 0)
                        i=secondValue;
                    else
                        i+=3;
                }
                else if(opcode == 7)
                {
                    if(firstValue < secondValue)
                        values[thirdValue] = 1;
                    else
                        values[thirdValue] = 0;
                    i+=4;
                }
                else if(opcode == 8)
                {
                    if(firstValue == secondValue)
                        values[thirdValue] = 1;
                    else
                        values[thirdValue] = 0;
                    i+=4;
                }
                
            }

            return paramoutput;
        }


        private static int[] GetParamModes(int paramValue)
        {
            var output = new int[4];
            var paramString = paramValue.ToString();

            if(paramString.Length < 5)
            {
                for(int i=5-paramString.Length; i > 0 ; i-- )
                    paramString = "0" + paramString;
            }
            
            output[0] = Convert.ToInt16(paramString.Substring(3));
            output[1] = Convert.ToInt16(paramString.Substring(2,1));
            output[2] = Convert.ToInt16(paramString.Substring(1,1));
            output[3] = Convert.ToInt16(paramString.Substring(0,1));

            return output;
        }

    }
}
