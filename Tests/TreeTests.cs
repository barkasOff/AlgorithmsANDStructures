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
            var resAdd = AddingTest(tree);

            Assert.True(resAdd, "Сортировка не правильная!!");
        }

        private bool                        AddingTest(TreeTraversal<int> tree)
        {
            var resList = new List<int>();
            var res = true;

            #region resList Add

            resList.PushBack(11);
            resList.PushBack(17);
            resList.PushBack(23);
            resList.PushBack(24);
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

            #endregion
            
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

        private void                         AddToList(int data) =>
            _inOrder.PushBack(data);
    }
}
