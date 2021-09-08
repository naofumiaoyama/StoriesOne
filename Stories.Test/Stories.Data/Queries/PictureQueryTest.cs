using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stories.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Test.Stories.Data.Queries
{
    [TestClass]
   public class PictureQueryTest
    {
        [TestMethod]
        public async Task GetTest()
        {
            var query = new PictureQuery();
            var pictureId = Guid.Parse("51DBF583-B594-4B80-A834-1D0AEC118F85");
            var picture = await query.Get(pictureId);
            Assert.AreEqual(pictureId, Guid.Parse("51DBF583-B594-4B80-A834-1D0AEC118F85"));
            Assert.AreEqual(picture.Url, "Https://www.google.com/imgres?imgurl=https%3A%2F%2Fwww.forkknifeswoon.com%2Fwp-content%2Fuploads%2F2014%2F10%2Fsimple-homemade-chicken-ramen-fork-knife-swoon-01.jpg&imgrefurl=https%3A%2F%2Fwww.forkknifeswoon.com%2Fsimple-homemade-chicken-ramen%2F&tbnid=xvuanwzsBotXAM&vet=12ahUKEwi0q92A1t_yAhVK95QKHfbIAT4QMygBegUIARDfAQ..i&docid=Pt4KygPKLwIZ3M&w=690&h=862&itg=1&q=ramen%20pic&ved=2ahUKEwi0q92A1t_yAhVK95QKHfbIAT4QMygBegUIARDfAQ");
        }
    }
}
