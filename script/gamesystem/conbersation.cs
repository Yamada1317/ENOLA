using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class conbersation : MonoBehaviour
{
    [SerializeField] private Text dataText;
    [SerializeField] private TextAsset textAsset;
    [SerializeField] private systemdata Systemdata;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private int number;

    private string loadText1;
    private string[] splitText1;
    private int textnum1;
    // Start is called before the first frame update
    void Start()
    {
        loadText1 = textAsset.text;
        splitText1 = loadText1.Split(char.Parse("\n"));
        textnum1 = 0;
        if (splitText1[textnum1] != "")
        {
            dataText.text = splitText1[textnum1];
            textnum1++;
            if (textnum1 >= splitText1.Length)
            {
                textnum1 = 0;
            }
        }
        else
        {
            dataText.text = "";
            textnum1++;
        }
        Systemdata.textscenejudge = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Systemdata.scenemovejudge)
        {
            SceneManager.LoadScene(number);
        }
    }


    public void textload()
    {
        if (textnum1 < splitText1.Length)
        {
            if (splitText1[textnum1] != "")
            {
                dataText.text = splitText1[textnum1];
                textnum1++;

            }
            else
            {
                dataText.text = "";
                textnum1++;
            }
        }
        else
        {
            Systemdata.scenejudge = true;
        }
        audioSource.Play();
    }
}
