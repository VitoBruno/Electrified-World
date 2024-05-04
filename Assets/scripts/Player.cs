using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rdb2d;
    Animator anim;
    AudioSource audioSource;

    [SerializeField] AudioClip efeitoSonoroPontuacao;
    [SerializeField] AudioClip efeitoSonoroMoedas;

    public bool inFloor = true;
    public float pulo;
    void Start()
    {
        GameController.moedas = 0;
        rdb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && inFloor)
        {
            rdb2d.AddForce(new Vector2(0, pulo), ForceMode2D.Impulse);
            inFloor = false;
            anim.SetBool("pulando", true);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ground")
        {
            anim.SetBool("pulando", false);
            inFloor = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "obstaculo")
        {
            anim.SetTrigger("morrendo");
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rdb2d.bodyType = RigidbodyType2D.Kinematic;
            gameObject.GetComponent<Player>().enabled = false;
            Invoke("LoadGameOver", 2f);
        }
        
    }
    
    public void adicionarpontos()
    {
        GameController.pontuacao++;
        audioSource.PlayOneShot(efeitoSonoroPontuacao);
    }

    public void adicionarmoedas()
    {
        GameController.moedas++;
        audioSource.PlayOneShot(efeitoSonoroMoedas);
    }
    void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
}