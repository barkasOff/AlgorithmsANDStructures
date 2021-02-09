using System;
using Structures;

namespace Algorithms
{
    public class        TreeTraversal<T> : Tree<T>
        where T : IComparable<T>
    {
        public void     PreOrderTraversal(Action<T> action)
        {
            if (_root == null)
                throw new NullReferenceException("Дерево не содержит элементов!!");
            PreOrderTraversal(action, _root);
        }
        public void     PostOrderTraversal(Action<T> action)
        {
            if (_root == null)
                throw new NullReferenceException("Дерево не содержит элементов!!");
            PostOrderTraversal(action, _root);
        }
        public void     InOrderTraversal(Action<T> action)
        {
            if (_root == null)
                throw new NullReferenceException("Дерево не содержит элементов!!");
            InOrderTraversal(action, _root);
        }

        private void    PreOrderTraversal(Action<T> action, Node node)
        {
            if (node != null)
            {
                action(node.Data);
                PreOrderTraversal(action, node.Left);
                PreOrderTraversal(action, node.Right);
            }
        }
        private void    PostOrderTraversal(Action<T> action, Node node)
        {
            if (node != null)
            {
                PreOrderTraversal(action, node.Left);
                PreOrderTraversal(action, node.Right);
                action(node.Data);
            }
        }
        private void    InOrderTraversal(Action<T> action, Node node)
        {
            if (node != null)
            {
                PreOrderTraversal(action, node.Left);
                action(node.Data);
                PreOrderTraversal(action, node.Right);
            }
        }
    }
}
