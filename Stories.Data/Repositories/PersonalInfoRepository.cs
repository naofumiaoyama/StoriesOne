﻿using Stories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Repositories
{
    public class PersonalInfoRepository : IPersonalInfoRepository
    {
        protected DatabaseContext _context;

        public PersonalInfoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(PersonalInfo personalInfo)
        {
            await _context.AddAsync(personalInfo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(PersonalInfo personalInfo)
        {
            _context.Remove(personalInfo);
            await _context.SaveChangesAsync();
        }

        public async Task<PersonalInfo> Get(Guid PersonId)
        {
            return await _context.PersonalInfos.FindAsync(PersonId);
        }
         
        public async Task Update(PersonalInfo personalInfo)
        {
            _context.PersonalInfos.Update(personalInfo);
            await _context.SaveChangesAsync();
        }     
    }
}
