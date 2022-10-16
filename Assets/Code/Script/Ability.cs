using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    public UnityEvent OnStartAction;
    public Tween tw;
    public float cowdown;
    public Slider slider;
    public float time;
    public bool isReady;
    public string namee;
    public Sprite sprEnabled;
    public Sprite sprDisabled;
    public float timeUsing;
    
    public void ReadyAbility()
    {
        timeUsing -= Time.deltaTime;

        time += Time.deltaTime;
        if(time >= cowdown)
        {
            slider.value = 1f;
            isReady = true;
        }
        else
        {
            slider.value = time / cowdown;
            isReady = false;
        }
    }
    private void OnDisable()
    {
        if (slider != null)
            if (slider.GetComponentInChildren<Image>() != null)
            {
                slider.GetComponentInChildren<Image>().sprite = sprDisabled;
                slider.value = 0;
            }
    }
    private void OnEnable()
    {
        if (slider != null)
            if (slider.GetComponentInChildren<Image>() != null)
                slider.GetComponentInChildren<Image>().sprite = sprEnabled;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.tag == "Target")
        {
            tw.Kill();
        }
    }
}
