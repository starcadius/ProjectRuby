using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class LaserGate : MonoBehaviour {
    public enum DoorType {yellow, blue };
    [Tooltip("you can choose the color of door, the colors are synched")]
    public DoorType type;
    public Animator animator;
    [Tooltip("child game object that has the collider and agent blocker on it, plan to only have this in the final inspector version")]
    public GameObject LaserBlocker;
    [Tooltip("this will be private")]
    public NavMeshObstacle navMeshBlocker;
    [Tooltip("this will be private")]
    public BoxCollider localCollider;
    [Tooltip("when active, turn on laser shield")]
    public bool _isActive = true;
    // Use this for initialization
    void Start () {

        
        if (type == DoorType.blue)
        {
            animator.SetInteger("gateNum", 1);
        }
        else
               if (type == DoorType.yellow)
        {
            animator.SetInteger("gateNum", 0);
        }

        if (_isActive)
        {
            animator.SetBool("on", true);
            navMeshBlocker.enabled = true;
            localCollider.isTrigger = false;
        }
        else
        {
            animator.SetBool("on", false);
            navMeshBlocker.enabled = false;
            localCollider.isTrigger = true;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeMyGate(int gateState)
    {
  
        switch (gateState)
        {
            case 1:
                //blue on yellow off
                Debug.Log(this+" laserGate switched to " + gateState);
                if (type == DoorType.blue)
                {
                    _isActive = true;
                }
                else 
                if (type == DoorType.yellow)
                {
                    _isActive = false;
                }
                    break;

            case 0:
                //blue off yellow on
                Debug.Log(this + " laserGate switched to " + gateState);
                if (type == DoorType.blue)
                {
                    _isActive = false;
                }
                else
               if (type == DoorType.yellow)
                {
                    _isActive = true;
                }
                break;

            default:
                //something
                Debug.Log(this + " laserGate switched to " + gateState);
                break;
        }

        if (_isActive)
        {
            animator.SetBool("on", true);
            navMeshBlocker.enabled = true;
            localCollider.isTrigger = false;
        }
        else
        {
            animator.SetBool("on", false);
            navMeshBlocker.enabled = false;
            localCollider.isTrigger = true;
        }
    }
}
