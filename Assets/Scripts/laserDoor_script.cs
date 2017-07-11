using UnityEngine;
using System.Collections;

public class laserDoor_script : MonoBehaviour
{
     public Animator MasterLaserController;
     public Collider Agent;

     
      bool bDoorOpen;
      bool yDoorOpen;
     
      void Start()
      {
      Debug.Log ("Laser script works!");
      //bDoorOpen = false;
      yDoorOpen = true;
     // MasterLaserController = GetComponent<Animator>();
      }
      
      void OnTriggerEnter(Collider col)
    {  
       Debug.Log ("I have been triggered!");
      if(col.gameObject.tag == "agent" && yDoorOpen == true)
      {
      //bDoorOpen = true;
      yDoorOpen = false;
      //GateChange ("bDoorOpen");
      MasterLaserController.SetBool("yDoorOpen",true);
      Debug.Log ("bdoor is open");
      return;
      }
       if(col.gameObject.tag == "agent" && yDoorOpen == false)
     {
     //bDoorOpen = false;
      yDoorOpen = true;
      //GateChange ("yDoorOpen");
      MasterLaserController.SetBool("yDoorOpen",false);
      Debug.Log ("ydoor is open");
      return;
      }
   }
      
      //void GateChange(string direction)
      //{
      //MasterLaserController.SetTrigger(direction);
      //}
}