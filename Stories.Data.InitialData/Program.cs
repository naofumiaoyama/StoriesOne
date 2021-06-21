using System;
using System.Threading.Tasks;

namespace Stories.Data.InitialData
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            PersonData personData = new PersonData();
            PersonalInfoData personalInfoData = new PersonalInfoData();
            TimelineData timelineData = new TimelineData();

            await personData.DeleteData();
            await personalInfoData.DeleteData();
            await timelineData.DeleteData();
            
            await personData.MakeData();
            await personalInfoData.MakeData();
            await timelineData.MakeData();
        }
    }
}