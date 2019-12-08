using System;
using System.Linq;
using System.Collections.Generic;

namespace day07
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
            var maxAmplifierOutput = 0 ;
            var ampSignal = "";
            for(int i = 0; i <5;i++)
            {
                for(int j = 0; j <5;j++)
                {
                    for(int k = 0; k <5;k++)
                    {                        
                        for(int l = 0; l <5;l++)
                        {
                            for(int m = 0; m <5;m++)
                            {
                                if(String.Format($"{i}{j}{k}{l}{m}").GroupBy( x=> x).Any( x=> x.Count() > 1))
                                continue;;

                                var aplifierAOutput = IntCodeComputer(text,0,i);
                                var aplifierBOutput = IntCodeComputer(text,aplifierAOutput,j);
                                var aplifierCOutput = IntCodeComputer(text,aplifierBOutput,k);
                                var aplifierDOutput = IntCodeComputer(text,aplifierCOutput,l);
                                var aplifierEOutput = IntCodeComputer(text,aplifierDOutput,m);

                                if(maxAmplifierOutput < aplifierEOutput)
                                maxAmplifierOutput  = aplifierEOutput;
                            }
                        }
                    }
                }
            }
            return maxAmplifierOutput;
        }
        
        static int part2(string text)
        {
            text = "3,52,1001,52,-5,52,3,53,1,52,56,54,1007,54,5,55,1005,55,26,1001,54,-5,54,1105,1,12,1,53,54,53,1008,54,0,55,1001,55,1,55,2,53,55,53,4,53,1001,56,-1,56,1005,56,6,99,0,0,0,0,10";
            var maxAmplifierOutput = 0 ;
            var ampSignal = "";
            for(int i = 5; i <10;i++)
            {
                for(int j = 5; j <10;j++)
                {
                    for(int k = 5; k <10;k++)
                    {                        
                        for(int l = 5; l <10;l++)
                        {
                            for(int m = 5; m <10;m++)
                            {
                                var phaseSettingSequence = String.Format($"{i}{j}{k}{l}{m}");
                                if(phaseSettingSequence.GroupBy( x=> x).Any( x=> x.Count() > 1))
                                continue;;

                                var input = 0;

                                for(int loop =0;loop < 5;loop++)
                                {
                                    input = IntCodeComputer(text,input,i);
                                    input = IntCodeComputer(text,input,j);
                                    input = IntCodeComputer(text,input,k);
                                    input = IntCodeComputer(text,input,l);
                                    input = IntCodeComputer(text,input,m);
                                }
                                if(maxAmplifierOutput < input)
                                {
                                    maxAmplifierOutput  = input;
                                    ampSignal = phaseSettingSequence;
                                }
                            }
                        }
                    }
                }
            }
            return maxAmplifierOutput;
        }
        
        static int IntCodeComputer(string text, int id, int phaseSetting)
        {
            var paramoutput = 0;
            bool usedPhaseSetting = false;
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
                    if(usedPhaseSetting == false)
                    {
                        values[firstValue] = phaseSetting;
                        usedPhaseSetting = true;
                    }
                    else
                        values[firstValue] = id;
                    i+=2;
                }
                else if(opcode == 4)
                {
                    if(values[values[i+1]] != 0)
                    {
                        paramoutput = values[values[i+1]];
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
