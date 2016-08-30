using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProcessSolution.WorkerRole.Entities;

namespace DataProcessSolution.Tests.Utilities
{
    public class UserFullRecordComparator:IEqualityComparer<UserFullRecord>
    {
        public bool Equals(UserFullRecord recordOne, UserFullRecord recordTwo)
        {
            return recordOne.UserOrder.Equals(recordTwo.UserOrder)
                   && recordOne.UserAddress.Equals(recordTwo.UserAddress)
                   && recordOne.UserName.Equals(recordTwo.UserName);
        }

        public int GetHashCode(UserFullRecord obj)
        {
            return base.GetHashCode();
        }
    }
}
