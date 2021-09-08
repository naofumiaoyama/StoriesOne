using Stories.Data.InitialData.InitialDataClass;
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
                var bookName = args[1];
                PutColumnInfoToExcelFromSQLServer(bookName);
            }
            else if(args[0] == "R" || args[0] == "r")
            {
                var bookName = args[1];
                await ReadExcelToSQLServerAsync(bookName);
            }
        }
        static void PutColumnInfoToExcelFromSQLServer(string bookName)
        {
            ExcelNPoi excelNPoi = new ExcelNPoi();
            excelNPoi.PutColumnInfoFromSQLServer(bookName);
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
            AddressData addressData = new AddressData();
            CommentData commentData = new CommentData();
            FriendRelationshipData friendRelationshipData = new FriendRelationshipData();
            PostData postData = new PostData();
            StoryData storyData = new StoryData();
            ReactionMarkData reactionMarkData = new ReactionMarkData();
            ChapterData chapterData = new ChapterData();
            CharacterData characterData = new CharacterData();
            GenreData genreData = new GenreData();
            NotificationData notificationData = new NotificationData();

            await personData.DeleteData();
            await addressData.DeleteData();
            await personalInfoData.DeleteData();
            await friendRelationshipData.DeleteData();
            await genreData.DeleteData();
            await storyData.DeleteData();
            await postData.DeleteData();
            await commentData.DeleteData();
            await reactionMarkData.DeleteData();
            await chapterData.DeleteData();
            await characterData.DeleteData();
            await notificationData.DeleteData();
            await pictureData.DeleteData();


            await personData.MakeData();
            await addressData.MakeData();
            await personalInfoData.MakeData();
            await pictureData.MakeData();
            await friendRelationshipData.MakeData();
            await genreData.MakeData();
            await storyData.MakeData();
            await postData.MakeData();
            await commentData.MakeData();
            await reactionMarkData.MakeData();
            await chapterData.MakeData();
            await characterData.MakeData();
            await notificationData.MakeData();     
        }
    }
}