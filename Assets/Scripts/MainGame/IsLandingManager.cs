using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLandingManager : MonoBehaviour
{
    public bool isLand, isCollision, isDown;
    Vector3 m_LastPosition;
    Rigidbody thisRigidbody;
    float curTime, coolTime = .5f;

    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollision)
        {
            if (GetSpeed() == 0)
            {
                isLand = true;
            }
            else
            {
                isLand = false;
            }

            if (isLand)
            {
                if (curTime < 3) curTime += Time.deltaTime;
            }
            else
            {
                curTime = 0;
            }

            if (curTime > coolTime)
            {
                thisRigidbody.isKinematic = true;
                isDown = true;
                isCollision = false;
            }
        }

        if(GetSpeed() > 0)
        {
            isDown = false;
        }
    }

    public float GetSpeed()
    {
        float speed = ((transform.position - m_LastPosition).magnitude) / Time.deltaTime;
        m_LastPosition = transform.position;

        return speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Tile")
        {
            isCollision = true;
        }
    }
}
