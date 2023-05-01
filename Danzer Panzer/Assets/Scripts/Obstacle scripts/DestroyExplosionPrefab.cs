using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosionPrefab : MonoBehaviour
{
    public float Timer = 3f;
    void Start()
    {
        Invoke("Destroyprefab", Timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void Destroyprefab()
    {
        gameObject.SetActive(false);
    }
}
