using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public float grabRange, throwPower;

    UiManager uiMng;
    public GameObject grabP, playerS;
    Transform grabO;
    RaycastHit hit;
    Quaternion objectRotateQ;
    Vector3 objectRotateV;

    public bool isCognize, isGrab, isRotate;
    int layerMask;
    float curTime, coolTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        grabP = GameObject.Find("GrabPoint");

        uiMng = GameObject.Find("GameMng").GetComponent<UiManager>();
        layerMask = 1 << LayerMask.NameToLayer("Object");

        grabP.transform.position = gameObject.transform.position + new Vector3(0, 0, grabRange);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) return;

        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, grabRange, layerMask))
        {
            CognizeObject(true);
        }
        else
        {
            CognizeObject(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(isCognize)
            {
                grabO = hit.transform;
                isGrab = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            DownObject();
            grabO = null;
        }

        if(isGrab)
        {
            if (Input.GetMouseButtonUp(1))
            {
                ThrowObject();
                grabO = null;
            }
            else
            { 
                GrabObject();
                if (Input.GetAxis("Mouse ScrollWheel") == 0)
                {
                    if (!isRotate)
                    {
                        GrabObjectRotate(SetRotateZero(gameObject.transform.rotation.y));
                        objectRotateV = gameObject.transform.eulerAngles;
                        objectRotateV.x = objectRotateV.z = 0;
                    }
                    else
                    {
                        GrabObjectRotateChange(objectRotateV);
                    }
                }
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            isRotate = true;
            curTime = 0;
            if (Input.mouseScrollDelta.y > 0) objectRotateV.y += 10f;
            if (Input.mouseScrollDelta.y < 0) objectRotateV.y -= 10f;
        }

        if(isRotate && Input.GetAxis("Mouse ScrollWheel") == 0)
        {
            curTime += Time.deltaTime;
        }

        if(curTime > coolTime)
        {
            isRotate = false;
        }
    }

    public void CognizeObject(bool cognize)
    {
        isCognize = cognize;
        if (isCognize) uiMng.isCognize = cognize;
        else uiMng.isCognize = cognize;
    }

    public void GrabObject()
    {
        grabO.position = Vector3.Lerp(grabO.position, grabP.transform.position, 0.1f);

        grabO.GetComponent<Rigidbody>().isKinematic = true;
        grabO.GetComponent<Rigidbody>().useGravity = false;
    }

    public Quaternion SetRotateZero(float target)
    {
        Quaternion rotation = gameObject.transform.rotation;
        rotation.x = 0;
        rotation.z = 0;
        rotation.y = target;

        return rotation;
    }

    public void GrabObjectRotate(Quaternion target)
    {
        grabO.transform.rotation = Quaternion.Slerp(grabO.transform.rotation, target, 7 * Time.deltaTime);
        //grabO.transform.localRotation = transform.localEulerAngles();
    }

    public void GrabObjectRotateChange(Vector3 target)
    {
        grabO.transform.eulerAngles = target;
    }

    public void UnGrabObject()
    {
        isGrab = false;
        isRotate = false;
        if (grabO != null)
        {
            grabO.GetComponent<Rigidbody>().isKinematic = false;
            grabO.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    public void DownObject()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        float forwardP = ((x >= 0 ? x : -x) * (y >= 0 ? y : -y)) / 3.14f;
        UnGrabObject();
        if (grabO != null)
        {
            grabO.GetComponent<Rigidbody>().AddForce(transform.right * x * 100);
            grabO.GetComponent<Rigidbody>().AddForce(transform.up * y * 100);

            grabO.GetComponent<Rigidbody>().AddForce(transform.forward * forwardP * 100);
        }    
    }

    public void ThrowObject()
    {
        UnGrabObject();
        grabO.GetComponent<Rigidbody>().AddForce(transform.forward * throwPower * 100);
        grabO.GetComponent<Rigidbody>().AddForce(transform.up * 200);
    }
}