using System;
using System.Threading.Tasks;

namespace Stories.Data.InitialData
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            if(args[0] == "S" || args[0] == "s")
            {
                await InitialDataFromSource();
            }
            else if(args[0] == "E" || args[0] == "e")
            {
                 PutColumnInfoToExcelFromSQLServer();
            }
            else if(args[0] == "R" || args[0] == "r")
            {
                var bookName = args[1];
                await ReadExcelToSQLServerAsync(bookName);
            }
        }
        static void PutColumnInfoToExcelFromSQLServer()
        {
            ExcelNPoi excelNPoi = new ExcelNPoi();
            excelNPoi.PutColumnInfoFromSQLServer();

        }

        static async Task ReadExcelToSQLServerAsync(string bookName)
        {
            ExcelNPoi excelNPoi = new ExcelNPoi();
            await excelNPoi.ReadExcelBookToSQLServerAsync(bookName);
        }
        static async Task InitialDataFromSource()
        {
            PersonData personData = new PersonData();
            PersonalInfoData personalInfoData = new PersonalInfoData();
            PictureData pictureData = new PictureData();
            TimelineData timelineData = new TimelineData();
            AddressData addressData = new AddressData();
            CommentData commentData = new CommentData();
            FriendRelationshipData friendRelationshipData = new FriendRelationshipData();
            PostData postData = new PostData();
            StoryData storyData = new StoryData();
            ReactionMarkData reactionMarkData = new ReactionMarkData();
            BodyData bodyData = new BodyData();

            await personData.DeleteData();
            await addressData.DeleteData();
            await personalInfoData.DeleteData();
            await pictureData.DeleteData();
            await timelineData.DeleteData();
            await commentData.DeleteData();
            await friendRelationshipData.DeleteData();
            await postData.DeleteData();
            await storyData.DeleteData();
            await reactionMarkData.DeleteData();
            await bodyData.DeleteData();

            await personData.MakeData();
            await addressData.MakeData();
            await personalInfoData.MakeData();
            await pictureData.MakeData();
            await timelineData.MakeData();
            await commentData.MakeData();
            await friendRelationshipData.MakeData();
            await postData.MakeData();
            await storyData.MakeData();
            await reactionMarkData.MakeData();
            await bodyData.MakeData();
        }
    }
}