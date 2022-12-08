using Xunit;
using Moq;
using Library.Controllers;
using Library.Models;
using Library.Services;

namespace LibraryTests
{
    public class BookControllerTests
    {
        private List<Book> _books = new List<Book>()
        {
            new Book("The Last Wish", 150),
            new Book("Sword of Destiny", 250),
            new Book("Blood of Elves", 340),
            new Book("Time of Contempt", 660),
            new Book("Baptism of Fire", 410),
            new Book("The Tower of the Swallow", 315)
        };

        [Fact]
        public void GetAll_ReturnsOkResultWithListOfBooks()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(r => r.GetAll()).Returns(_books);
            var controller = new BookController(mock.Object);

            var result = controller.GetAll();

            Assert.Equal(_books, result);
        }

        [Fact]
        public void GetById_ReturnsOkResultWithBook()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(r => r.GetById(3)).Returns(_books[2]);
            var controller = new BookController(mock.Object);

            var result = controller.GetById(3);

            Assert.Equal(_books[2], result);
        }

        [Fact]
        public void Create_ReturnsIdOfNewBook()
        {
            var mock = new Mock<IRepository>();
            var controller = new BookController(mock.Object);
            mock.Setup(r => r.Create(It.IsAny<Book>())).Returns(7);

            var result = controller.Create(new Book("A lady of the lake", 310));

            Assert.Equal(7, result);
        }

        [Fact]
        public void Update_ReturnsTrueWhenUpdated()
        {
            var mock = new Mock<IRepository>();
            var controller = new BookController(mock.Object);
            mock.Setup(r => r.Update(It.IsAny<Book>())).Returns(true);

            var result = controller.Update(new Book("Season of Storms", 210) { Id = 4 });

            Assert.True(result);
        }

        [Fact]
        public void Update_ReturnsFalseWhenBookDontExist() 
        {
            var mock = new Mock<IRepository>();
            var controller = new BookController(mock.Object);
            mock.Setup(r => r.Update(It.IsAny<Book>())).Returns(false);

            var result = controller.Update(new Book("Season of Storms", 210) { Id = 9 });

            Assert.False(result);
        }

        [Fact]
        public void Delete_ReturnsTrueWhenDeleted() 
        {
            var mock = new Mock<IRepository>();
            var controller = new BookController(mock.Object);
            mock.Setup(r => r.Delete(It.IsAny<int>())).Returns(true);

            var result = controller.Delete(4);

            Assert.True(result);
        }

        [Fact]
        public void Delete_ReturnsFalseWhenBookDontExist()
        {
            var mock = new Mock<IRepository>();
            var controller = new BookController(mock.Object);
            mock.Setup(r => r.Delete(It.IsAny<int>())).Returns(false);

            var result = controller.Delete(9);

            Assert.False(result);
        }
    }
}
