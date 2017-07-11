using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Portals : MonoBehaviour {
    public Transform m_portal;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider collider)
    {
        //detect astronaut and send it to m_portal
        if (collider.tag == "agent")
        {
            Debug.Log("I see an astronaut!!!");
            if (m_portal != null && collider.gameObject.GetComponent<astronaut_agent>().m_portalEnabled)
            {
                collider.gameObject.GetComponent<astronaut_agent>().StartPortalTimer();
                NavMeshAgent navM = collider.gameObject.GetComponent<NavMeshAgent>();
                navM.enabled = false;
                collider.transform.position = m_portal.transform.position;
                
                navM.enabled = true;
            }
            else
            {
                Debug.Log("portal is missing destination transform!");
            }
        }
    }

   
    
}
