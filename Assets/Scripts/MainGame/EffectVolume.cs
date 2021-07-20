using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectVolume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("EffectV");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
