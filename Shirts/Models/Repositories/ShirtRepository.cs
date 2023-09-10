using System;
namespace Shirts.Models.Repositories
{
    public static class ShirtRepository
    {
        private static readonly List<Shirt> shirts = new List<Shirt>()
        {
            new Shirt{ShirtId = 1 , Brand = "Levy" , Color = "Blue" , Gender = "Men" , Price = 99.95 , Size = 9},
            new Shirt{ShirtId = 2, Brand = "Gucci", Color = "Black", Gender = "Women", Price = 299.50 , Size = 6 },
            new Shirt{ShirtId = 3, Brand = "Nike", Color = "Orange", Gender ="Men" , Price = 59.98, Size = 8 }
        };

        public static List<Shirt> GetShirts()
        {
            return shirts;
        }

        public static bool ShirtExists(int id)
        {
            return shirts.Any(x => x.ShirtId == id);
        }

        public static Shirt? GetShirtByProperties(string? brand, string? gender, string? color, int? size)
        {
            return shirts.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(brand) &&
            !string.IsNullOrWhiteSpace(x.Brand) &&
            x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(gender) &&
            !string.IsNullOrWhiteSpace(x.Gender) &&
            x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(color) &&
            !string.IsNullOrWhiteSpace(x.Color) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
            size.HasValue &&
            x.Size.HasValue && size.Value == x.Size.Value);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.ShirtId == id);
        }

        public static void CreateShirts(Shirt shirt)
        {
            int maxId = shirts.Max(x => x.ShirtId);
            shirt.ShirtId = maxId + 1;

            shirts.Add(shirt);
        }

        public static void UpdateShirt(Shirt shirt)
        {
            var shirtToUPdate = shirts.First(x => x.ShirtId == shirt.ShirtId);
            shirtToUPdate.Brand = shirt.Brand;
            shirtToUPdate.Color = shirt.Color;
            shirtToUPdate.Gender = shirt.Gender;
            shirtToUPdate.Price = shirt.Price;
            shirtToUPdate.Size = shirt.Size;
        }
        public static void DeleteShirt(int shirtId)
        {
            var shirt = GetShirtById(shirtId);
            if(shirt != null)
            {
                shirts.Remove(shirt);
            }
        }
    }
}

