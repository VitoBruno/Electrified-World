using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController gc;
    public Text moedastext;
    public Text obstaculotext;
    public static int pontuacao;
    public static float moedas;
    // Start is called before the first frame update
    void Start()
    {
        if (gc == null)
        {
            gc = this;
        }
        else if (gc != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        moedastext.text = moedas.ToString();
        obstaculotext.text = pontuacao.ToString();
    }
    
    public void ChangeScene(Scene Jogo)
    {
        PlayerPrefs.SetInt("pontuacao1", pontuacao);
        //SceneManager.LoadScene(Jogo);
    }
}
