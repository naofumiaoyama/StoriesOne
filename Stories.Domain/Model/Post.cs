﻿using System;
namespace Stories.Domain.Model
{
    public class Post
    {
        public Story Story{ get; set;}
        public string User { get; set;}
        public string Title { get; set; }
    }
}