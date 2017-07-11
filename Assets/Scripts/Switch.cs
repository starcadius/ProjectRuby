using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
    public bool m_BluePortalOn = false;
    public bool m_agentInTrigger = false;
    public GameObject bluePortals;
    public GameObject purplePortals;
	// Use this for initialization
	void Start () {
        purplePortals.SetActive(false);
        bluePortals.SetActive(true);
    }

    public void OnTriggerEnter(Collider collider)
    {
        //detect astronaut and send it to m_portal
        if (collider.tag == "agent")
        {
            m_agentInTrigger = true;
           StartCoroutine (SwitchTimer());
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        //detect astronaut and send it to m_portal
        if (collider.tag == "agent")
        {
            m_agentInTrigger = false;
        }
    }

    public IEnumerator SwitchTimer()
    {

        yield return new WaitForSeconds(3f);
        //flip switch
        if (m_agentInTrigger)
        {
            m_BluePortalOn = !m_BluePortalOn;
        }

        if (!m_BluePortalOn)
        {
            purplePortals.SetActive(false);
            bluePortals.SetActive(true);
        }
        else
        {
            purplePortals.SetActive(true);
            bluePortals.SetActive(false);
        }

    }
}
