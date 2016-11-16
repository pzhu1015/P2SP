using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Complents.ChatComp
{
    #region ItemCollectionBase

    [Serializable, ComVisible(true)]
    public class ItemCollectionBase<TParent, TItem> :
            ICollection<TItem>,
            IList<TItem>,
            IEnumerable<TItem>,
            ICollection,
            IList,
            IEnumerable
        where TParent : Control
        where TItem : class
    {
        #region 变量

        private List<TItem> _list;
        private TParent _owner;

        #endregion

        #region 构造函数

        protected ItemCollectionBase() { }

        public ItemCollectionBase(TParent owner)
        {
            if (owner == null)
                throw new ArgumentNullException("owner");
            _owner = owner;
        }

        #endregion

        #region 属性

        public virtual TParent Owner
        {
            get { return _owner; }
        }

        internal virtual List<TItem> List
        {
            get
            {
                if (_list == null)
                    _list = new List<TItem>(20);
                return _list;
            }
        }

        #endregion

        #region Public Method

        public virtual void AddRange(TItem[] items)
        {
            foreach (TItem item in items)
            {
                Add(item);
            }
        }

        #endregion

        #region ICollection<TItem> 成员

        public virtual void Add(TItem item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            List.Add(item);
        }

        public virtual void Clear()
        {
            List.Clear();
        }

        public virtual bool Contains(TItem item)
        {
            return List.Contains(item);
        }

        public virtual void CopyTo(TItem[] array, int arrayIndex)
        {
            List.CopyTo(array, arrayIndex);
        }

        public virtual int Count
        {
            get { return List.Count; }
        }

        public virtual bool IsReadOnly
        {
            get { return false; }
        }

        public virtual bool Remove(TItem item)
        {
            return List.Remove(item);
        }

        #endregion

        #region IList<TItem> 成员

        public virtual int IndexOf(TItem item)
        {
            return List.IndexOf(item);
        }

        public virtual void Insert(int index, TItem item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            List.Insert(index, item);
        }

        public virtual void RemoveAt(int index)
        {
            List.RemoveAt(index);
        }

        public virtual TItem this[int index]
        {
            get
            {
                return List[index];
            }
            set
            {
            }
        }

        #endregion

        #region IEnumerable<TItem> 成员

        public virtual IEnumerator<TItem> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成员

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region ICollection 成员

        void ICollection.CopyTo(Array array, int index)
        {
            CopyTo((TItem[])array, index);
        }

        int ICollection.Count
        {
            get { return Count; }
        }

        bool ICollection.IsSynchronized
        {
            get { return false; }
        }

        object ICollection.SyncRoot
        {
            get { return this; }
        }

        #endregion

        #region IList 成员

        int IList.Add(object value)
        {
            TItem item = value as TItem;
            Add(item);
            return List.IndexOf(item);
        }

        void IList.Clear()
        {
            List.Clear();
        }

        bool IList.Contains(object value)
        {
            return Contains(value as TItem);
        }

        int IList.IndexOf(object value)
        {
            return IndexOf(value as TItem);
        }

        void IList.Insert(int index, object value)
        {
            Insert(index, value as TItem);
        }

        bool IList.IsFixedSize
        {
            get { return false; }
        }

        bool IList.IsReadOnly
        {
            get { return IsReadOnly; }
        }

        void IList.Remove(object value)
        {
            Remove(value as TItem);
        }

        void IList.RemoveAt(int index)
        {
            RemoveAt(index);
        }

        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
            }
        }

        #endregion
    }

    #endregion

    #region ItemEventCollectionBase

    [Serializable, ComVisible(true)]
    public abstract class ItemEventCollectionBase<TParent, TItem> : CollectionBase<TItem>
        where TParent : Control
        where TItem : class
    {
        #region Private Field

        private TParent _owner;

        #endregion

        #region Constuctor

        protected ItemEventCollectionBase(TParent owner)
            : base()
        {
            if (owner == null)
                throw new ArgumentNullException("owner");
            _owner = owner;
        }

        #endregion

        #region Event

        public event CollectionChangeEventHandler CollectionChanged;

        #endregion

        #region Property

        public virtual TParent Owner
        {
            get { return _owner; }
        }

        public virtual TItem this[int index]
        {
            get { return InnerList[index]; }
        }

        #endregion

        #region Public Method

        public virtual void Add(TItem item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            if (!List.Contains(item))
                List.Add(item);
        }

        public virtual void AddRange(TItem[] items)
        {
            base.AddRange(items);
        }

        public virtual void Remove(TItem item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            if (Contains(item))
                List.Remove(item);
        }

        public virtual bool Contains(TItem item)
        {
            return List.Contains(item);
        }

        public virtual int IndexOf(TItem item)
        {
            return List.IndexOf(item);
        }

        public virtual void CopyTo(TItem[] items, int index)
        {
            List.CopyTo(items, index);
        }

        public virtual void Insert(int index, TItem item)
        {
            List.Insert(index, item);
        }

        #endregion

        #region Override

        protected virtual void OnCollectionChanged(CollectionChangeEventArgs e)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, e);
            }
        }

        protected override void OnClearComplete()
        {
            base.OnClearComplete();
            OnCollectionChanged(new CollectionChangeEventArgs(
                CollectionChangeAction.Refresh, null));
        }

        protected override void OnInsertComplete(int index, TItem value)
        {
            base.OnInsertComplete(index, value);
            OnCollectionChanged(new CollectionChangeEventArgs(
                CollectionChangeAction.Add, value));
        }

        protected override void OnAddRangeComplete(ICollection<TItem> values)
        {
            base.OnAddRangeComplete(values);
            OnCollectionChanged(new CollectionChangeEventArgs(
                CollectionChangeAction.Add, values));
        }

        protected override void OnSortComplete()
        {
            base.OnSortComplete();
            OnCollectionChanged(new CollectionChangeEventArgs(
                CollectionChangeAction.Refresh, this));
        }

        protected override void OnRemoveComplete(int index, TItem value)
        {
            base.OnRemoveComplete(index, value);
            OnCollectionChanged(new CollectionChangeEventArgs(
                CollectionChangeAction.Remove, value));
        }

        #endregion
    }

    #endregion

    #region CollectionBase

    [Serializable, ComVisible(true)]
    public abstract class CollectionBase<TItem> : IList, ICollection, IEnumerable
        where TItem : class
    {
        #region Private Field

        private List<TItem> _list;
        private IComparer<TItem> _comparer;

        #endregion

        #region Constructor

        protected CollectionBase()
        {
            _list = new List<TItem>();
        }

        protected CollectionBase(int capacity)
        {
            _list = new List<TItem>(capacity);
        }

        #endregion

        #region Property

        [ComVisible(false)]
        public int Capacity
        {
            get
            {
                return InnerList.Capacity;
            }
            set
            {
                InnerList.Capacity = value;
            }
        }

        public int Count
        {
            get
            {
                if (_list != null)
                {
                    return _list.Count;
                }
                return 0;
            }
        }

        public virtual IComparer<TItem> Comparer
        {
            get { return _comparer; }
            set
            {
                _comparer = value;
                try
                {
                    Sort();
                }
                catch
                {
                }
            }
        }

        #endregion

        #region Public Method

        public void RemoveAt(int index)
        {
            if ((index < 0) || (index >= InnerList.Count))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            TItem item = InnerList[index];
            OnValidate(item);
            OnRemove(index, item);
            InnerList.RemoveAt(index);
            try
            {
                OnRemoveComplete(index, item);
            }
            catch
            {
                InnerList.Insert(index, item);
                throw;
            }
        }

        public void AddRange(ICollection<TItem> items)
        {
            if (items == null)
                throw new ArgumentNullException("items");
            OnAddRange(items);
            foreach (TItem item in items)
            {
                Add(item, false);
            }
            OnAddRangeComplete(items);
            try
            {
                Sort();
            }
            catch
            {
            }
        }

        public void Clear()
        {
            OnClear();
            InnerList.Clear();
            OnClearComplete();
        }

        public IEnumerator GetEnumerator()
        {
            return InnerList.GetEnumerator();
        }

        #endregion

        #region Protected Method

        protected virtual void OnSort()
        {
        }

        protected virtual void OnSortComplete()
        {
        }

        protected virtual void OnClear()
        {
        }

        protected virtual void OnClearComplete()
        {
        }

        protected virtual void OnInsert(int index, TItem value)
        {
        }

        protected virtual void OnInsertComplete(int index, TItem value)
        {
        }

        protected virtual void OnAddRange(ICollection<TItem> values)
        {
        }

        protected virtual void OnAddRangeComplete(ICollection<TItem> values)
        {
        }

        protected virtual void OnRemove(int index, TItem value)
        {
        }

        protected virtual void OnRemoveComplete(int index, TItem value)
        {
        }

        protected virtual void OnSet(int index, TItem oldValue, TItem newValue)
        {
        }

        protected virtual void OnSetComplete(int index, TItem oldValue, TItem newValue)
        {
        }

        protected virtual void OnValidate(TItem value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
        }

        public virtual void Sort()
        {
            if (Comparer != null)
            {
                OnSort();
                InnerList.Sort(Comparer);
                OnSortComplete();
            }
        }

        protected virtual int Add(TItem item,bool bEvent)
        {
            OnValidate(item);
            int index = InnerList.Count;
            if(bEvent)
                OnInsert(index, item);
            InnerList.Add(item);
            try
            {
                if (bEvent)
                {
                    OnInsertComplete(index, item);
                }
            }
            catch
            {
                InnerList.RemoveAt(index);
                throw;
            }
            try
            {
                if (bEvent)
                    Sort();
                index = InnerList.IndexOf(item);
            }
            catch
            {
            }
                
            return index;
        }

        #endregion

        #region InterFace Method

        void ICollection.CopyTo(Array array, int index)
        {
            InnerList.CopyTo((TItem[])array, index);
        }

        int IList.Add(object value)
        {
            if (!(value is TItem))
                throw new ArgumentException("value");

            TItem item = value as TItem;
            return Add(item, true);
        }

        bool IList.Contains(object value)
        {
            return InnerList.Contains(value as TItem);
        }

        int IList.IndexOf(object value)
        {
            return InnerList.IndexOf(value as TItem);
        }

        void IList.Insert(int index, object value)
        {
            if ((index < 0) || (index > this.InnerList.Count))
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (!(value is TItem))
                throw new ArgumentException("value");
            TItem item = value as TItem;
            OnValidate(item);
            OnInsert(index, item);
            InnerList.Insert(index, item);
            try
            {
                OnInsertComplete(index, item);
            }
            catch
            {
                InnerList.RemoveAt(index);
                throw;
            }

            try
            {
                Sort();
            }
            catch
            {
            }
        }

        void IList.Remove(object value)
        {
            if(!(value is TItem))
                throw new ArgumentException("value");

            TItem item = value as TItem;
            OnValidate(item);
            int index = InnerList.IndexOf(item);
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            OnRemove(index, item);
            InnerList.RemoveAt(index);
            try
            {
                OnRemoveComplete(index, item);
            }
            catch
            {
                InnerList.Insert(index, item);
                throw;
            }
        }

        protected List<TItem> InnerList
        {
            get
            {
                if (this._list == null)
                {
                    _list = new List<TItem>();
                }
                return _list;
            }
        }

        protected IList List
        {
            get
            {
                return this;
            }
        }

        bool ICollection.IsSynchronized
        {
            get
            {
                return false;
            }
        }

        object ICollection.SyncRoot
        {
            get
            {
                return this;
            }
        }

        bool IList.IsFixedSize
        {
            get
            {
                return false;
            }
        }

        bool IList.IsReadOnly
        {
            get
            {
                return false;
            }
        }

        object IList.this[int index]
        {
            get
            {
                if ((index < 0) || (index >= InnerList.Count))
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                return InnerList[index];
            }
            set
            {
                if ((index < 0) || (index >= InnerList.Count))
                {
                    throw new ArgumentOutOfRangeException("index");
                }

                if(!(value is TItem))
                    throw new ArgumentException();
                TItem item = value as TItem;
                OnValidate(item);
                TItem oldValue = InnerList[index];
                OnSet(index, oldValue, item);
                InnerList[index] = item;
                try
                {
                    OnSetComplete(index, oldValue, item);
                }
                catch
                {
                    InnerList[index] = oldValue;
                    throw;
                }
            }
        }

        #endregion
    }

    #endregion
}
