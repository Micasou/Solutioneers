using Solutioneers.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solutioneers.Models
{
    /*AS the name implies, we must create custom model returns that are a fusion of all of the models we need vision of on this page.
     * Example: We click Solutioneers Category, 
     */
        public class ChannelVoteCounting
        {
            public Channel CastThis { get; set; } //object will be cast at the controller level to count the number of votes 
            public int numOfVotes { get; set; }
            public ChannelVoteCounting(Channel ObjectToBeCast)
            {
                CastThis = ObjectToBeCast;
            }
        }
    public class ProblemVoteCounting
    {
        public Problem CastThis { get; set; } //object will be cast at the controller level to count the number of votes 
        public int numOfVotes { get; set; }
        public ProblemVoteCounting(Problem ObjectToBeCast)
        {
            CastThis = ObjectToBeCast;
        }
    }
    public class SolutionVoteCounting
    {
        public Solution CastThis { get; set; } //object will be cast at the controller level to count the number of votes 
        public int numOfVotes { get; set; }
        public SolutionVoteCounting(Solution ObjectToBeCast)
        {
            CastThis = ObjectToBeCast;
        }
    }
    public class CategoryToChannel
        {
            public Category Category { get; set; }
            public Channel Channel { get; set; }
            public ICollection<ChannelVoteCounting> Channels { get; set; }

            public CategoryToChannel(Category theCategory, ICollection<Channel> theChannels)
            {
            //for all objects in theChannels we will cast them to an object to store in our dynamic 
            //data structure ObjectVoteCounting so we can easily counter the number of votes on the controller
                foreach (Channel channel in theChannels)
                {
                ChannelVoteCounting temp = new ChannelVoteCounting(channel);
                    Channels.Add(temp);
                }
                Channel = new Channel();//We must create this to populate values if the list is empty
                Category = theCategory;
            }
        }
        public class ChannelToProblem
        {
            public Channel Channel { get; set; }
            public Problem Problem { get; set; }
            public ICollection<ProblemVoteCounting> Problems { get; set; }
            public ChannelToProblem(Channel theChannel, ICollection<Problem> theProblems)
            {

                //for all objects in theChannels we will cast them to an object to store in our dynamic 
                //data structure ObjectVoteCounting so we can easily counter the number of votes on the controller
                foreach (Problem problem in theProblems)
                {
                ProblemVoteCounting temp = new ProblemVoteCounting(problem);
                    Problems.Add(temp);
                }
                Problem = new Problem();
                Channel = theChannel;
            }
        }
        public class ChannelToSolution
        {
            public Channel Channel { get; set;}
            public Solution Solution { get; set; }
            public ICollection<SolutionVoteCounting> Solutions { get; set; }

            public ChannelToSolution(Channel theChannel, ICollection<Solution> theSolutions)
            {
                //for all objects in theChannels we will cast them to an object to store in our dynamic 
                //data structure ObjectVoteCounting so we can easily counter the number of votes on the controller
                foreach (Solution solution in theSolutions)
                {
                    SolutionVoteCounting temp = new SolutionVoteCounting(solution);
                    Solutions.Add(temp);
                }
                Solution = new Solution();
                Channel = theChannel;
            }
    }
    
}