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
            if (_root == null)
                throw new NullReferenceException("Дерево не содержит элементов!!");
            RemoveFromNode(_root, data);
            --_count;
        }
        public bool     Contains(T data) =>
            FindNode(data) != null;
        public void     Clear()
        {
            _root = null;
            _count = 0;
        }

        private void    AddToNode(Node dir, T data)
        {
            if (dir.Data.CompareTo(data) == 0)
                ++dir.DataCount;
            else if (dir.Data.CompareTo(data) == 1)
            {
                if (dir.Left != null)
                    AddToNode(dir.Left, data);
                else
                    dir.Left = new Node(data);
            }
            else if (dir.Data.CompareTo(data) == -1)
            {
                if (dir.Right != null)
                    AddToNode(dir.Right, data);
                else
                    dir.Right = new Node(data);
            }
        }
        private void    RemoveFromNode(Node dir, T data, Node prevDir = null)
        {
            if (dir == null)
                throw new NullReferenceException($"Элемент {data} не найден!!");
            else if (dir.Data.CompareTo(data) == 0 && dir.DataCount > 1)
                --dir.DataCount;
            else if (dir.Data.CompareTo(data) == 0)
            {
                if (dir.Left == null && dir.Right == null)
                {
                    if (prevDir == null)
                        dir = null;
                    else if (prevDir.Left != null && prevDir.Left.Data.CompareTo(dir.Data) == 0)
                        prevDir.Left = null;
                    else
                        prevDir.Right = null;
                }
                else if (dir.Left != null && dir.Right == null)
                {
                    if (prevDir == null)
                        _root = _root.Left;
                    else if (prevDir.Left != null && prevDir.Left.Data.CompareTo(data) == 0)
                        prevDir.Left = dir.Left;
                    else
                        prevDir.Right = dir.Left;
                }
                else if (dir.Right != null && dir.Left == null)
                {
                    if (prevDir == null)
                        _root = _root.Right;
                    else if (prevDir.Left != null && prevDir.Left.Data.CompareTo(data) == 0)
                        prevDir.Left = dir.Right;
                    else
                        prevDir.Right = dir.Right;
                }
                else
                {
                    var right = dir.Left;
                    Node prevRight = null;

                    while (right.Right != null)
                    {
                        prevRight = right;
                        right = right.Right;
                    }
                    if (prevDir == null)
                        _root.Data = right.Data;
                    else if (prevDir.Left != null && prevDir.Left.Data.CompareTo(data) == 0)
                        prevDir.Left.Data = right.Data;
                    else
                        prevDir.Right.Data = right.Data;
                    if (prevRight != null)
                        prevRight.Right = right.Left;
                    else if (prevDir != null)
                        dir.Left = right.Left;
                }
            }
            else if (dir.Data.CompareTo(data) == -1)
                RemoveFromNode(dir.Right, data, dir);
            else if (dir.Data.CompareTo(data) == 1)
                RemoveFromNode(dir.Left, data, dir);
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
                    else if (res.Data.CompareTo(data) == 1)
                        res = res.Left;
                    else if (res.Data.CompareTo(data) == -1)
                        res = res.Right;
                }
            }
            return (res);
        }
    }
}