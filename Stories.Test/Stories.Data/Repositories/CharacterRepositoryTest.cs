using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stories.Data;
using Stories.Data.Entities;
using Stories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Test.Stories.Data.Repositories
{
    [TestClass]
    public class CharacterRepositoryTest
    {
        [TestMethod]
        public async Task CrudTest()
        {
            using (var context = new DatabaseContext())
            {
                //adding
                GenericRepository<Character> characterRepository = new GenericRepository<Character>(context);
                Character character = new Character();
                character.Id = Guid.Parse("CDAF82B1-3165-4EE2-B632-85C78433C0B2");
                character.StoryId = Guid.Parse("D701ACBD-97D9-437B-A949-A4CF04A33521");
                character.Name = "Romeo and Juliet";
                character.Description = "An age-old vendetta between two powerful families erupts into bloodshed";
                await characterRepository.Add(character);

                //getting
                var getcharacter = await characterRepository.Get(character.Id);
                Assert.AreEqual(getcharacter.Id, character.Id);
                Assert.AreEqual(getcharacter.StoryId, character.StoryId);
                Assert.AreEqual(getcharacter.Name, character.Name);
                Assert.AreEqual(getcharacter.Description, character.Description);

                //updating
                character.Name = "ANN WITH AN E";
                character.Description = " The 13-year-old Anne will transform their lives and eventually the small town in which they live, with her unique spirit, fierce intellect and brilliant imagination.";
                var updatecharacter = await characterRepository.Get(character.Id);
                Assert.AreEqual(updatecharacter.Name, character.Name);
                Assert.AreEqual(updatecharacter.Description, character.Description);

                //Removing
                await characterRepository.Remove(character);
                var resultCharacter = characterRepository.Get(character.Id).Result;
                Assert.AreEqual(resultCharacter, null);
            }
        }
    }
}
