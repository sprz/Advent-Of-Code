﻿using System;
using System.Collections.Generic;
using System.Linq;
namespace day_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var banks = new int[]{4,10,4,1,8,4,9,14,5,1,14,15,0,15,3,5};
            var existedConfigs = new HashSet<String>();
            var cycleNo = 0;
            while(!existedConfigs.Contains(String.Join(";",banks)))
            {
                existedConfigs.Add(String.Join(";",banks));
                var index =  Array.IndexOf(banks,banks.Max());

                var memories = banks[index];
                banks[index] = 0;
                for(int i=index+1;memories != 0;i++)
                {
                    banks[i%banks.Length]++;
                    memories--;
                }
                cycleNo++;
            }

        }
        
    }
}
