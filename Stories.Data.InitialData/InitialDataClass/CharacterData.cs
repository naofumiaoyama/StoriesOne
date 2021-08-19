using Stories.Data.Entities;
using Stories.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.InitialData.InitialDataClass
{
   public class CharacterData
    {
        public async Task MakeData()
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<Character> characterRepository = new GenericRepository<Character>(context);
                Character character1 = new Character();
                character1.Id = Guid.Parse("01A6D854-B023-4579-805D-85DCAD1347CA");
                character1.StoryId = Guid.Parse("D701ACBD-97D9-437B-A949-A4CF04A33521");
                character1.Name = "Romeo";
                character1.Description = "Montague family member";
                character1.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                character1.CreateDate = DateTime.Now;
                character1.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                character1.UpdateDate = DateTime.Now;
                await characterRepository.Add(character1);

                Character character2 = new Character();
                character2.Id = Guid.Parse("EF1136E2-F7EE-480E-8362-34043D147372");
                character2.StoryId = Guid.Parse("D701ACBD-97D9-437B-A949-A4CF04A33521");
                character2.Name = "Juliet";
                character2.Description = "Capulet family member";
                character2.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                character2.CreateDate = DateTime.Now;
                character2.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                character2.UpdateDate = DateTime.Now;
                await characterRepository.Add(character2);

                Character character3 = new Character();
                character3.Id = Guid.Parse("C30F23A3-A64B-4019-A888-DC9C239E1CB5");
                character3.StoryId = Guid.Parse("4EADAFCD-7585-492C-A39D-878715441048");
                character3.Name = "Harry Potter";
                character3.Description = " Harry is described as having his father's perpetually untidy black hair, his mother's bright green eyes, and a lightning bolt-shaped scar on his forehead.";
                character3.CreateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                character3.CreateDate = DateTime.Now;
                character3.UpdateUserId = Guid.Parse("019520F8-E48B-4079-84CC-B7F0F5A79C1F");
                character3.UpdateDate = DateTime.Now;

                await characterRepository.Add(character3);
            }
        }

        public async Task DeleteData()   
        {
            using (var context = new DatabaseContext())
            {
                GenericRepository<Character> characterRepository = new GenericRepository<Character>(context);
                var character1 = characterRepository.Get(Guid.Parse("01A6D854-B023-4579-805D-85DCAD1347CA")).Result;
                if (character1 != null) { await characterRepository.Remove(character1); }

                var character2 = characterRepository.Get(Guid.Parse("EF1136E2-F7EE-480E-8362-34043D147372")).Result;
                if (character2 != null) { await characterRepository.Remove(character2); }

                var character3 = characterRepository.Get(Guid.Parse("C30F23A3-A64B-4019-A888-DC9C239E1CB5")).Result;
                if (character3 != null) { await characterRepository.Remove(character3); }

            }
        }

    }
}
