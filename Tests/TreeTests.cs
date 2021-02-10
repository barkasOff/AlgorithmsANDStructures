using System;
using Algorithms;
using Structures;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class                            TreeTests
    {
        private List<int>                   _inOrder = new List<int>();
        private readonly ITestOutputHelper  _testOutputHelper;

        public TreeTests(ITestOutputHelper testOutputHelper) =>
            _testOutputHelper = testOutputHelper;
        
        [Fact]
        public void                          Test()
        {
            var tree = new TreeTraversal<int>();
            var resList = new List<int>();
            var resAdd = false;
            var resRemove = false;
            var clearRemove = false;

            Init(tree, resList);
            resAdd = InOrderTest(tree, resList, "Сортировка или добавление");

            tree.Remove(11);
            resList.Remove(11);
            resRemove = InOrderTest(tree, resList, "\nУдаление - 11");
            Init(tree, resList);
            tree.Remove(60);
            resList.Remove(60);
            resRemove = InOrderTest(tree, resList, "\nУдаление - 60");
            Init(tree, resList);
            tree.Remove(35);
            resList.Remove(35);
            resRemove = InOrderTest(tree, resList, "\nУдаление - 35");
            Init(tree, resList);
            tree.Remove(68);
            resList.Remove(68);
            resRemove = InOrderTest(tree, resList, "\nУдаление - 68");
            Init(tree, resList);
            tree.Remove(42);
            resList.Remove(42);
            resRemove = InOrderTest(tree, resList, "\nУдаление - 42");
            Init(tree, resList);
            tree.Remove(17);
            resList.Remove(17);
            resRemove = InOrderTest(tree, resList, "\nУдаление - 17");
            
            try
            {
                tree.Clear();
                resList.Clear();
                clearRemove = InOrderTest(tree, resList, "\nОчищение");
            }
            catch (Exception ex)
            {
                if (ex.Message == "Дерево не содержит элементов!!")
                    clearRemove = true;
            }

            Assert.True(resAdd, "Ошибка в сортировке или добавлении!!");
            Assert.True(resRemove, "Ошибка в удалении!!");
            Assert.True(clearRemove, "Ошибка очищения!!");
        }

        private bool                        InOrderTest(TreeTraversal<int> tree, List<int> resList, string info)
        {
            var res = true;

            _inOrder.Clear();
            _testOutputHelper.WriteLine(info);
            tree.InOrderTraversal(AddToList);
            _testOutputHelper.WriteLine($"{tree.Count}. {_inOrder.Count} {resList.Count}");
            for (int i = 0; i < resList.Count; ++i)
            {
                _testOutputHelper.WriteLine($"{i + 1}. {_inOrder[i]} - {resList[i]}");
                if (_inOrder[i] != resList[i])
                    res = false;
            }
            return (res);
        }
        private void                        Init(TreeTraversal<int> tree, List<int> resList)
        {
            tree.Clear();
            resList.Clear();
            #region resList Add

            resList.PushBack(11);
            resList.PushBack(17);
            resList.PushBack(23);
            resList.PushBack(24);
            resList.PushBack(25);
            resList.PushBack(35);
            resList.PushBack(42);
            resList.PushBack(60);
            resList.PushBack(68);
            resList.PushBack(68);
            resList.PushBack(69);
            resList.PushBack(76);

            #endregion
            #region tree Add

            tree.Add(60);
            tree.Add(35);
            tree.Add(17);
            tree.Add(11);
            tree.Add(24);
            tree.Add(23);
            tree.Add(42);
            tree.Add(76);
            tree.Add(68);
            tree.Add(68);
            tree.Add(69);
            tree.Add(25);

            #endregion
        }
        private void                         AddToList(int data) =>
            _inOrder.PushBack(data);
    }
}
