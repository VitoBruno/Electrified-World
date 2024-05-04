using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{

    public float velocidade = 0;
    private Material textura;
    private GameObject player;

    private float posicao = 0;

    void Start()
    {
        textura = GetComponent<Renderer>().material;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        var lado = player.transform.localScale.x;
        posicao += velocidade * lado;

        textura.mainTextureOffset = new Vector2(posicao, 0);
    }
}