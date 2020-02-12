using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortListener
{
    public class ConnInfo
    {
        public string Protocol { get; set; } = "";
        public string Address { get; set; } = "";
        public string Address2 { get; set; } = "";
        public string Status { get; set; } = "";
        public int Pid { get; set; }
        public string Pname { get; set; } = "";

        public override bool Equals(object obj)
        {
            return obj is ConnInfo info &&
                   Protocol == info.Protocol &&
                   Address == info.Address &&
                   Address2 == info.Address2 &&
                   Status == info.Status &&
                   Pid == info.Pid &&
                   Pname == info.Pname;
        }

        public override int GetHashCode()
        {
            var hashCode = -1599007192;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Protocol);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address2);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Status);
            hashCode = hashCode * -1521134295 + Pid.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Pname);
            return hashCode;
        }

        public static bool operator ==(ConnInfo obj1, ConnInfo obj2)
        {
            if (obj1.GetHashCode() == obj2.GetHashCode() && obj1.Equals(obj2))
                return true;
            return false;
        }

        public static bool operator !=(ConnInfo obj1, ConnInfo obj2)
        {
            if (obj1.GetHashCode() == obj2.GetHashCode() && obj1.Equals(obj2))
                return false;
            return true;
        }
    }
}
