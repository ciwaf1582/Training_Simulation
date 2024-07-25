using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor_Belt.Conveyor
{
     class ConveyorS : CDevice
    {
        public RPIO convPio1;
        public RPIO convPio2;
        public RPIO convPio3;
        public RPIO convPio4;
        public ConveyorS()
        {
            convPio1 = new RPIO();
            convPio2 = new RPIO();
            convPio3 = new RPIO();
            convPio4 = new RPIO();

            carrier = new Carrier();
        }
        public enum SERVO_POS
        {
            CONV_NONE = 0,
            CONV1 = 1,
            CONV2 = 2,
            CONV3 = 3,
            CONV4 = 4
        }
        private SERVO_POS tarPos;
        private SERVO_POS curPos;
        public SERVO_POS TargetPosition
        {
            get { return tarPos; } //외부에서 변경 불가능
        }
        public SERVO_POS CurrentPositions
        {
            get { return curPos; }
            set { curPos = value; }
        }
        private void MovePostion(SERVO_POS target) // 임시 함수
        {
            tarPos = target;
        }
        public SERVO_POS GetPosition()
        {
            return curPos;
        }
        public override void Process()
        {
            
            //함수 이름만 만들고 구현을 하지 않으면 예외처리
            //throw new NotImplementedException(); 
            if (blsAutoConv == true)
            {
                switch (stepConv)
                {
                    case 0: // 초기화 하는 부분 
                        stepConv = 100; //임시
                        break;

                    case 100:
                        if (convPio1.UReq) stepConv = 200;
                        else if (convPio2.UReq) stepConv = 300;
                        else if (convPio3.UReq) stepConv = 400;
                        else if (convPio4.UReq) stepConv = 500;
                        break;

                    case 200:
                        if (convPio1.UReq)
                        {
                            MovePostion(SERVO_POS.CONV1); // 적힌 숫자의 컨베이너에게 감
                            if (GetPosition() == SERVO_POS.CONV1)
                            {
                                stepConv = 210;
                            }
                        }
                        break;

                    case 210:
                        convPio1.TrReq = true;
                        if (convPio1.UReq && convPio1.Ready)
                        {
                            stepConv = 220;
                        }
                        break;

                    case 220:
                        statusCcwconv = true;
                        convPio1.Busy = true;
                        if (convPio1.Ready && blsSensorDetect1)
                        {
                            statusCcwconv = false;
                            convPio1.TrReq = false;
                            convPio1.Busy = false;
                            stepConv = 230;
                        }
                        break;

                    case 230:
                        convPio1.Compt = true;
                        if (!convPio1.Ready)
                        {
                            convPio1.Compt = false;
                            stepConv = 240;
                        }
                        break;

                    case 240:
                        stepConv = 600;
                        break;

                    case 300:
                        if (convPio2.UReq)
                        {
                            MovePostion(SERVO_POS.CONV2);
                            if (GetPosition() == SERVO_POS.CONV2)
                            {
                                stepConv = 310;
                            }
                        }
                        break;

                    case 310:
                        convPio2.TrReq = true;
                        if (convPio2.UReq && convPio2.Ready)
                        {
                            stepConv = 320;
                        }
                        break;

                    case 320:
                        statusCcwconv = true;
                        convPio2.Busy = true;
                        if (convPio2.Ready && blsSensorDetect2)
                        {
                            statusCcwconv = false;
                            convPio2.TrReq = false;
                            convPio2.Busy = false;
                            stepConv = 330;
                        }
                        break;

                    case 330:
                        convPio2.Compt = true;
                        if (!convPio2.Ready)
                        {
                            convPio2.Compt = false;
                            stepConv = 240;
                        }
                        break;

                    case 340:
                        stepConv = 600;
                        break;

                    case 400:
                        if (convPio3.UReq)
                        {
                            MovePostion(SERVO_POS.CONV3); // 적힌 숫자의 컨베이너에게 감
                            if (GetPosition() == SERVO_POS.CONV3)
                            {
                                stepConv = 410;
                            }
                        }
                        break;

                    case 410:
                        convPio3.TrReq = true;
                        if (convPio3.UReq && convPio3.Ready)
                        {
                            stepConv = 420;
                        }
                        break;

                    case 420:
                        statusCwconv = true;
                        convPio3.Busy = true;
                        if (convPio3.Ready && blsSensorDetect2)
                        {
                            statusCwconv = false;
                            convPio3.TrReq = false;
                            convPio3.Busy = false;
                            stepConv = 430;
                        }
                        break;

                    case 430:
                        convPio3.Compt = true;
                        if (!convPio3.Ready)
                        {
                            convPio3.Compt = false;
                            stepConv = 440;
                        }
                        break;

                    case 440:
                        stepConv = 600;
                        break;

                    case 500:
                        if (convPio4.UReq)
                        {
                            MovePostion(SERVO_POS.CONV4); // 적힌 숫자의 컨베이너에게 감
                            if (GetPosition() == SERVO_POS.CONV4)
                            {
                                stepConv = 510;
                            }
                        }
                        break;

                    case 510:
                        convPio4.TrReq = true;
                        if (convPio4.UReq && convPio4.Ready)
                        {
                            stepConv = 520;
                        }
                        break;

                    case 520:
                        statusCwconv = true;
                        convPio4.Busy = true;
                        if (convPio4.Ready && blsSensorDetect1)
                        {
                            statusCwconv = false;
                            convPio4.TrReq = false;
                            convPio4.Busy = false;
                            stepConv = 530;
                        }
                        break;

                    case 530:
                        convPio4.Compt = true;
                        if (!convPio4.Ready)
                        {
                            convPio4.Compt = false;
                            stepConv = 540;
                        }
                        break;

                    case 540:
                        stepConv = 600;
                        break;

                    case 600: //몇번 컨베이어로 갈지 선택
                        if (carrier.id != 0)
                        {
                            if (carrier.use == Carrier.USE.USE_TAKEOUT)
                            {
                                if (convPio1.LReq) //자재 정보가 반출상태면 1번 컨베이어로 반출
                                {
                                    stepConv = 700;
                                    carrier.dest = 1;
                                }
                            }
                            //스택 상태면 3, 4번 컨베이어로 반출
                            else if (carrier.use == Carrier.USE.USE_STACK) 
                            {
                                if (convPio3.LReq)
                                {
                                    stepConv = 900;
                                    carrier.dest = 3;
                                }
                                if (convPio4.LReq)
                                {
                                    stepConv = 1000;
                                    carrier.dest = 4;
                                }
                            }
                            //자재정보가 NONE이면... Erorr처리를 해야하지만 임시로 1번으로 반출
                            else if (carrier.use == Carrier.USE.USE_NONE) 
                            {
                                if (convPio1.LReq)
                                {
                                    stepConv = 700;
                                    carrier.dest = 1;
                                }
                            }
                        }
                        else
                        {
                            // know id take out : 아이디가 0이면 이상한 것으로 간주
                        }
                        break;

                    case 700:
                        if (convPio1.LReq)
                        {
                            MovePostion(SERVO_POS.CONV1);
                            if (GetPosition() == SERVO_POS.CONV1)
                                stepConv = 710;
                        }
                        break;

                    case 710:
                        convPio1.TrReq = true;
                        if(convPio1.LReq && convPio1.Ready)
                        {
                            stepConv = 720;
                        }
                        break;

                    case 720:
                        statusCwconv = true;
                        convPio1.Busy = true;
                        if (!blsSensorDetect1 && !blsSensorDetect2)
                        {
                            statusCwconv = false;
                            convPio1.TrReq = false;
                            convPio1.Busy = false;
                            stepConv = 730;
                        }
                        break;

                    case 730:
                        convPio1.Compt = true;
                        if (!convPio1.Ready)
                        {
                            convPio1.Compt = false;
                            stepConv = 100;
                        }
                        break;

                    case 800:
                        if (convPio2.LReq)
                        {
                            MovePostion(SERVO_POS.CONV2);
                            if (GetPosition() == SERVO_POS.CONV2)
                                stepConv = 810;
                        }
                        break;

                    case 810:
                        convPio2.TrReq = true;
                        if (convPio2.LReq && convPio2.Ready)
                        {
                            stepConv = 820;
                        }
                        break;

                    case 820:
                        statusCwconv = true;
                        convPio2.Busy = true;
                        if (!blsSensorDetect1 && !blsSensorDetect2)
                        {
                            statusCwconv = false;
                            convPio2.TrReq = false;
                            convPio2.Busy = false;
                            stepConv = 830;
                        }
                        break;

                    case 830:
                        convPio2.Compt = true;
                        if (!convPio2.Ready)
                        {
                            convPio2.Compt = false;
                            stepConv = 100;
                        }
                        break;

                    case 900:
                        if (convPio3.LReq)
                        {
                            MovePostion(SERVO_POS.CONV3);
                            if (GetPosition() == SERVO_POS.CONV3)
                                stepConv = 910;
                        }
                        break;

                    case 910:
                        convPio3.TrReq = true;
                        if (convPio3.LReq && convPio3.Ready)
                        {
                            stepConv = 920;
                        }
                        break;

                    case 920:
                        statusCcwconv = true;
                        convPio3.Busy = true;
                        if (!blsSensorDetect1 && !blsSensorDetect2)
                        {
                            statusCcwconv = false;
                            convPio3.TrReq = false;
                            convPio3.Busy = false;
                            stepConv = 930;
                        }
                        break;

                    case 930:
                        convPio3.Compt = true;
                        if (!convPio3.Ready)
                        {
                            convPio3.Compt = false;
                            stepConv = 100;
                        }
                        break;

                    case 1000:
                        if (convPio4.LReq)
                        {
                            MovePostion(SERVO_POS.CONV4);
                            if (GetPosition() == SERVO_POS.CONV4)
                                stepConv = 1010;
                        }
                        break;

                    case 1010:
                        convPio4.TrReq = true;
                        if (convPio4.LReq && convPio4.Ready)
                        {
                            stepConv = 1020;
                        }
                        break;

                    case 1020:
                        statusCcwconv = true;
                        convPio4.Busy = true;
                        if (!blsSensorDetect1 && !blsSensorDetect2)
                        {
                            statusCcwconv = false;
                            convPio4.TrReq = false;
                            convPio4.Busy = false;
                            stepConv = 1030;
                        }
                        break;

                    case 1030:
                        convPio4.Compt = true;
                        if (!convPio4.Ready)
                        {
                            convPio4.Compt = false;
                            stepConv = 100;
                        }
                        break;

                    default:
                        stepConv = 0;
                        break;
                }
            }
            else
            {
                stepConv = 0;
            }
            if (oldStepConv != stepConv)
            {
                Console.WriteLine("Shuttle Conveyor = {0}", stepConv);
            }
            oldStepConv = stepConv;
            blsTakeIn = false;
        }
    }
}
