namespace NunitFrameworkProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            TestContext.Progress.WriteLine("Setup completed");
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("Test1 completed");
        }

        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("Test2 completed");
        }

        [Test]
        public void Test3()
        {
            TestContext.Progress.WriteLine("Test 3 completed");
        }

        [TearDown]
        public void CloseBrowser()
        {
            TestContext.Progress.WriteLine("Teardown completed");
        }
    }
}