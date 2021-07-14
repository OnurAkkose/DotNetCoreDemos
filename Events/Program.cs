using System;

namespace Events
{
    public class ProductEventArgs : EventArgs
    {
        public ProductDto ProductDto { get; set; }
    }
    public class EventPublisher
    {
        public event EventHandler<ProductEventArgs> ProductCompleted;
        protected virtual void OnProductCompleted(ProductEventArgs e)
        {
            ProductCompleted?.Invoke(this, e);
        }

        public void AddNewItem(ProductDto productDto)
        {
            var data = new ProductEventArgs();
            data.ProductDto = productDto;
            OnProductCompleted(data);
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            EventPublisher publisher = new();
            publisher.ProductCompleted += Publisher_ProductCompleted;
            publisher.AddNewItem(new ProductDto { Id = 1, Name = "Pizza" });
        }
        private static void Publisher_ProductCompleted(object sender, ProductEventArgs e)
        {
            Console.WriteLine("Subscribed to Event");
            Console.WriteLine(e.ProductDto.Name);
        }
    }

    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
