using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraRay : MonoBehaviour
{
    [Header("don't use")]
    public GameObject hitObject;

    LayerMask tileMask, buttonMask;
    RaycastHit hit;
    RaycastHit buttonhit;

    float cognizeRange = 5;


    // Start is called before the first frame update
    void Start()
    {
        tileMask = 1 << LayerMask.NameToLayer("Tile");
        buttonMask = 1 << LayerMask.NameToLayer("Button");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out buttonhit, cognizeRange, buttonMask))
            {
                if (buttonhit.transform != null)
                {
                    buttonhit.transform.GetComponent<CreaterManager>().CreateTarger();
                }
            }
        }

        //if(hit.transform != null) Debug.Log(hit.transform.gameObject);
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * 5, Color.red);
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, cognizeRange, tileMask))
        {
            if (hit.transform != null)
            {
                if (hitObject != null)
                {
                    if (hitObject != hit.transform)
                    {
                        UnTarget();
                    }
                }
                hitObject = hit.transform.gameObject;
                if(hit.transform.position.y > gameObject.transform.position.y)
                {
                    ReTarget();
                }
            }
        }
        else
        {
            UnTarget();
        }

        
    }

    public void ReTarget()
    {
        if (hit.transform != null)
        {
            if(hit.transform.tag == "Panel")
            {
                hit.transform.parent.parent.GetComponent<CognizeTileManager>().LookPlayer();
            }
            else
            {
                hit.transform.GetComponent<CognizeTileManager>().LookPlayer();
            }
        }
    }

    public void UnTarget()
    {
        if (hitObject != null)
        {
            if (hitObject.tag == "Panel")
            {
                hitObject.transform.parent.parent.GetComponent<CognizeTileManager>().UnLookPlayer();
            }
            else
            {
                hitObject.GetComponent<CognizeTileManager>().UnLookPlayer();
            }
            
        }
    }
}
