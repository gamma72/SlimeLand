using UnityEngine;
using UnityEngine.UI;

public class PlayerJson : MonoBehaviour
{
    Slider bgmS, effectS, responsiveS;

    // Start is called before the first frame update
    private void Awake()
    {
        bgmS = GameObject.Find("BgmS").GetComponent<Slider>();
        effectS = GameObject.Find("EffectS").GetComponent<Slider>();
        responsiveS = GameObject.Find("ResponsiveS").GetComponent<Slider>();

        if (!PlayerPrefs.HasKey("BgmV"))
        {
            ResetData();
        }
    }

    public void ResetData()
    {
        PlayerPrefs.SetFloat("BgmV", 0.5f);
        PlayerPrefs.SetFloat("EffectV", 0.5f);
        PlayerPrefs.SetFloat("ResponsiveV", 0.5f);
    }

    public void ReValueSlide()
    {
        bgmS.value = PlayerPrefs.GetFloat("BgmV");
        effectS.value = PlayerPrefs.GetFloat("EffectV");
        responsiveS.value = PlayerPrefs.GetFloat("ResponsiveV");
    }

    public void PushSlideData()
    {
        PlayerPrefs.SetFloat("BgmV", bgmS.value);
        PlayerPrefs.SetFloat("EffectV", effectS.value);
        PlayerPrefs.SetFloat("ResponsiveV", responsiveS.value);
    }
}

