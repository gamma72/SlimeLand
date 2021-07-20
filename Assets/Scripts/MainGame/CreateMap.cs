using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [Header("Map Size")]
    public int xPos;
    public int zPos;

    [Header("Components")]
    public Material grayMaterial;
    public GameObject tilePrefabs;
    public GameObject groundPrefabs;
    public GameObject waterPrefabs;
    public GameObject enemyCreater;
    

    [Header("Don't reValue")]
    public Vector3 center;


    //GameObject mainCamera;
    GameObject[] sideWall;
    GameObject target, centerTop;

    public struct ARRSIZE
    {
        public int x;
        public int z;
    }

    ARRSIZE baseArr;
    GameObject[] panels;

    // Start is called before the first frame update
    void Start()
    {
        //mainCamera = GameObject.Find("Main Camera");
        sideWall = GameObject.FindGameObjectsWithTag("SideWall");
        target = GameObject.Find("Target");
        centerTop = GameObject.Find("CenterTop");

        MapReLoad();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            MapReLoad();
        }
    }

    public void MapReLoad()
    {
        baseArr.x = xPos;
        baseArr.z = zPos;
        DestroyPanels(panels);
        panels = SetArr(baseArr);
        InstancePanel(panels, baseArr);
        Debug.Log("ReLoad Map");

        center = CenterSearch(baseArr);

        centerTop.transform.position = center + new Vector3(0,10,0);
        //mainCamera.GetComponent<TestCameraMove>().CameraPos = center;
        //mainCamera.GetComponent<TestCameraMove>().MoveCamera();

        //enemyCreater.transform.position = panels[0].transform.position + new Vector3(1.5f, 0, -1.5f);
        

        target.transform.position = panels[panels.Length - 1].transform.position + new Vector3(1.5f, 0, -1.5f);

        for (int i = 0; i < sideWall.Length; i++)
        {
            sideWall[i].GetComponent<SideWallManager>().ReLoadMap();
        }

        
    }

    public void EnemyCreaterMake()
    {
        GameObject instanceObj = Instantiate(enemyCreater, transform.position, transform.rotation) as GameObject;
        instanceObj.transform.position = panels[0].transform.position + new Vector3(1.5f, .5f, -1.5f);
    }

    public GameObject[] SetArr(ARRSIZE test)
    {
        Debug.Log("SetArr");
        return new GameObject[test.x * test.z];
    }

    public void InstancePanel(GameObject[] arr, ARRSIZE size)
    {
        Debug.Log("Instance");
        for (int i=0; i<arr.Length; i++)
        {
            arr[i] = Instantiate(tilePrefabs, transform.position + new Vector3((i % size.x) *3,0,(i / size.x)*3), Quaternion.Euler(0, 0, 0));
            arr[i].transform.name = i < 10 ? "Tile_0" + i : "Tile_" + i;
            arr[i].transform.parent = transform.GetChild(3);
            GameObject testG  = Instantiate(groundPrefabs, arr[i].transform.position + new Vector3(1.5f, -5, -1.5f), arr[i].transform.rotation);
            testG.transform.parent = transform.GetChild(2);

            /*if((i/size.x)%2 == 0)
            {
                //arr[i].GetComponent<MeshRenderer>().material = grayMaterial;
                if ((i % size.x) % 2 == 0)
                {
                    arr[i].GetComponent<MeshRenderer>().material = grayMaterial;
                }
            }
            else
            {
                if ((i % size.x) % 2 != 0)
                {
                    arr[i].GetComponent<MeshRenderer>().material = grayMaterial;
                }
            }*/
        }
    }

    public void DestroyPanels(GameObject[] arr)
    {
        if (arr == null) return;

        Debug.Log("Destroy");
        for(int i = 0; i<arr.Length; i++)
        {
            Destroy(arr[i]);
        }
    }

    public Vector3 CenterSearch(ARRSIZE size)
    {
        return gameObject.transform.position + new Vector3(((size.x * 3f) / 2), 0, ((size.z * 3f) / 2) - 3f);
    }
}
