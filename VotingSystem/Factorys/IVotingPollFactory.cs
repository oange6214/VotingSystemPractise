using VotingSystem.Models;

namespace VotingSystem.Factorys
{
    public interface IVotingPollFactory
    {
        VotingPoll Create(VotingPollFactory.Request request);
    }
}