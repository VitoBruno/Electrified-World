using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamentoObstaculo : MonoBehaviour
{
    public float velocidade;

    private Player scriptPlayer;

    private bool passou;
    void Start()
    {
        scriptPlayer = FindObjectOfType(typeof(Player)) as Player;
    }
    void Update()
    {
        transform.position += new Vector3(velocidade, 0, 0) * Time.deltaTime;

        if (transform.position.x < scriptPlayer.transform.position.x && !passou)
        {
            scriptPlayer.adicionarpontos();
            passou = true;
        }

        if (transform.position.x < -4.5)
        {
            gameObject.SetActive(false);
        }
    }
    

    private void OnEnable()
    {
        passou = false;
    }
}