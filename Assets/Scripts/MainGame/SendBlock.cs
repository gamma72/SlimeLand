using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendBlock : MonoBehaviour
{
    CreateMap createMap;

    // Start is called before the first frame update
    void Start()
    {
        createMap = GameObject.Find("MapCreater").GetComponent<CreateMap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Object"))
        {
            if(other.GetComponent<Rigidbody>().useGravity == true)
            {
                Vector3 checkPosition = other.transform.position;
                if(checkPosition.x >= 0 && checkPosition.z >= -3)
                {
                    if (checkPosition.x <= createMap.xPos * 3 && checkPosition.z <= (createMap.zPos - 1) * 3)
                    {
                        other.transform.position = other.transform.position + (Vector3.up * 3);
                        return;
                    }
                }

                other.transform.position = createMap.center + (Vector3.up * 5);
            }
            
        }
    }
}
