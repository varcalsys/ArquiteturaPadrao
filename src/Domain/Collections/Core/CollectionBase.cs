using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Collections.Core
{
    public class CollectionBase<T> : ICollection<T> where T: class
    {
        private readonly ICollection<T> _collection;

        public CollectionBase()
        {
            _collection = new Collection<T>();
        }

        public CollectionBase(IList<T> list)
        {
            _collection = new Collection<T>(list);
        }

        public int Count
        {
            get { return _collection.Count; }
        }

        public bool IsReadOnly
        {
            get
            {
                return _collection.IsReadOnly;
            }
        }

        public virtual void Add(T item)
        {
            _collection.Add(item);
        }

        public void AddRange(IEnumerable<T> listOfEntities)
        {
            foreach (var item in listOfEntities)
            {
                Add(item);
            }
        }

        public void Clear()
        {
            _collection.Clear();
        }

        public bool Contains(T item)
        {
           return _collection.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _collection.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        public virtual bool Remove(T item)
        {
            return _collection.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return  GetEnumerator();
        }
    }
}
