using Library.Models;

namespace Library.Services
{
    public interface IRepository
    {
        public IList<Book> GetAll();
        public Book GetById(int id);
        public int Create(Book book);
        public bool Update(Book book);
        public bool Delete(int id);
    }
}
