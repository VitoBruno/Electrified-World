using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    public int velocidade;

    public Player scriptPlayer;
    void Start()
    {
        scriptPlayer = FindObjectOfType(typeof(Player)) as Player;
    }

    void Update()
    {
        transform.position += new Vector3(velocidade, 0, 0) * Time.deltaTime;

        if (transform.position.x < -4.5)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D()
    {
        scriptPlayer.adicionarmoedas();
        gameObject.SetActive(false);
    }
}