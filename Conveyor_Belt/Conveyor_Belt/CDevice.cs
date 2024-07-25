using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor_Belt
{
    abstract class CDevice : IProcess//abstract : 추상 클래스 (상속받아야만 사용 가능)
    {
        // public : 어디서든 접근
        //*protected : 상속 클래스에서 접근 가능
        // private : 같은 클래스 내에서 접근 가능
        protected bool blsTrReq;
        protected bool blsBusy;
        protected bool blsCompt;
        protected bool blsUReq; // Unload Request
        protected bool blsLReq; // Load Request
        protected bool blsReady;

        public Carrier carrier; //각 컨베이어에 상속하기 위해 CDevice에 불러옴
        //=============================================================
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
        public bool UReq { get { return blsUReq; } }
        public bool LReq { get { return blsLReq; } }
        public bool Ready { get { return blsReady; } }
        //=============================================================
        protected bool statusCwconv; //모터
        protected bool statusCcwconv;//모터
        public bool statusCw
        {
            get { return statusCcwconv; }
            set { statusCcwconv = value; }
        }
        public bool statusCcw
        {
            get { return statusCcwconv; }
            set { statusCcwconv = value; }
        }
        //=============================================================
        protected int stepConv;
        protected int oldStepConv;
        protected int countConv;
        public int step
        {
            get { return stepConv; }
            set { stepConv = value; }
        }
        public int oldStep
        {
            get { return oldStepConv; }
            set { oldStepConv = value; }
        }
        public int count
        {
            get { return countConv; }
            set { countConv = value; }
        }
        //=============================================================
        protected bool blsAutoConv;
        protected bool blsTakeIn, blsTakeOut;
        public bool auto
        {
            get { return blsAutoConv; }
            set { blsAutoConv = value; }
        }
        public bool takeIn
        {
            get { return blsTakeIn; }
            set { blsTakeIn = value; }
        }
        public bool takeOut
        {
            get { return blsTakeOut; }
            set { blsTakeOut = value; }
        }
        //=============================================================
        protected bool blsSensorDetect1, blsSensorDetect2;
        public bool sensor1
        {
            get { return blsSensorDetect1; }
            set { blsSensorDetect1 = value; }
        }
        public bool sensor2
        {
            get { return blsSensorDetect2; }
            set { blsSensorDetect2 = value; }
        }
        public abstract void Process(); // 추상함수

        
    }
}
