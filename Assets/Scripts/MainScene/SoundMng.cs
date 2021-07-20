using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMng : MonoBehaviour
{
    public AudioClip[] bgmS;
    AudioSource bgmO;

    // Start is called before the first frame update
    void Start()
    {
        bgmO = GameObject.Find("Bgm").GetComponent<AudioSource>();
        SettingVolume();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SettingVolume()
    {
        bgmO.volume = PlayerPrefs.GetFloat("BgmV");
    }
}
