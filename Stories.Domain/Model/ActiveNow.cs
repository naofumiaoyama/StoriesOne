﻿using System;
namespace Stories.Domain.Model
{
    public class ActiveNow
    {
        public Story[] stories;

        static void Active(string[] args)
        {
            string str = "Active";

            bool isNotEmpty = str.Length > 0;
            
            if (isNotEmpty)
            {
                Console.WriteLine("Active");
            }
            else
            {
                Console.WriteLine("NotActive");
            }
            Console.WriteLine(isNotEmpty);

            Console.ReadLine();
        }




    }
}
