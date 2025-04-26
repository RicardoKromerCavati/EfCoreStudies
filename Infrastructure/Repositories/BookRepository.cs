using Core.Entities;
using Core.Repositories;

namespace Infrastructure.Repositories
{
	public class BookRepository : BaseRepository<Book>, IBookRepository
	{
		public BookRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
		}
	}
}
