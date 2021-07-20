using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOnLook : MonoBehaviour
{
    GameObject panel, player;

    bool panelActive;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Main Camera");
        panel = gameObject.transform.parent.GetChild(0).gameObject;
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (panelActive)
        {
            RaycastHit hit;

            Debug.DrawRay(player.transform.position, player.transform.forward);
            if (Physics.Raycast(player.transform.position, player.transform.forward, out hit))
            {
                if (hit.transform != null)
                {
                    Debug.Log(hit.transform.name);
                    if (hit.transform == gameObject.transform.parent || hit.transform == panel.transform.GetChild(0))
                    {
                        panel.SetActive(true);
                    }else
                    {
                        panel.SetActive(false);
                    }
                }
                
            }
            else
            {
                panel.SetActive(false);
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            panelActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            panelActive = false;
            panel.SetActive(false);
        }
    }
}
