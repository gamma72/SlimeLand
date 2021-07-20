using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CognizeTileManager : MonoBehaviour
{

    [Header("don't use")]
    public GameObject lookObj;
    public GameObject panel;
    public GameObject playerCamera;
    

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.Find("Player02").transform.GetChild(1).gameObject;

        lookObj = gameObject.transform.GetChild(0).gameObject;
        panel = lookObj.transform.GetChild(0).gameObject;
        
        lookObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void LookPlayer()
    {
        lookObj.SetActive(true);
        lookObj.transform.LookAt(playerCamera.transform);
        panel.transform.position = lookObj.transform.forward * 2f + lookObj.transform.position;
    }
    
    public void UnLookPlayer()
    {
        lookObj.SetActive(false);
    }
}
