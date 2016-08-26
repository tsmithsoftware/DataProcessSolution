using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using EvalServiceLibrary.DataContracts;
using EvalServiceLibrary.Interfaces;

namespace EvalServiceLibrary
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class EvalService:IEvalService
    {
        List<Eval> evals = new List<Eval>();
        public void SubmitEval(Eval eval)
        {
            evals.Add(eval);
        }

        public List<Eval> GetEvals()
        {
            return evals;
        }
    }
}
