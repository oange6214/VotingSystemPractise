using VotingSystem.Database;
using VotingSystem.Models;

namespace VotingSystem.Application
{
	public class VotingIntoractor
	{
		private readonly IVotingSystemPersistance _persistance;

		public VotingIntoractor(IVotingSystemPersistance persistance)
		{
			_persistance = persistance;
		}

		public void Vote(Vote vote)
		{
			if (!_persistance.VoteExists(vote))
			{
				_persistance.SaveVote(vote);
			}
		}
	}
}
