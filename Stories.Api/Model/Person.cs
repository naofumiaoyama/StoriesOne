﻿using System;
namespace Stories.Api.Model
{
    public class Person
    {
        public string ID {get;set;}
        public string GivenName { get; set;}
        public string FamilyName{ get; set; }
        public PersonInfo PersonInfo { get; set; }
        public Address Address { get; set; }
    }
}
