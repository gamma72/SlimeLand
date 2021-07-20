using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnTileManager : MonoBehaviour
{
    public GameObject objectDestroy;
    public List<GameObject> enemys;
    public List<GameObject> objects;

    float curTime, limitTime = 10;
    bool danger;

    float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > 1)
        {
            for(int i=0; i<enemys.Count; i++)
            {
                if(enemys[i] == null)
                {
                    enemys.RemoveAt(i);
                }
            }
            time = 0;
        }

        if (enemys.Count >= 4) danger = true;
        else danger = false;

        if (danger) curTime += Time.deltaTime;
        else curTime = 0;

        if(curTime > limitTime)
        {
            if(objects.Count > 0)
            {
                for(int i=0; i<objects.Count; i++)
                {
                    Instantiate(objectDestroy, objects[i].transform.position, objects[i].transform.rotation);
                    Destroy(objects[i]);
                }                
            }
            objects.Clear();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemys.Add(other.gameObject);
        }
        if(other.gameObject.layer == 12)
        {
            objects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemys.Remove(other.gameObject);
        }
        if(other.gameObject.layer == 12)
        {
            if (other.GetComponent<IsLandingManager>().isDown)
            {
                objects.Remove(other.gameObject);
            }
        }
    }
}
