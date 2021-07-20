using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWallManager : MonoBehaviour
{
    Vector3 center;
    float xSize, zSize;
    int xPos, zPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReLoadMap()
    {
        center = gameObject.transform.parent.parent.GetComponent<CreateMap>().center;
        xPos = gameObject.transform.parent.parent.GetComponent<CreateMap>().xPos;
        zPos = gameObject.transform.parent.parent.GetComponent<CreateMap>().zPos;
        xSize = xPos * 3;
        zSize = zPos * 3;


        RePosition();
        ReSize();
    }

    public void ReSize()
    {
        if(gameObject.name == "Front" || gameObject.name == "Back")
        {
            transform.localScale = new Vector3(xSize+2, 10, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 10, zSize);
        }
    }

    public void RePosition()
    {
        switch (gameObject.name)
        {
            case "Front":
                transform.position = center + new Vector3(0,0,zSize/2) + new Vector3(0,0,0.5f);
                break;
            case "Back":
                transform.position = center - new Vector3(0, 0, zSize / 2) + new Vector3(0,0,-0.5f);
                break;
            case "Right":
                transform.position = center + new Vector3(xSize/2, 0, 0) + new Vector3(0.5f, 0, 0);
                break;
            case "Left":
                transform.position = center - new Vector3(xSize/2, 0, 0) + new Vector3(-0.5f, 0, 0);
                break;
            default:
                break;
        }
    }
}
