using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUiRotation : MonoBehaviour
{
    GameObject player, panel;


    void Start()
    {
        player = GameObject.Find("Main Camera");
        panel = gameObject.transform.GetChild(0).gameObject;
    }
 
    void Update()
    {
        transform.LookAt(player.transform);
        //panel.transform.position = gameObject.transform.position + new Vector3(0, 0, (gameObject.transform.parent.localScale.x/2) + 1.5f);
        panel.transform.position = gameObject.transform.forward + new Vector3(0,player.transform.position.y,0);
    }
}
