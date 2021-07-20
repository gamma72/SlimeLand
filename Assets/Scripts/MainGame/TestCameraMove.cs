using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraMove : MonoBehaviour
{
    public Vector3 CameraPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCamera()
    {
        float num;
        if (CameraPos.x > CameraPos.z) num = CameraPos.x;
        else num = CameraPos.z;
        transform.position = CameraPos + new Vector3(0, num * 2.5f, 0);
    }
}
