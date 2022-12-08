namespace Library.Models
{
    public class Book
    {

        private static int _id = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Book(string name, decimal price)
        {
            Id = ++_id;
            Name = name;
            Price = price;
        }
    }
}
