using NUnit.Framework;
using System.Linq;

namespace SegmentTree.Test
{
    public class Test_Add
    {
        private int n=5;
        private SegmentTree<int>seg;
        private int[]a={24,1,34,4,3};

        [SetUp]
        public void SetUp()
        {
            seg = new SegmentTree<int>(n,0,(x,y)=>x+y);
            for(int i=0;i<n;i++)seg[i]=a[i];
        }

        [TestCase(1,1)]
        [TestCase(0,2)]
        [TestCase(2,3)]
        [TestCase(1,5)]
        public void SegmentTree_QueryShould_ReturnsTheSameResultAsABruteForceAlgorithm
            (int l,int r)
        {
            Assert.That(seg.Query(l,r),Is.EqualTo(a[l..r].AsEnumerable().Sum()));
        }

        [TestCase(1)]
        [TestCase(4)]
        public void SegmentTree_IndexerShould_ReturnsTheSameResultAsWithAnArray
            (int i)
        {
            Assert.That(seg[i],Is.EqualTo(a[i]));
        }


        [Test]
        public void SegmentTree_AssignmentViaIndexerShould_ChangeTheResultOfQueryAndIndexer
        (
            [Random(0, 5, 2)]int i,
            [Random(-30, 30, 2)]int value,
            [Random(0, 5, 2)]int j,
            [Random(0, 5, 2)]int l,
            [Random(0, 5, 12)]int r
        )
        {
            if(r<l)Swap(ref l, ref r);
            int was=seg[i];
            seg[i]=value;
            a[i]=value;
            Assert.That(seg[j],Is.EqualTo(a[j]));
            Assert.That(seg.Query(l,r),Is.EqualTo(a[l..r].AsEnumerable().Sum()));
        }

        [Test]
        public void SegmentTree_AddAssignmentViaIndexerShould_ChangeTheResultOfQueryAndIndexer
        (
            [Random(0, 5, 2)]int i,
            [Random(-30, 30, 2)]int value,
            [Random(0, 5, 2)]int j,
            [Random(0, 5, 2)]int l,
            [Random(0, 5, 12)]int r
        )
        {
            if(r<l)Swap(ref l, ref r);
            int was=seg[i];
            seg[i]+=value;
            a[i]+=value;
            Assert.That(seg[j],Is.EqualTo(a[j]));
            Assert.That(seg.Query(l,r),Is.EqualTo(a[l..r].AsEnumerable().Sum()));
        }

        [Test]
        public void SegmentTree_SubAssignmentViaIndexerShould_ChangeTheResultOfQueryAndIndexer
        (
            [Random(0, 5, 2)]int i,
            [Random(-30, 30, 2)]int value,
            [Random(0, 5, 2)]int j,
            [Random(0, 5, 2)]int l,
            [Random(0, 5, 12)]int r
        )
        {
            if(r<l)Swap(ref l, ref r);
            int was=seg[i];
            seg[i]-=value;
            a[i]-=value;
            Assert.That(seg[j],Is.EqualTo(a[j]));
            Assert.That(seg.Query(l,r),Is.EqualTo(a[l..r].AsEnumerable().Sum()));
        }

        [Test]
        public void SegmentTree_MulAssignmentViaIndexerShould_ChangeTheResultOfQueryAndIndexer
        (
            [Random(0, 5, 2)]int i,
            [Random(-3, 3, 2)]int value,
            [Random(0, 5, 2)]int j,
            [Random(0, 5, 2)]int l,
            [Random(0, 5, 12)]int r
        )
        {
            if(r<l)Swap(ref l, ref r);
            int was=seg[i];
            seg[i]*=value;
            a[i]*=value;
            Assert.That(seg[j],Is.EqualTo(a[j]));
            Assert.That(seg.Query(l,r),Is.EqualTo(a[l..r].AsEnumerable().Sum()));
        }

        private void Swap(ref int x, ref int y){
            int z=x;
            x=y;
            y=z;
        }
    }


    public class Test_Min
    {
        private int n=5;
        private SegmentTree<int>seg;
        private int[]a={24,1,34,4,3};

