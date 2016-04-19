using NUnit.Framework;

namespace ExFunk.Test
{
    [TestFixture]
    public abstract class BaseTest
    {
        public abstract void Arrange();
        public abstract void Act();

        public virtual void Clear()
        {
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            Arrange();
            Act();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Clear();
        }
    }
}