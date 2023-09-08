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

        public static bool ShirtExists(int id)
        {
            return shirts.Any(x => x.ShirtId == id);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.ShirtId == id);
        }
    }
}

