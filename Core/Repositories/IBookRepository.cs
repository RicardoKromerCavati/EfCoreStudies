using Core.Entities;

namespace Core.Repositories;

public interface IBookRepository : IRepository<Book>
{
	void InsertMany(IEnumerable<Book> books);
}
