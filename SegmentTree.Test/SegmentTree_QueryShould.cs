using NUnit.Framework;

namespace SegmentTree.Test{
    [TestFixture]
    public class Tests{
        private int n = 5;
        private SegmentTree<int>seg;
        private int[]a={24,1,34,4,3};

        [SetUp]
        public void SetUp(){
            seg = new SegmentTree<int>(n);
        }

        [TestCase(0,2)]
        [TestCase(3,3)]
        [TestCase(1,5)]
        public void SegmentTree_QueryShould_ReturnsTheSameResultToABruteForceAlgorithm(int l, int r){
            int expected=0;
            for(int i=l;i<r;i++)expected+=a[i];
            Assert.That(seg.Query(l,r),Is.EqualTo(expected));
        }
    }
}
