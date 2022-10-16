using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FireBallScript : MonoBehaviour
{
    public float duration, distance;
    public Tween tw;
    EnemyTargetManager target;
    void Start()
    {

        target = FindObjectOfType<EnemyTargetManager>();
        if (target.target == null)
        {

            tw = transform.DOMove(transform.position + transform.forward * distance, duration).OnComplete(() =>
            {
                Destroy(gameObject);
            });
        }
        else
        {
            tw = transform.DOMove(target.target.transform.position, duration).OnComplete(() =>
            {
                Destroy(gameObject);
            });
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<EnemyAI>(out EnemyAI e)){
            e.TakeDamage(2);
            tw.Kill();
            Destroy(this.gameObject);
        }
        
    }
}
