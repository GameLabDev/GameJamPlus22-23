using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class PlayerManager : MonoBehaviour
{
    private InputManager inputManager;
    private LocomotionManager locomotionManager;
    public float Health;
    public Slider sliderHealth;
    public string namee;
    public EnemyManager enemy;
    public bool isp1;
    void Start()
    { 
        sliderHealth = GameObject.Find(namee).GetComponent<Slider>();
        inputManager = GetComponent<InputManager>();
        locomotionManager = GetComponent<LocomotionManager>();
    }

    void Update()
    {
        if(inputManager.enabled)
            inputManager.HandleInput();
    }
    private void FixedUpdate()
    {
        if (Health <= 0) {
            GameObject.Find("UIStats").GetComponentsInChildren<TMPro.TextMeshProUGUI>()[0].text = "Game Over!!";
            if (enemy.players.Length > 1)
            {
                if (enemy.score[0] > enemy.score[1])
                {
                    GameObject.Find("StatusTxt").GetComponent<TMPro.TextMeshProUGUI>().text = "The Best: Player 1";
                }
                else
                {
                    GameObject.Find("StatusTxt").GetComponent<TMPro.TextMeshProUGUI>().text = "The Best: Player 2";
                }
            }
            GameObject.Find("UIStats").transform.DOMove(new Vector3(Screen.width / 2f, Screen.height / 2f, 0.00f), 2f).OnComplete(() =>
            {
                Time.timeScale = 0f;
            });
        }
        if(locomotionManager.enabled)
            locomotionManager.HandleLocomotion();
    }

    internal void TakeDamage(int v)
    {
        Health -= v;
        sliderHealth.value = Health/10f;
    }
}