        [SetUp]
        public void SetUp()
        {
            seg = new SegmentTree<int>(n,int.MaxValue,(x,y)=>System.Math.Min(x,y));
            for(int i=0;i<n;i++)seg[i]=a[i];
        }

        [TestCase(1,1)]
        [TestCase(0,2)]
        [TestCase(2,3)]
        [TestCase(1,5)]
        public void SegmentTree_QueryShould_ReturnsTheSameResultAsABruteForceAlgorithm
            (int l,int r)
        {
            Assert.That(seg.Query(l,r),Is.EqualTo(l==r?int.MaxValue:a[l..r].AsEnumerable().Min()));

        }

        [TestCase(1)]
        [TestCase(4)]
        public void SegmentTree_IndexerShould_ReturnsTheSameResultAsWithAnArray
            (int i)
        {
            Assert.That(seg[i],Is.EqualTo(a[i]));
        }


        [Test]
        public void SegmentTree_AssignmentViaIndexerShould_ChangeTheResultOfQueryAndIndexer
        (
            [Random(0, 5, 2)]int i,
            [Random(-30, 30, 2)]int value,
            [Random(0, 5, 2)]int j,
            [Random(0, 5, 2)]int l,
            [Random(0, 6, 12)]int r
        )
        {
            if(r<l)Swap(ref l, ref r);
            int was=seg[i];
            seg[i]=value;
            a[i]=value;
            Assert.That(seg[j],Is.EqualTo(a[j]));
            int expecded=l==r?int.MaxValue:a[l..r].AsEnumerable().Min();
            Assert.That(seg.Query(l,r),Is.EqualTo(expecded));
        }

        [Test]
        public void SegmentTree_AddAssignmentViaIndexerShould_ChangeTheResultOfQueryAndIndexer
        (
            [Random(0, 5, 2)]int i,
            [Random(-30, 30, 2)]int value,
            [Random(0, 5, 2)]int j,
            [Random(0, 5, 2)]int l,
            [Random(0, 6, 12)]int r
        )
        {
            if(r<l)Swap(ref l, ref r);
            int was=seg[i];
            seg[i]+=value;
            a[i]+=value;
            Assert.That(seg[j],Is.EqualTo(a[j]));
            Assert.That(seg.Query(l,r),Is.EqualTo(l==r?int.MaxValue:a[l..r].AsEnumerable().Min()));
        }

        [Test]
        public void SegmentTree_SubAssignmentViaIndexerShould_ChangeTheResultOfQueryAndIndexer
        (
            [Random(0, 5, 2)]int i,
            [Random(-30, 30, 2)]int value,
            [Random(0, 5, 2)]int j,
            [Random(0, 5, 2)]int l,
            [Random(0, 6, 12)]int r
        )
        {
            if(r<l)Swap(ref l, ref r);
            int was=seg[i];
            seg[i]-=value;
            a[i]-=value;
            Assert.That(seg[j],Is.EqualTo(a[j]));
            Assert.That(seg.Query(l,r),Is.EqualTo(l==r?int.MaxValue:a[l..r].AsEnumerable().Min()));
        }

        [Test]
        public void SegmentTree_MulAssignmentViaIndexerShould_ChangeTheResultOfQueryAndIndexer
        (
            [Random(0, 5, 2)]int i,
            [Random(-3, 3, 2)]int value,
            [Random(0, 5, 2)]int j,
            [Random(0, 5, 2)]int l,
            [Random(0, 6, 12)]int r
        )
        {
            if(r<l)Swap(ref l, ref r);
            int was=seg[i];
            seg[i]*=value;
            a[i]*=value;
            Assert.That(seg[j],Is.EqualTo(a[j]));
            Assert.That(seg.Query(l,r),Is.EqualTo(l==r?int.MaxValue:a[l..r].AsEnumerable().Min()));
        }

        private void Swap(ref int x, ref int y){
            int z=x;
            x=y;
            y=z;
        }
    }

