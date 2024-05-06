using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    
    public void LoadScenes(string cena)
    {
        SceneManager.LoadScene(cena);
    }
    public void Quit()
    {
        Application.Quit();
    }
    void Start()
    {
    }
}
