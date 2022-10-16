using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UiMenuManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textCredits;
    public ButtonAnimation btn1, btn2, btn3;
    public float duration;
    public string TargetText = "The Team ; Felipe Rodrigues de Oliveira - Artista 2D/3D ; Carolina Cristina Tolentino Alves - Artista 3D ; Marco Antônio da Silva - Programador ; Guilherme Leandro De Cicco - Game Designer ; Ana Carolina Candido de Campos - Roterista ; Marcelo Targa - Sound Designer";
    public GameObject Creditos;
    public string start = "";
    public void LoadGame(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    public void OnCreditos()
    {
        btn1.gameObject.SetActive(false);
        btn2.gameObject.SetActive(false);
        btn3.gameObject.SetActive(false);
        btn3.img.color = Color.black;
        btn3.text.color = Color.white;
        Creditos.SetActive(true);
        DOVirtual.DelayedCall(5f, () => {
            Creditos.SetActive(false);
            btn1.gameObject.SetActive(true);
            btn2.gameObject.SetActive(true);
            btn3.gameObject.SetActive(true);
        });
    }
}
