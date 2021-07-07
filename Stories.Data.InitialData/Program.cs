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
            PictureData pictureData = new PictureData();
            TimelineData timelineData = new TimelineData();
            AddressData addressData = new AddressData();
            CommentData commentData = new CommentData();
            FriendRelationshipData friendRelationshipData = new FriendRelationshipData();
            PostData postData = new PostData();
            StoryData storyData = new StoryData();

            await personData.DeleteData();
            await personalInfoData.DeleteData();
            await pictureData.DeleteData();
            await timelineData.DeleteData();
            await addressData.DeleteData();
            await commentData.DeleteData();
            await friendRelationshipData.DeleteData();
            await postData.DeleteData();
            await storyData.DeleteData();

            await personData.MakeData();
            await personalInfoData.MakeData();
            await pictureData.MakeData();
            await timelineData.MakeData();
            await addressData.MakeData();
            await commentData.MakeData();
            await friendRelationshipData.MakeData();
            await postData.MakeData();
            await storyData.MakeData();
        }
    }
}