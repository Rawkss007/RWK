using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projetil : MonoBehaviour
{
    public float posInicial;
    public float alcance = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x - posInicial > alcance || posInicial - transform.position.x > alcance)
        {
             Destroy(gameObject);
        }
    }
}
