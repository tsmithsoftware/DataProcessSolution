using System.Collections.Generic;
using System.ServiceModel;
using EvalServiceLibrary.DataContracts;

namespace EvalServiceLibrary.Interfaces
{
    [ServiceContract]
    public interface IEvalService
    {
        [OperationContract]
        void SubmitEval(Eval eval);
        [OperationContract]
        List<Eval> GetEvals();
    }
}
