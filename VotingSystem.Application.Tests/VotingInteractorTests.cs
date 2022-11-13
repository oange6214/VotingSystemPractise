using Moq;
using VotingSystem.Database;
using VotingSystem.Models;
using Xunit;

namespace VotingSystem.Application.Tests
{
	public class VotingInteractorTests
	{
		private Mock<IVotingSystemPersistance> _mockPersistance = new Mock<IVotingSystemPersistance>();
		private readonly VotingInteractor _intoractor;
		private readonly Vote _vote;

		public VotingInteractorTests()
		{
			_vote = new Vote { UserId = "a", CounterId = 1 };
			_intoractor = new VotingInteractor(_mockPersistance.Object);
		}

		[Fact]
		public void Vote_PersistsVoteWhenUserHasntVoted()
		{
			_mockPersistance.Setup(x => x.VoteExists(_vote)).Returns(false);

			_intoractor.Vote(_vote);

			_mockPersistance.Verify(x => x.SaveVote(_vote));
		}


		[Fact]
		public void Vote_DoesntPersistsVoteWhenUserAlreadyVoted()
		{
			_mockPersistance.Setup(x => x.VoteExists(_vote)).Returns(true);

			_intoractor.Vote(_vote);

			_mockPersistance.Verify(x => x.SaveVote(_vote), Times.Never);
		}

	}
}
