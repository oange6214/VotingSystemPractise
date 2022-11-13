using VotingSystem.Models;

namespace VotingSystem.Database
{
    public interface IVotingSystemPersistance
    {
		void SaveVotingPoll(VotingPoll poll);
        void SaveVote(Vote vote);
        bool VoteExists(Vote vote);
        VotingPoll GetPoll(int pollId);
    }
}
