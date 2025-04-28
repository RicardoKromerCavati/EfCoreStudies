using Core.Entities;
using Core.Repositories;
using System.Diagnostics;

namespace Infrastructure.Repositories
{
	public class BookRepository : BaseRepository<Book>, IBookRepository
	{
		public BookRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
		}

		public void InsertMany(IEnumerable<Book> books)
		{
			var stopwatchAddRange = Stopwatch.StartNew();
			_dbSet.AddRange(books);
			stopwatchAddRange.Stop();

			_applicationDbContext.SaveChanges();
			var milisecondsAddRangeStopwatch = stopwatchAddRange.ElapsedMilliseconds;



			var stopwatchBulkInsert = Stopwatch.StartNew();
			_dbSet.BulkInsert(books); //SaveChanges is not needed because the extension method already calls it.
			stopwatchBulkInsert.Stop();

			var milisecondsBulkInsertStopwatch = stopwatchBulkInsert.ElapsedMilliseconds;

			Debug.WriteLine($"AddRange: {milisecondsAddRangeStopwatch}\nBulkInsert: {milisecondsBulkInsertStopwatch}");

		}
	}
}
