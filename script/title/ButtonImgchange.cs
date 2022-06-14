using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonImgchange : MonoBehaviour
{
    [SerializeField]
    private Image img;

    [SerializeField]
    Sprite on;
    [SerializeField]
    Sprite off;

    private bool flg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeImage()
    {
        img.sprite = (flg) ? on : off;
        flg = !flg;
    }

}
