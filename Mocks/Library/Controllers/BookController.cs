using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepository _repository;

        public BookController(IRepository repository)
        {
            _repository = repository;
        }

        public int Create(Book book)
        {
            return _repository.Create(book);
        }

        public IList<Book> GetAll()
        {
            return _repository.GetAll();
        }

        public Book GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public bool Update(Book book)
        {
            return _repository.Update(book);
        }
    }
}
