using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conveyor_Belt
{
    internal class Carrier
    {
        public UInt64 id; //자재 구분 id
        public UInt16 source; //출발
        public UInt16 dest; //목적지
        public USE use; //저장, 반출 

        public enum USE
        {
            USE_NONE,
            USE_TAKEOUT,
            USE_STACK
        }
        public void clear() //초기화
        {
            id = 0;
            source = 0;
            dest = 0;
            use = USE.USE_NONE;
        }
    }

}
