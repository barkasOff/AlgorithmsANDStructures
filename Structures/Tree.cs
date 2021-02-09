using System;

namespace Structures
{
    public class        Tree<T>
        where T : IComparable<T>
    {
        protected class Node
        {
            public T    Data { get; set; }
            public int  DataCount { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(T data)
            {
                Data = data;
                DataCount = 1;
                Left = null;
                Right = null;
            }
        }
        
        protected Node  _root = null;
        private int     _count = 0;

        public T        Root => _root.Data ?? default(T);
        public int      Count => _count;

        public void     Add(T data)
        {
            if (_root == null)
                _root = new Node(data);
            else
                AddToNode(_root, data);
            ++_count;
        }
        public void     Remove(T data)
        {
            if (!Contains(data))
                throw new NullReferenceException("Дерево не содержит элементов!!");
            RemoveFromNode(_root, data);
            --_count;
        }
        public bool     Contains(T data) =>
            FindNode(data) == null;
        public void     Clear()
        {
            _root = null;
            _count = 0;
        }

        private void    AddToNode(Node dir, T data)
        {
            if (dir == null)
                dir = new Node(data);
            else if (dir.Data.CompareTo(data) == 0)
                ++dir.DataCount;
            else if (dir.Data.CompareTo(data) == -1)
                AddToNode(dir.Left, data);
            else if (dir.Data.CompareTo(data) > 0)
                AddToNode(dir.Right, data);
        }
        private void    RemoveFromNode(Node dir, T data, Node prevDir = null)
        {
            if (dir.Data.CompareTo(data) == 0)
            {
                if (dir.Left == null && dir.Right == null)
                    dir = null;
                else if (dir.Left != null && dir.Right == null)
                    dir = dir.Left;
                else if (dir.Right != null && dir.Left == null)
                    dir = dir.Right;
                else if (dir.Left.Right == null)
                    dir = dir.Left;
                else
                {
                    var right = dir.Left;

                    while (right.Right != null)
                        right = right.Right;
                    dir.Data = right.Data;
                    right = right.Left;
                }
            }
            else if (dir.Data.CompareTo(data) == -1)
                RemoveFromNode(dir.Left, data, dir);
            else if (dir.Data.CompareTo(data) > 0)
                RemoveFromNode(dir.Right, data, dir);
        }
        private Node    FindNode(T data)
        {
            var res = _root;

            if (res != null)
            {
                while (res != null)
                {
                    if (res.Data.CompareTo(data) == 0)
                        break ;
                    else if (res.Data.CompareTo(data) == -1)
                        res = res.Left;
                    else if (res.Data.CompareTo(data) > 0)
                        res = res.Right;
                }
            }
            return (res);
        }
    }
}