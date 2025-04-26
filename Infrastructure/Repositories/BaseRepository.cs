using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class BaseRepository<T> : IRepository<T> where T : BaseDatabaseEntity
	{
		protected readonly ApplicationDbContext _applicationDbContext;
		protected readonly DbSet<T> _dbSet;

		public BaseRepository(ApplicationDbContext applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
			_dbSet = _applicationDbContext.Set<T>();
		}

		public bool Delete(int id)
		{
			var dbEntity = SelectById(id);

			if (dbEntity is null)
			{
				return false;
			}

			_dbSet.Remove(dbEntity);
			_applicationDbContext.SaveChanges();

			return true;
		}

		public void Insert(T entity)
		{
			_dbSet.Add(entity);
			_applicationDbContext.SaveChanges();
		}

		public IList<T> SelectAll() => _dbSet.ToList();

		public T SelectById(int id) => 
			_dbSet.FirstOrDefault(entity => entity.Id == id);

		public void Update(T entity)
		{
			_dbSet.Update(entity);
			_applicationDbContext.SaveChanges();
		}
	}
}
