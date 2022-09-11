using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Technology : Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }    
        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }

        public Technology()
        {
            
        }

        public Technology(int id, int programmingLanguageId, string name, string imageUrl) : this()
        {
            Id = id;
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
            ImageUrl = imageUrl;
        }
    }
}
