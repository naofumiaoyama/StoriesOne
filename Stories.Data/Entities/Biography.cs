﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stories.Data.Entities
{
    public class Biography
    {
        public Guid Id { get; set; }
        public Person Person { get; set; }
        public string LivingPlace { get; set; }
        public string Occupation { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
    }

    public enum MaritalStatus
    {
        Single = 1,
        Married = 2,
        Divorced = 3,
        Windowed = 4,
        Complicated = 5
    }
}
