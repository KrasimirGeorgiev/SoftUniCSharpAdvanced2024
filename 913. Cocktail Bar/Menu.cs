namespace CocktailBar
{
    public class Menu
    {
        private List<Cocktail> _cocktails;
        public Menu(int barCapacity)
        {
            BarCapacity = barCapacity;
            _cocktails = new List<Cocktail>();
        }
        public List<Cocktail> Cocktails { get => _cocktails; }

        public int BarCapacity { get; set; }

        public void AddCocktail(Cocktail cocktail)
        {
            if (_cocktails.Any(x => x.Name == cocktail.Name))
            {
                return;
            }

            if (_cocktails.Count < BarCapacity)
            {
                _cocktails.Add(cocktail);
            }
        }

        public bool RemoveCocktail(string name)
        {
            Cocktail cocktail = _cocktails.FirstOrDefault(c => c.Name == name);
            if (cocktail != null)
            {
                _cocktails.Remove(cocktail);
                return true;
            }
            return false;
        }

        public Cocktail GetMostDiverse()
        {
            return _cocktails.OrderByDescending(c => c.Ingredients.Count).FirstOrDefault();
        }

        public string Details(string cocktailName)
        {
            return _cocktails.FirstOrDefault(x => x.Name == cocktailName)?.ToString();
        }

        public string GetAll()
        {
            return $"All Cocktails:" +
               $"{Environment.NewLine}" +
               $"{string.Join(Environment.NewLine, this.Cocktails.OrderBy(x => x.Name).Select(x => x.Name))}";
        }
    }
}
