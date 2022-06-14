using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bgmvlume : MonoBehaviour
{
    public Slider BgmSlider;
    public Slider seSlider;
    public Slider voiceSlider;

    // Start is called before the first frame update
    void Start()
    {
        //BGM,SE,voiceの音量代入
        voiceSlider.value = notchange.voicechange;
        BgmSlider.value = notchange.bgmchange;
        seSlider.value = notchange.sechange;
    }

    // Update is called once per frame
    void Update()
    {
        notchange.bgmchange = BgmSlider.value;
        notchange.sechange = seSlider.value;
        notchange.voicechange = voiceSlider.value;
    }
}
