using VotingSystem.Models;
using Xunit;
using static Xunit.Assert;

namespace VotingSystem.Tests
{
	public class VotingPollTests
	{
		[Fact]
		public void ZeroCountersWhenCreated()
		{
			var poll = new VotingPoll();

			Empty(poll.Counters);
		}
	}
}
