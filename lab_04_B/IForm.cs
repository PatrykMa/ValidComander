using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_04_B
{
    interface IForm
    {
        event Action<Object> CopyButtonClick;
        event Action<Object> DeleteButtonClick;
        event Action<Object> MoveButtonClick;

        MinTCPanel GetLeftPanel();
        MinTCPanel GetRightPanel();
        

    }
}
