using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.Models.Domain
{
    public class Recipe
    {
        public int Id { get; protected set; }
        [Required]
        public int AuthorId { get; protected set; }
        [Required]
        public string Name { get; protected set; }
        [MaxLength(255)]
        public string ShortDescription { get; protected set; }
        public string Description { get; protected set; }
        [Required]
        public short NeededTimeMinutes { get; protected set; }
        public DateTime DateOfLastModification { get; protected set; }
        public string MainImageUrl {get; protected set; }
        public bool IsPrivate { get; set; }

        protected Recipe() { }

        public Recipe(int authorId, string name, string shortDescription, string description, short neededTimeMinutes, bool isPrivate = false, string mainImageUrl = "")
        {
            AuthorId = authorId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            ShortDescription = shortDescription;
            Description = description;
            NeededTimeMinutes = neededTimeMinutes;
            MainImageUrl = mainImageUrl;
            IsPrivate = isPrivate;
            DateOfLastModification = DateTime.UtcNow;
        }
    }
}
