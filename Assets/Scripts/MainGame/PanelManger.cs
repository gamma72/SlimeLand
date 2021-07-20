using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform != null)
                {
                    /*
                    switch (hit.transform.tag)
                    {
                        case "OnCreate":
                            GameObject tower = Instantiate(towerPrefab) as GameObject;
                            tower.transform.position = hit.collider.transform.position + new Vector3(0, .9f, 0);
                            break;
                        case "None":
                            Debug.Log("This place is no create Tower");
                            break;
                    }
                    */

                    Debug.Log(hit.transform.name);
                }
            }
        }
    }
}
