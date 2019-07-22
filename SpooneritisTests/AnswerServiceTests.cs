using NUnit.Framework;
using SpooneritisMobile.Services;
using Moq;

namespace Tests
{
    public class Tests
    {
        private IAnswerService _sut;

        private readonly ISettingsProvider _mockSettingsProvider = new Mock<ISettingsProvider>().Object;
        private readonly IBaseApiAccessor _mockBaseApiAccessor = new Mock<IBaseApiAccessor>().Object;

        [SetUp]
        public void Setup()
        {
            _sut = new AnswerService(_mockSettingsProvider, _mockBaseApiAccessor);
        }

        [Test]
        public void Thing()
        {
            Assert.IsTrue(true);
        }
    }
}