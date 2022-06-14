using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEffectHelp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{



    public EffectModel _effectModel;
    public Sprite enterImage;
    public Color enterColor;

    private Sprite beginImage;
    private Color beginColor;

    [SerializeField]
    private Image _image;
    private void Start()
    {
        //_image = transform.GetComponent<Image>();
        beginImage = _image.sprite;
        beginColor = _image.color;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {

        switch (_effectModel)
        {
            case EffectModel.IMAGE:

                _image.sprite = enterImage;

                break;
            case EffectModel.COLOR:
                _image.color = enterColor;
                break;
            default:
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        switch (_effectModel)
        {
            case EffectModel.IMAGE:

                _image.sprite = beginImage;

                break;
            case EffectModel.COLOR:
                _image.color = beginColor;
                break;
            default:
                break;
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        switch (_effectModel)
        {
            case EffectModel.IMAGE:

                _image.sprite = beginImage;

                break;
            case EffectModel.COLOR:
                _image.color = beginColor;
                break;
            default:
                break;
        }
    }


    public enum EffectModel
    {
        IMAGE,
        COLOR
    }
}
