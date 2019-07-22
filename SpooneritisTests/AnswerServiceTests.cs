using NUnit.Framework;
using SpooneritisMobile.Services;

namespace Tests
{
    public class Tests
    {
        private IAnswerService _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new AnswerService();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}