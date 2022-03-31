using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BO
{
    [DataContract]
    public class HeaderInfo
    {
        [DataMember]
        public string TransactionID { get; set; }

        [DataMember]
        public string CallStatus { get; set; }

    }
}
