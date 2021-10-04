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
            var pictureId = Guid.Parse("5006e057-4682-4ea6-ba61-c1ff7a63492c");
            var picture = await query.Get(pictureId);
            Assert.AreEqual(pictureId, Guid.Parse("5006e057-4682-4ea6-ba61-c1ff7a63492c"));
            Assert.AreEqual(picture.Url, "https://scontent-nrt1-1.xx.fbcdn.net/v/t1.6435-9/197204748_101752262154035_1080203619806412059_n.jpg?_nc_cat=101&ccb=1-3&_nc_sid=8bfeb9&_nc_ohc=WW_QOkcT8R4AX8Cqqpn&_nc_ht=scontent-nrt1-1.xx&oh=c0a48e1a5efcef78cf7324428711d047&oe=60DBD398");
        }
    }
}
