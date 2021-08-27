using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Domain.Model
{
    public abstract class Person
    {
        protected Person(Guid id, string firstName, string lastName, string nickName, PersonalInfo personalInfo, PersonType personType)
        {
            if (Guid.Empty == id)
            {
                throw new ArgumentException("id is a required field.");
            }
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException("firstName is a required field.");
            }
            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException("lastName is a required field.");
            }
            if (string.IsNullOrEmpty(nickName))
            {
                throw new ArgumentException("nickName is a required field.");
            }
            if (!PersonType.IsDefined(personType))
            {
                throw new ArgumentException("The personType has not been defined.");
            }
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
            PersonalInfo = personalInfo;
            PersonType = personType;
        }

        public Guid Id{ get;  private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string NickName { get; private set; }
        public PersonalInfo PersonalInfo { get; private set; }
        public PersonType PersonType { get; private set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        
    }

    public enum PersonType
    {
        User = 1,
        SystemOperater = 2,
        Administrator = 3
    }
}
