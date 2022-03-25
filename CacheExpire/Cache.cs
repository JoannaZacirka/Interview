using System;

namespace pg
{
    public interface ITimeService
    {
        DateTime CurrentTimeLocal();
        DateTime CurrentTimeUTC();
        DateTime CurrentTimeSecondsTrimmedLocal();
        DateTime CurrentTimeSecondsTrimmedUTC();
    }

    public class CacheCleaningPolicy
    {
        /// <summary>
        /// Gets or sets an absolute expiration date for the cache entry.
        /// </summary>
        public DateTimeOffset? AbsoluteExpiration { get; set; }
        /// <summary>
        /// Gets or sets an absolute expiration time, relative to now.
        /// </summary>
        public TimeSpan? AbsoluteExpirationRelativeToNow { get; set; }
        /// <summary>
        /// Gets or sets how long a cache entry can be inactive (e.g. not accessed) before
        ///  it will be removed. This will not extend the entry lifetime beyond the absolute
        ///  expiration (if set).
        /// </summary>
        public TimeSpan? SlidingExpiration { get; set; }
    }

    public class DailyCacheCleaningPolicyFactory
    {
        private readonly TimeSpan _scheduledCleanupTimeLocal = new TimeSpan(3, 30, 0);
        private CacheCleaningPolicy _cacheCleaningPolicy;
        public ITimeService TimeService { get; }

        public DailyCacheCleaningPolicyFactory(ITimeService timeService)
        {
            TimeService = timeService;  
        }
        public CacheCleaningPolicy GetCacheCleaningPolicy()
        {
            if (_cacheCleaningPolicy?.AbsoluteExpiration == null || _cacheCleaningPolicy.AbsoluteExpiration.Value.UtcTicks < TimeService.CurrentTimeUTC().Ticks)
            {
                SetDailyExpirationCachePolicy();
            }

            return _cacheCleaningPolicy;
        }

        private void SetDailyExpirationCachePolicy()
        {
            var cacheCleaningPolicy = new CacheCleaningPolicy();
            var dayShift = 0;
            var now = TimeService.CurrentTimeLocal();
            
            if (now.TimeOfDay > _scheduledCleanupTimeLocal)
            {
                dayShift++;
            }

            cacheCleaningPolicy.AbsoluteExpiration = now.Date.AddDays(dayShift).AddSeconds(_scheduledCleanupTimeLocal.Seconds).ToUniversalTime();

            _cacheCleaningPolicy = cacheCleaningPolicy;
        }
    }

}
