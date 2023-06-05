using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TbcAcademy
{
    public class Excersice
    {
        public static void Main(string[] args)
        {
            string Input = Console.ReadLine();
            int InputNumber = Convert.ToInt32(Input);
            if (InputNumber < 0) {
                Console.WriteLine("Cold");
            }else if (InputNumber <= 30){
                Console.WriteLine("Good Weather");
            }else{
            Console.WriteLine("It's Hot");
            }        
            
        }
    }
}
