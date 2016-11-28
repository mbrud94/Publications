﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publications.Models.Entities
{
    public class Publication
    {
        public int PublicationId { get; set; }
        public DateTime CreationDate { get; set; }

        public List<BranchOfKnowledgePublication> BranchOfKnowledgePublication { get; set; }
        public List<AuthorPublication> AuthorPublication { get; set; }
    }
}
