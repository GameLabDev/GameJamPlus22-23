using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class EnemyManager : MonoBehaviour
{
    public EnemyAI[] enemies;
    public GameObject[] players;
    public bool flag;
    public float timeAtack = 2;
    public int health = 5;
    public int QuantiitySpawn;
    public int SpawnedQuantity;
    public bool runned;
    public GameObject Enemy;
    public Slider slider;
    public float startQuanSpawn;
    public Transform[] Points;
    public int[] score;
    public bool hasWin = false;
    private void Start()
    {
        if(players.Length == 1)
        {
            GameObject.Find("StatusTxt").SetActive(false);
        }
        startQuanSpawn = QuantiitySpawn;
        Invoke(nameof(ResetAttack), 1);
    }
    public void ResetAttack()
    {
        flag = false;
        enemies = GetComponentsInChildren<EnemyAI>();
        foreach (EnemyAI eai in enemies)
        {
            if (eai.atacking)
                flag = true;
            break;

        }
        if (flag) Invoke(nameof(ResetAttack), timeAtack);
        foreach (EnemyAI eai in enemies)
        {
            eai.LookAtNoYAxis(eai.player.gameObject);
            eai.atacking = false;
        }
        if (!flag && enemies.Length > 0)
        {
            int value = Random.Range(0, enemies.Length);
            enemies[value].player = players[Random.Range(0, players.Length)].GetComponent<LocomotionManager>();
            enemies[value].atacking = true;
        }
        Invoke(nameof(ResetAttack), timeAtack);
    }
    private void Update()
    {
        if(!hasWin && runned && QuantiitySpawn == 0 && enemies.Length == 0 && (players[0].GetComponent<PlayerManager>().Health != 0|| (players[players.Length -1].GetComponent<PlayerManager>().Health != 0)))
        {
            hasWin = true;
            GameObject.Find("UIStats").GetComponentsInChildren<TMPro.TextMeshProUGUI>()[0].text = "Win!!";
            if (players.Length >= 1)
            {
                if (score[0] > score[1])
                {
                    GameObject.Find("StatusTxt").GetComponent<TMPro.TextMeshProUGUI>().text = "The Best: Player 1";
                }
                else
                {
                    GameObject.Find("StatusTxt").GetComponent<TMPro.TextMeshProUGUI>().text = "The Best: Player 2";
                }
            }
            GameObject.Find("UIStats").transform.DOMove(new Vector3(Screen.width / 2f, Screen.height / 2f, 0.00f), 2f).OnComplete(() => {
                Time.timeScale = 0f;
            });
        }
        if(QuantiitySpawn != 0 && enemies.Length <= 1)
        {
            runned = true;
            for(int i = 0; i < 10; i++)
            {
                if (QuantiitySpawn == 0) return;
                GameObject Enemyobj = Instantiate(Enemy,Points[Random.Range(0, Points.Length - 1)]);
                Enemyobj.transform.SetParent(transform);
                Enemyobj.GetComponent<EnemyAI>().player = players[Random.Range(0, players.Length)].GetComponent<LocomotionManager>();
                QuantiitySpawn--;
                SpawnedQuantity++;
                slider.value = 1f - (SpawnedQuantity / startQuanSpawn);
            }
            enemies = GetComponentsInChildren<EnemyAI>();
        }
    }
    private void InstantiateEnemy()
    {
            
    }
}
