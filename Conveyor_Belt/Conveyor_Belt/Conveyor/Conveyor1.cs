using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Conveyor_Belt.Conveyor
{
    class Conveyor1 : CDevice
    {
        public Conveyor1()
        {
            carrier = new Carrier(); //인스턴스
        }
    public override void Process()
        {
            //함수 이름만 만들고 구현을 하지 않으면 예외처리
            //throw new NotImplementedException(); 
            if (blsAutoConv == true)
            {
                switch (stepConv)
                {
                    case 0:
                        blsUReq = false;
                        blsLReq = false;
                        blsReady = false;
                        statusCwconv = false;
                        statusCcwconv = false;

                        stepConv = 100;
                        break;

                    case 100:
                        blsLReq = true;
                        if (blsTrReq)
                        {
                            statusCwconv = true;
                            blsReady = true;
                            stepConv = 110;
                        }
                        break;

                    case 110:
                        if (blsBusy)
                        {
                            stepConv = 120;
                        }
                        break;

                    case 120:
                        if (blsSensorDetect1)
                        {
                            statusCwconv = false;
                            stepConv = 130;
                        }
                        break;

                    case 130:
                        if (!blsTrReq && !blsBusy && blsCompt)
                        {
                            blsLReq = false;
                            blsReady = false;
                            stepConv = 140;
                        }
                        break;

                    case 140:
                        if (blsSensorDetect2 == false)
                        {
                            stepConv = 200;
                        }
                        break;

                    case 200:
                        if (!blsSensorDetect1 && !blsSensorDetect2)
                        {
                            stepConv = 0;
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
                Console.WriteLine("Conveyor 1 Step = {0}", stepConv);
            }
            oldStepConv = stepConv;
            blsTakeIn = false;
        }
    }
}
