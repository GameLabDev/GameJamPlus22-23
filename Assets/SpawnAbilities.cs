using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAbilities : MonoBehaviour
{
    public Transform[] points;
    public float timeAtack=5f;
    public GameObject[] Abilities;
    private void Start()
    {
        Invoke(nameof(SpawnPoints), timeAtack);
    }
    public void SpawnPoints() {
        GameObject gmo = Instantiate(Abilities[Random.Range(0,2)], points[Random.Range(0, points.Length - 1)]) as GameObject;
        float time = Random.Range(5f, 15f);
        Destroy(gmo, time);
        Invoke(nameof(SpawnPoints), time);
    }

}
