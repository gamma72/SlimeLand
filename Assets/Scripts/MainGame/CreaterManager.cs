using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaterManager : MonoBehaviour
{
    public GameObject createTarget;
    public GameObject btnSound;
    public int cost;

    GameMng gameMng;
    GameObject centertop;
    
    

    // Start is called before the first frame update
    void Start()
    {
        gameMng = GameObject.Find("GameMng").GetComponent<GameMng>();
        centertop = GameObject.Find("CenterTop");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateTarger()
    {
        if (gameMng.money < cost) return;
        GameObject createObj = Instantiate(createTarget, centertop.transform.position, Quaternion.Euler(centertop.transform.position)) as GameObject;
        Instantiate(btnSound, gameObject.transform.position, gameObject.transform.rotation);
        createObj.name = "Object_" + gameMng.numObject++;
        gameMng.money -= cost;
    }
}
