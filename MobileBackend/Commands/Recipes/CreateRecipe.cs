namespace MobileBackend.Commands.Recipes
{
    public class CreateRecipe : ICommand
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public short NeededTimeMinutes { get; set; }
    }
}