using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class ButtonAnimation : MonoBehaviour
{
    public Image img;
    public TextMeshProUGUI text;
    public Vector3 value;
    public Vector3 returnValue;

    public void AnimationEnter()
    {
        img.DOColor(Color.white, 0.2f);
        text.DOColor(Color.black, 0.2f);
    }
    public void AnimationExit()
    {
        text.DOColor(Color.white, 0.2f);
        img.DOColor(Color.black, 0.2f);
    }
}
