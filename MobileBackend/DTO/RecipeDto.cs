using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileBackend.DTO
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public short NeededTimeMinutes { get; set; }
        public DateTime DateOfLastModification { get; set; }
        public string MainImageUrl { get; set; }
        public bool IsPrivate { get; set; }
    }
}
