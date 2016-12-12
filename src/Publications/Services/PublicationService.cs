﻿using Publications.Models;
using Publications.Models.Entities;
using Publications.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publications.Services
{
    public class PublicationService
    {
        private ApplicationDbContext db;

        public PublicationService(ApplicationDbContext context)
        {
            db = context;
        }
        
        public IEnumerable<PublicationVM> GetAllPublications()
        {
            List<Publication> publications = db.Publications.ToList();
            List<PublicationVM> publicationsVM = new List<PublicationVM>();
            foreach (Publication item in publications)
            {
                publicationsVM.Add(new PublicationVM()
                {
                    Authors = GetAllAuthorsOfPublication(item.PublicationId),
                    Id = item.PublicationId,
                    Type = GetTypeOfPublication(item.PublicationId),
                    CreationDate = GetCreationDateFromPublication(item.PublicationId),
                    Title = GetTitleOfPublication(item.PublicationId)
                });
            }
            return publicationsVM;
        }
        private string GetAuthorById(int id)
        {
            List<Author> authors = (from author in db.Authors where author.AuthorId == id select author).ToList();
            return authors[0].FirstName + " " + authors[0].SecondName;
        }
        private string GetTypeOfPublication(int publicationId)
        {
            List<PublicationTemplate> templates = db.PublicationTemplates.ToList();
            foreach (PublicationTemplate item in templates)
            {
                if ((from pub in item.Publications where pub.PublicationId == publicationId select pub).ToList().Count == 1)
                {
                    return item.Name;
                }
            }
            return null;
        }
        private DateTime GetCreationDateFromPublication(int id)
        {
            List<Publication> publications = (from pub in db.Publications where pub.PublicationId == id select pub).ToList();
            return publications[0].CreationDate;
        }
        private List<string> GetAllAuthorsOfPublication(int publicationId)
        {
            List<AuthorPublication> AuthorPublications = (from ap in db.AuthorPublications where ap.PublicationId == publicationId select ap).ToList();
            List<string> authors = new List<string>();
            foreach (AuthorPublication item in AuthorPublications)
            {
                authors.Add(GetAuthorById(item.AuthorId));
            }
            return authors;            
        }
        private string GetTitleOfPublication(int publicationId)
        {
            return null;
        }


    }
}