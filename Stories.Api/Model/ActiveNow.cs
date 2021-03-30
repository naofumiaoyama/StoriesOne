using System;
namespace Stories.Api.Model
{
    public class ActiveNow
    {
        public Story[] stories;
        //static int Active = 0;
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
