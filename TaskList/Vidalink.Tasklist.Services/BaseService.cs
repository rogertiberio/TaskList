using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidalink.Tasklist.Repository;
using Vidalink.Tasklist.Services.Interface;

namespace Vidalink.Tasklist.Services
{
    public class BaseService<T>
       : IDisposable, IBaseService<T> where T : class
    {

        private BaseRepository<T> _repository = new BaseRepository<T>();

        public T Find(int id)
        {
            return _repository.Find(id);
        }

        public IQueryable<T> List()
        {
            return _repository.List();
        }

        public void Add(T item)
        {
            try
            {
                _repository.Add(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(T item)
        {
            try
            {
                _repository.Remove(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(int item)
        {
            try
            {
                T itemDatabase = this.Find(item);

                if (itemDatabase == null)
                    throw new Exception("Record not found by id");

                this.Remove(itemDatabase);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual void Edit(T item)
        {
            _repository.Edit(item);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
