using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
public class astronaut_agent : NetworkBehaviour
{
    public SpriteRenderer spriteColor;
    public UnityEngine.AI.NavMeshAgent agent;
    public bool m_portalEnabled = true;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "ground")
                {
                    agent.SetDestination(hit.point);
                }
            }

        }
    }

    public void StartPortalTimer()
    {
        if (m_portalEnabled)
        {
            m_portalEnabled = false;
            StartCoroutine(PortalTimer());
        }
    }

    public IEnumerator PortalTimer()
    {

        Debug.Log("portal timer is running");
        
        yield return new WaitForSeconds(1);
        m_portalEnabled = true;
    }

    public override void OnStartLocalPlayer()
    {
        //GetComponent<MeshRenderer>().material.color = Color.blue;
        spriteColor.color = Color.yellow;
        GetComponent<NetworkAnimator>().SetParameterAutoSend(0,true);
    }

    public override void PreStartClient()
    {
        base.PreStartClient();
        GetComponent<NetworkAnimator>().SetParameterAutoSend(0, true);
    }
}