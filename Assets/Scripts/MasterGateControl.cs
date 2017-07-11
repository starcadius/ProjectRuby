using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterGateControl : MonoBehaviour {
    GameObject[] laserGateObjects;
   public LaserGate[] laserGates;
    public enum GateSwitch { yellow, blue };
    public GateSwitch gateActive;
    // Use this for initialization
    void Start () {

        //add all lasergates
        laserGateObjects = GameObject.FindGameObjectsWithTag("LaserGate");

        laserGates = new LaserGate[laserGateObjects.Length];

        for (int i = 0; i < laserGateObjects.Length; i++)
        {
            laserGates[i] = laserGateObjects[i].GetComponent<LaserGate>();
        }
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeGate()
    {
        int gateState = 0;
        if (gateActive == GateSwitch.yellow)
        {
            gateActive = GateSwitch.blue;
            gateState = 1;
        }
        else
         if (gateActive == GateSwitch.blue)
        {
            gateActive = GateSwitch.yellow;
            gateState = 0;
        }

        Debug.Log("gate switched to "+gateActive);
        // do a for each loop for gates
        if (laserGates != null)
        {
            foreach (LaserGate gate in laserGates)
            {
                //switch gates

                gate.ChangeMyGate(gateState);
            }
        }
    }
}
