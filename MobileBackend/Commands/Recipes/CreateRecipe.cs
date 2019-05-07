using System.Text;

namespace MobileBackend.Commands.Recipes
{
    public class CreateRecipe : ICommand
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public short NeededTimeMinutes { get; set; }
        public string MainImageUrl {get; protected set; }
        public bool IsPrivate { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Name: {Name}");
            builder.AppendLine($"ShortDescription: {ShortDescription}");
            builder.AppendLine($"Description: {Description}");
            builder.AppendLine($"NeededTimeMinutes: {NeededTimeMinutes}");
            builder.AppendLine($"IsPrivate: {IsPrivate}");
            builder.AppendLine($"MainImageUrl: {MainImageUrl}");
            return builder.ToString();
        }
    }

    
}