    public class Test_LongMin
    {
        private int n=5;
        private SegmentTree<long>seg;
        private long[]a={24,1,34,4,3};

        [SetUp]
        public void SetUp()
        {
            seg = new SegmentTree<long>(n,long.MaxValue,(x,y)=>System.Math.Min(x,y));
            for(int i=0;i<n;i++)seg[i]=a[i];
        }

        [TestCase(1,1)]
        [TestCase(0,2)]
        [TestCase(2,3)]
        [TestCase(1,5)]
        public void SegmentTree_QueryShould_ReturnsTheSameResultAsABruteForceAlgorithm
            (int l,int r)
        {
            Assert.That(seg.Query(l,r),Is.EqualTo(l==r?long.MaxValue:a[l..r].AsEnumerable().Min()));

        }

        [TestCase(1)]
        [TestCase(4)]
        public void SegmentTree_IndexerShould_ReturnsTheSameResultAsWithAnArray
            (int i)
        {
            Assert.That(seg[i],Is.EqualTo(a[i]));
        }


        [Test]
        public void SegmentTree_AssignmentViaIndexerShould_ChangeTheResultOfQueryAndIndexer
        (
            [Random(0, 5, 2)]int i,
            [Random(-30, 30, 2)]long value,
            [Random(0, 5, 2)]int j,
            [Random(0, 5, 2)]int l,
            [Random(0, 6, 12)]int r
        )
        {
            if(r<l)Swap(ref l, ref r);
            long was=seg[i];
            seg[i]=value;
            a[i]=value;
            Assert.That(seg[j],Is.EqualTo(a[j]));
            long expecded=l==r?long.MaxValue:a[l..r].AsEnumerable().Min();
            Assert.That(seg.Query(l,r),Is.EqualTo(expecded));
        }

        [Test]
        public void SegmentTree_AddAssignmentViaIndexerShould_ChangeTheResultOfQueryAndIndexer
        (
            [Random(0, 5, 2)]int i,
            [Random(-30, 30, 2)]long value,
            [Random(0, 5, 2)]int j,
            [Random(0, 5, 2)]int l,
            [Random(0, 6, 12)]int r
        )
        {
            if(r<l)Swap(ref l, ref r);
            long was=seg[i];
            seg[i]+=value;
            a[i]+=value;
            Assert.That(seg[j],Is.EqualTo(a[j]));
            Assert.That(seg.Query(l,r),Is.EqualTo(l==r?long.MaxValue:a[l..r].AsEnumerable().Min()));
        }

        [Test]
        public void SegmentTree_SubAssignmentViaIndexerShould_ChangeTheResultOfQueryAndIndexer
        (
            [Random(0, 5, 2)]int i,
            [Random(-30, 30, 2)]long value,
            [Random(0, 5, 2)]int j,
            [Random(0, 5, 2)]int l,
            [Random(0, 6, 12)]int r
        )
        {
            if(r<l)Swap(ref l, ref r);
            long was=seg[i];
            seg[i]-=value;
            a[i]-=value;
            Assert.That(seg[j],Is.EqualTo(a[j]));
            Assert.That(seg.Query(l,r),Is.EqualTo(l==r?long.MaxValue:a[l..r].AsEnumerable().Min()));
        }

        [Test]
        public void SegmentTree_MulAssignmentViaIndexerShould_ChangeTheResultOfQueryAndIndexer
        (
            [Random(0, 5, 2)]int i,
            [Random(-3, 3, 2)]long value,
            [Random(0, 5, 2)]int j,
            [Random(0, 5, 2)]int l,
            [Random(0, 6, 12)]int r
        )
        {
            if(r<l)Swap(ref l, ref r);
            long was=seg[i];
            seg[i]*=value;
            a[i]*=value;
            Assert.That(seg[j],Is.EqualTo(a[j]));
            Assert.That(seg.Query(l,r),Is.EqualTo(l==r?long.MaxValue:a[l..r].AsEnumerable().Min()));
        }

        private void Swap(ref int x, ref int y){
            int z=x;
            x=y;
            y=z;
        }
    }
}
