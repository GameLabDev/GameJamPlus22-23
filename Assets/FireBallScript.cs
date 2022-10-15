using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FireBallScript : MonoBehaviour
{
    public float duration, distance;
    public Tween tw;
    void Start()
    {
        tw = transform.DOMove(transform.position + transform.forward * distance, duration).OnComplete(()=> {
            Destroy(gameObject);
        });
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<EnemyScript>(out EnemyScript e)){
            e.health--;
            tw.Kill();
            Destroy(this.gameObject);
        }
        
    }
}
