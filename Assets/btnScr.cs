using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnScr : MonoBehaviour
{
    public void Reload()
    {
        SceneManager.LoadScene("CoreMechanicPrototype");
    }
}
