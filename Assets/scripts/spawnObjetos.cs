using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObjetos : MonoBehaviour
{
    public float alturaMaxima;
    public float alturaMinima;

    public float tempoSpawn;

    private float execucaoSpawn;

    public int maximoObstaculos;

    public GameObject prefab;

    public List<GameObject> listaObstaculo;

    void Start()
    {
        for (int i = 0; i < maximoObstaculos; i++)
        {
            GameObject obstaculoTemporario = Instantiate(prefab) as GameObject;
            listaObstaculo.Add(obstaculoTemporario);
            obstaculoTemporario.SetActive(false);
        }
    }


    void Update()
    {
        execucaoSpawn += Time.deltaTime;

        if (execucaoSpawn > tempoSpawn)
        {
            execucaoSpawn = 0;

            Spawn();
        }
    }

    private void Spawn()
    {
        float posicaoAleatoria = Random.Range(alturaMinima, alturaMaxima);

        GameObject obstaculoTemporario = null;

        for (int i = 0; i < maximoObstaculos; i++)
        {
            if (listaObstaculo[i].activeSelf == false)
            {
                obstaculoTemporario = listaObstaculo[i];
                break;
            }
        }

        if (obstaculoTemporario != null)
        {
            obstaculoTemporario.transform.position = new Vector3(transform.position.x, posicaoAleatoria, transform.position.z);
            obstaculoTemporario.SetActive(true);
        }
    }
}