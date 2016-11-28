﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publications.Models.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public AcademicDegree AcademicDegree { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
