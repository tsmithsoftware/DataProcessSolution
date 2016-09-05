using DataProcessSolution.WorkerRole.Operations;
using Rhino.Etl.Core;
namespace DataProcessSolution.WorkerRole.Processes
{
    public class MainProcess:EtlProcess
    {
        public string NamesFile { get; set; } 
        public string AddressesFile { get; set; } 
        public string OrdersFile { get; set; }
        public string FirstStageOutputFile { get; set; }
        public string SecondStageOutoutFile { get; set; }
        protected override void Initialize()
        {
            Register(new FirstStageJoinUserRecords()
                .Left(new UserNameRead(NamesFile))
                .Right(new UserAddressRead(AddressesFile))
                );

            Register(new FirstStageUserFullWrite(FirstStageOutputFile));

            /**Register(new SecondStageJoinUserRecords()
                .Left(new UserNameRead(NamesFile))
                .Right(new UserAddressRead(AddressesFile))
                );**/

            
            //Register(new SecondStageUserFullWrite(SecondStageOutoutFile));
        }
    }
}
