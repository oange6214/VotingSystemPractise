using VotingSystem.Models;
using Xunit;
using static Xunit.Assert;

namespace VotingSystem.Tests
{
	public class CounterManagerTests
	{
		public const string CounterName = "Counter Name";
		public Counter _counter = new Counter
		{
			Name = CounterName, 
			Count = 5
		};

		[Fact]
		public void HasName()
		{
			Equal(CounterName, _counter.Name);
		}

		[Fact]
		public void GetStatistics_IncludesCounterName()
		{
			var statistics = new CounterManager().GetStatistics(_counter, 5);
			Equal(CounterName, statistics.Name);
		}

		[Fact]
		public void GetStatistics_IncludesCounterCount()
		{
			var statistics = new CounterManager().GetStatistics(_counter, 5);
			Equal(5, statistics.Count);
		}

		[Theory]
		[InlineData(5, 10, 50)]
		[InlineData(1, 3, 33.33)] 
		[InlineData(2, 3, 66.67)]
		[InlineData(2, 8, 25)]
		public void GetStatistics_ShowPercentageUpToTwoDeciamlsBasedOnTotalCount(int count, int total, double expected)
		{
			_counter.Count = count;
			var statistics = new CounterManager().GetStatistics(_counter, total);
			Equal(expected, statistics.Percent);
		}

		[Fact]
		public void ResolveExcess_DoesnAddExcessWhenAllCountersAreEqual()
		{
			var counter1 = new Counter { Count = 1, Percent = 33.33 };
			var counter2 = new Counter { Count = 1, Percent = 33.33 };
			var counter3 = new Counter { Count = 1, Percent = 33.33 };
			var counters = new List<Counter> { counter1, counter2, counter3 };

			new CounterManager().ResolveExcess(counters);

			Equal(33.33, counter1.Percent);
			Equal(33.33, counter2.Percent);
			Equal(33.33, counter3.Percent);
		}

		[Theory]
		[InlineData(66.66, 66.67, 33.33)]
		[InlineData(66.65, 66.67, 33.33)]
		[InlineData(66.65, 66.68, 33.32)]
		public void ResolveExcess_AddsExcessToHighestCounter(double initial, double expected, double lowest)
		{
			var counter1 = new Counter { Percent = initial };
			var counter2 = new Counter { Percent = lowest };
			var counters = new List<Counter> { counter1, counter2 };

			new CounterManager().ResolveExcess(counters);

			Equal(expected, counter1.Percent);
			Equal(lowest, counter2.Percent);

			var counter3 = new Counter { Percent = initial };
			var counter4 = new Counter { Percent = lowest };
			counters = new List<Counter> { counter4, counter3 };

			new CounterManager().ResolveExcess(counters);

			Equal(expected, counter3.Percent);
			Equal(lowest, counter4.Percent);
		}

		[Theory]
		[InlineData(11.11, 11.12, 44.44)]
		[InlineData(11.10, 11.12, 44.44)]
		public void ResolveExcess_AddsExcessToLowestCounterWhenMoreThanOneHighestCounters(double initial, double expected, double highest)
		{
			var counter1 = new Counter { Percent = highest };
			var counter2 = new Counter { Percent = highest };
			var counter3 = new Counter { Percent = initial };
			var counters = new List<Counter> { counter1, counter2, counter3 };

			new CounterManager().ResolveExcess(counters);

			Equal(highest, counter1.Percent);
			Equal(highest, counter2.Percent);
			Equal(expected, counter3.Percent);
		}

		[Fact]
		public void ResolveExcess_DoesntAddExcessIfTotalPercentIs100()
		{
			var counter1 = new Counter { Percent = 80 };
			var counter2 = new Counter { Percent = 20 };
			var counters = new List<Counter> { counter1, counter2 };

			new CounterManager().ResolveExcess(counters);

			Equal(80, counter1.Percent);
			Equal(20, counter2.Percent);
		}

	}
}