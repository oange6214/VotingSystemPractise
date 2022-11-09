using VotingSystem.Models;

namespace VotingSystem.Database
{
    public interface IVotingSystemPersistance
    {
		void SaveVote(Vote vote);
		void SaveVotingPoll(VotingPoll poll);
		bool VoteExists(Vote vote);
	}
}
