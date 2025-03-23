namespace ShopGenericsExmpale
{
	// Covariant repository interface (out)
	public interface IRepository<out T>
	{
		T GetById(Guid id);
		IEnumerable<T> GetAll();
	}

	// Contravariant service interface (in)
	public interface IService<in T>
	{
		void Process(T item);
	}

	// Base entity
	public abstract class Entity
	{
		public Guid Id { get; } = Guid.NewGuid();
	}

	// Specific entity: Product
	public class Product : Entity
	{
		public string Name { get; }
		public decimal Price { get; private set; }

		public Product(string name, decimal price)
		{
			Name = name;
			Price = price;
		}

		public void ApplyDiscount(decimal percentage)
		{
			Price -= Price * (percentage / 100);
		}
	}

	// Generic repository implementation
	public class Repository<T> : IRepository<T> where T : Entity
	{
		protected readonly List<T> _items = new();

		public void Add(T item)
		{
			_items.Add(item);
		}

		public T GetById(Guid id) => _items.FirstOrDefault(item => item.Id == id);

		public IEnumerable<T> GetAll() => _items;
	}

	// Service for processing discounts
	public class DiscountService : IService<Product>
	{
		private readonly decimal _discountRate;

		public DiscountService(decimal discountRate)
		{
			_discountRate = discountRate;
		}

		public void Process(Product product)
		{
			product.ApplyDiscount(_discountRate);
			Console.WriteLine($"Applied {_discountRate}% discount to {product.Name}, new price: {product.Price:C}");
		}
	}

	// Cart class with generic constraints
	public class ShoppingCart<T> where T : Product
	{
		private readonly List<T> _cartItems = new();

		public void AddToCart(T product)
		{
			_cartItems.Add(product);
			Console.WriteLine($"Added {product.Name} to cart.");
		}

		public decimal CalculateTotal()
		{
			return _cartItems.Sum(p => p.Price);
		}

		public void Checkout(IService<T> service)
		{
			foreach (var item in _cartItems)
			{
				service.Process(item);
			}
			Console.WriteLine($"Total after discount: {CalculateTotal():C}");
		}
	}

	// Main program
	class ShopGenerics
	{
		public static void Test()
		{
			var productRepo = new Repository<Product>();
			productRepo.Add(new Product("Laptop", 1000));
			productRepo.Add(new Product("Smartphone", 500));
			productRepo.Add(new Product("Headphones", 100));
			Entity ent = new Product("pr 1", 22);
			

			IRepository<Entity> entityRepo = productRepo; // Covariance

			Console.WriteLine("Product List:");
			foreach (var entity in entityRepo.GetAll())
			{
				if (entity is Product product)
					Console.WriteLine($"- {product.Name}: {product.Price:C}");
			}

			Console.WriteLine("\nAdding products to cart...");
			var cart = new ShoppingCart<Product>();
			foreach (var product in productRepo.GetAll())
			{
				cart.AddToCart(product);
			}

			Console.WriteLine("\nApplying discount...");
			var discountService = new DiscountService(10); // 10% discount
			cart.Checkout(discountService);
		}
	}

}
