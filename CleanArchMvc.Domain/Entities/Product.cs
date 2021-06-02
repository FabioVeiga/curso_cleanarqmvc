using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid ID, ID must to be greater then zero.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        } 

        private void ValidateDomain(string name, string description, decimal price, int stock, string image){
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is invalid. Name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name. Name must have 3 caracters.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description is invalid. Description is required.");
            DomainExceptionValidation.When(description.Length < 5, "Description is invalid. Description must have 5 caracters");
            DomainExceptionValidation.When(price < 0, "Price is invalid. Price cannot be zero.");
            DomainExceptionValidation.When(stock < 0, "Stock is invalid. Stock cannot be zero.");
            DomainExceptionValidation.When(image?.Length > 200, "Image name is invalid. Too long, image name execeed 200 caracters");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;  
        }
    }
}