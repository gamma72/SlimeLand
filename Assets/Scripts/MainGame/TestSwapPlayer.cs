using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSwapPlayer : MonoBehaviour
{
    GameObject player01, player02;

    bool playerOn = false;
    // Start is called before the first frame update
    void Start()
    {
        player01 = GameObject.Find("Player01");
        player02 = GameObject.Find("Player02");

        player02.transform.GetChild(2).gameObject.SetActive(false);
        player02.transform.GetChild(1).gameObject.SetActive(false);
        player02.GetComponent<PlayerMove>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangePlayer();
        }
    }

    public void ChangePlayer()
    {
        player01.transform.GetChild(2).gameObject.SetActive(playerOn);
        player01.transform.GetChild(1).gameObject.SetActive(playerOn);
        player01.GetComponent<PlayerMove>().enabled = playerOn;
        player02.transform.GetChild(2).gameObject.SetActive(!playerOn);
        player02.transform.GetChild(1).gameObject.SetActive(!playerOn);
        player02.GetComponent<PlayerMove>().enabled = !playerOn;
        playerOn = !playerOn;
    }
}
