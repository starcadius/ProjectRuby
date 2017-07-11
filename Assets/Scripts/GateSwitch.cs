using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSwitch : MonoBehaviour {

    /*simple trigger switch for changing the gates*/

    //drag in game object that has the master gate control script on it.
   public MasterGateControl masterGateControl;//controls which gates are active


    void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.tag == "agent")
        {
            masterGateControl.ChangeGate();
            return;
        }
    }
}
