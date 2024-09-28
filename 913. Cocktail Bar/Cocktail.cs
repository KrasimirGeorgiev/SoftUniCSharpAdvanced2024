namespace CocktailBar
{
    public class Cocktail
    {
        private List<string> _ingredients;

        public Cocktail(string name, decimal price, double volume, string ingredients)
        {
            Name = name;
            Price = price;
            Volume = volume;
            _ingredients = ingredients.Split(", ").ToList();
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public double Volume { get; set; }

        public List<string> Ingredients { get => _ingredients; }

        public override string ToString()
        {
            return $"{Name}, Price: {Price:F2} BGN, Volume: {Volume} ml{Environment.NewLine}Ingredients: {string.Join(", ", Ingredients)}";
        }
    }
}
