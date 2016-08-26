using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using EvalServiceLibrary.Client.EvalServiceReference;

namespace EvalServiceLibrary.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            /**ChannelFactory<IEvalServiceChannel> channelFactory = 
                new ChannelFactory<IEvalServiceChannel>("BasicHttpBinding_IEvalService");
            IEvalServiceChannel channel = channelFactory.CreateChannel();**/

            EvalServiceClient channel = new EvalServiceClient("BasicHttpBinding_IEvalService");

            Eval eval = new Eval()
            {
                Submitter = "Aaron",
                TimeSent = DateTime.Now,
                Comments = "Hi!"
            };
            channel.SubmitEval(eval);
            channel.SubmitEval(eval);

            channel.GetEvalsCompleted += Channel_GetEvalsCompleted;
            channel.GetEvalsAsync();
            Console.WriteLine("Waiting...");
            Console.ReadLine();


            Console.ReadLine();
            channel.Close();
        }

        private static void Channel_GetEvalsCompleted(object sender, GetEvalsCompletedEventArgs e)
        {
            Console.WriteLine($"Number of evals: {e.Result.Count}");
        }
    }
}
