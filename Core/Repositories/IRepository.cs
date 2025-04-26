using Core.Entities;

namespace Core.Repositories
{
	public interface IRepository<T> where T : BaseDatabaseEntity
	{
		IList<T> SelectAll();
		T SelectById(int id);
		void Insert(T entity);
		void Update(T entity);
		bool Delete(int id);
	}
}