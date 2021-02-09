using System;
using System.Collections.Generic;

namespace DataStructures.Core
{
    public class                List<T>
        where T : IComparable<T>
    {
        private class           Link
        {
            public T        Data { get; set; }
            public Link     Next { get; set; }

            public Link(T data) =>
                Data = data;
        }

        private int             _count = 0;
        private Link            _head = null;
        private Link            _tail = null;

        public int              Count => _count;

        public void             PushFront(T data)
        {
            var newEl = new Link(data);

            if (_head != null)
                newEl.Next = _head;
            _head = newEl;
            if (Count == 0)
                _tail = newEl;
            ++_count;
        }
        public void             PushBack(T data)
        {
            var newEl = new Link(data);

            if (_head == null)
                _head = newEl;
            else
                _tail.Next = newEl;
            _tail = newEl;
            ++_count;
        }
        public void             InsertBefore(T beforeData, T data)
        {
            var copyHead = _head;
            var newEl = new Link(data);

            if (_head == null)
                PushFront(data);
            else
            {
                while (copyHead.Next.Data.CompareTo(beforeData) != 0 && copyHead != null)
                    copyHead = copyHead.Next;
                if (copyHead == null)
                    throw new NullReferenceException($"Не найден элемент {beforeData}");
                newEl.Next = copyHead.Next;
                copyHead.Next = newEl;
            }
            ++_count;
        }
        public void             InsertAfter(T afterData, T data)
        {
            var copyHead = _head;
            var newEl = new Link(data);

            if (_head == null)
                PushBack(data);
            else
            {
                while (copyHead.Data.CompareTo(afterData) != 0 && copyHead != null)
                    copyHead = copyHead.Next;
                if (copyHead == null)
                    throw new NullReferenceException($"Не найден элемент {afterData}");
                if (copyHead.Next == null)
                    _tail = newEl;
                newEl.Next = copyHead.Next;
                copyHead.Next = newEl;
            }
            ++_count;
        }
        public void             PopFront()
        {
            var copyHead = _head;

            if (copyHead == null)
                throw new NullReferenceException("List пуст");
            _head = copyHead.Next;
            if (_head == null)
                _tail = null;
            --_count;
        }
        public void             PopBack()
        {
            var     copyHead = _head;
            Link    previousLink = null;

            if (copyHead == null)
                throw new NullReferenceException("List пуст");
            while (copyHead.Next != null)
            {
                previousLink = copyHead;
                copyHead = copyHead.Next;
            }
            if (previousLink == null)
                _head = previousLink;
            else
                previousLink.Next = null;
            _tail = previousLink;
            --_count;
        }
        public void             Remove(T data)
        {
            var     currentLink = _head;
            Link    previousLink = null;

            while (currentLink.Data.CompareTo(data) != 0 && currentLink != null)
            {
                previousLink = currentLink;
                currentLink = currentLink.Next;
            }
            if (currentLink == null)
                throw new NullReferenceException($"Элемент {data} не найден");
            if (previousLink == null)
                _head = currentLink.Next;
            else
                previousLink.Next = currentLink.Next;
            if ((previousLink != null && previousLink.Next == null) || _head == null)
                _tail = null;
            --_count;
        }
        public void             Reverse()
        {
            Link    prevList = null;
            Link    currentLink = _head;
            while (currentLink != null)
            {
                var nextLink = currentLink.Next;
                currentLink.Next = prevList;

                prevList = currentLink;
                currentLink = nextLink;
            }
        }
        public void             Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public T                this[int index]
        {
            get => FindLinkByIndex(index).Data;
            set => FindLinkByIndex(index).Data = value;
        }
        public IEnumerator<T>  GetEnumerator()
        {
            var copyHead = _head;

            while (copyHead != null)
            {
                yield return copyHead.Data;
                copyHead = copyHead.Next;
            }
        }

        private Link            FindLinkByIndex(int index)
        {
            var copyHead = _head;

            for (int i = 0; i < index; ++i)
            {
                if (copyHead == null)
                    throw new NullReferenceException("Выход за границы");
                copyHead = copyHead.Next;
            }
            if (copyHead == null)
                throw new NullReferenceException("Выход за границы");
            return (copyHead);
        }
    }
}
