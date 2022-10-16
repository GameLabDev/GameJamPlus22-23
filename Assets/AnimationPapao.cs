using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AnimationPapao : MonoBehaviour
{

    private void Start()
    {
        ShortcutExtensions.DOShakeRotation(transform,0.5f,10).SetLoops(-1);
    }
}
