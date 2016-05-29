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
        public class ObjectVoteCounting
        {
            public object CastThis { get; set; } //object will be cast at the controller level to count the number of votes 
            public int numOfVotes { get; set; }
            public ObjectVoteCounting(object ObjectToBeCast)
            {
                CastThis = ObjectToBeCast;
            }
           
        }
        public class CategoryToChannel
        {
            public Category Category { get; set; }
            public ICollection<ObjectVoteCounting> Channels { get; set; }

            public CategoryToChannel(Category theCategory, ICollection<Channel> theChannels)
            {
            //for all objects in theChannels we will cast them to an object to store in our dynamic 
            //data structure ObjectVoteCounting so we can easily counter the number of votes on the controller
                foreach (Channel channel in theChannels)
                {
                    ObjectVoteCounting temp = new ObjectVoteCounting(channel);
                    Channels.Add(temp);
                }
                Category = theCategory;
            }
        }
        public class ChannelToProblem
        {
            public Channel Channel { get; set; }
            public ICollection<ObjectVoteCounting> Problems { get; set; }
            public ChannelToProblem(Channel theChannel, ICollection<Problem> theProblems)
            {

                //for all objects in theChannels we will cast them to an object to store in our dynamic 
                //data structure ObjectVoteCounting so we can easily counter the number of votes on the controller
                foreach (Problem problem in theProblems)
                {
                    ObjectVoteCounting temp = new ObjectVoteCounting(problem);
                    Problems.Add(temp);
                }
                Channel = theChannel;
            }
        }
        public class ChannelToSolution
        {
            public Channel Channel { get; set;}
            public ICollection<ObjectVoteCounting> Solutions { get; set; }

            public ChannelToSolution(Channel theChannel, ICollection<Solution> theSolutions)
            {
                //for all objects in theChannels we will cast them to an object to store in our dynamic 
                //data structure ObjectVoteCounting so we can easily counter the number of votes on the controller
                foreach (Solution solution in theSolutions)
                {
                    ObjectVoteCounting temp = new ObjectVoteCounting(solution);
                    Solutions.Add(temp);
                }
                Channel = theChannel;
            }
    }
    
}