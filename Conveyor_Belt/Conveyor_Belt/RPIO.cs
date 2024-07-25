using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor_Belt
{
    public class RPIO
    {
        private bool blsTrReq;
        private bool blsBusy;
        private bool blsCompt;
        private bool blsUReq;
        private bool blsLReq;
        private bool blsReady;

        public bool TrReq
        {
            get { return blsTrReq; }
            set { blsTrReq = value; }
        }
        public bool Busy
        {
            get { return blsBusy; }
            set { blsBusy = value; }
        }
        public bool Compt
        {
            get { return blsCompt; }
            set { blsCompt = value; }
        }
        public bool UReq 
        {
            get { return blsUReq; }
            set { blsUReq = value; }
        }
        public bool LReq 
        { 
            get { return blsLReq; } 
            set { blsLReq = value; }
        }
        public bool Ready
        {
            get { return blsReady; }
            set { blsReady = value; }
        }
    }
}
