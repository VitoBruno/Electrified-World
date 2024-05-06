using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float speed;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += (Vector2.right * (speed * Time.deltaTime));
    }
}