using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerView : MonoBehaviour
{
    GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.Find("TestPanel");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.transform != null)
                {
                    Debug.Log(hit.transform.name);
                }
            }
        }
    }
}
