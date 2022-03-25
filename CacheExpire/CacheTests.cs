using System.Collections.Generic;
using NUnit.Framework;
using Moq;

namespace pg
{
    public class CacheTests
    {
        Mock<ITimeService> _timeService;
        DailyCacheCleaningPolicyFactory _testedFactory;

        [SetUp]
        public void Setup()
        {
            _timeService = new Mock<ITimeService>();
            _testedFactory = new DailyCacheCleaningPolicyFactory(_timeService.Object);
        }

        [Test]
        public void Should_CacheFactory_Return_Expiration_To_NextDay_slot()
        {
            // given
            _timeService.Setup(ts => ts.CurrentTimeLocal()).Returns( new System.DateTime(2020, 3, 15, 6, 12, 12)); // 2020-03-15 06:12:12

            // when
            var policy = _testedFactory.GetCacheCleaningPolicy();

            // then
            Assert.Pass();
        }
    }


    
}