using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public bool metalDoorJam = false;
	
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Kiosk")
        {
            metalDoorJam = true;
        }

        if (collision.gameObject.tag == "MetalDoor")
        {
            metalDoorJam = false;
            //activate door
            collision.gameObject.SetActive(false);
        }
    }
}
