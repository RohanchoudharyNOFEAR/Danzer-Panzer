using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zombiescript : MonoBehaviour
{
    public GameObject Bloodfxprefab;
    public float Speed = 1f;
    private Rigidbody _mybody;
    private bool IsAlive;
    public AudioSource _audio;
    public AudioClip _zombiesmash;

    void Start()
    {
        _mybody = GetComponent<Rigidbody>();
       
        IsAlive = true;
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsAlive == true)
        {
            _mybody.velocity = new Vector3(0f, 0f, -Speed);

        }

        if (transform.position.y < -7)
        {
            gameObject.SetActive(false);
        }

    }
     void die()
    {
        _mybody.velocity = Vector3.zero;
        GetComponent<Collider>().enabled = false;
        GetComponentInChildren<Animator>().Play("idle");

        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        transform.localScale = new Vector3(1f, 1f, 0.2f);
        transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
        IsAlive = false;

    }
    void DeactivateGameobject()
    {
        gameObject.SetActive(false);
    }

     void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Bullet")
        {

            Instantiate(Bloodfxprefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_zombiesmash, transform.position);

            Invoke("DeactivateGameobject", 3f);


            GamePlay_Controller.Instance.IncreaseScore();


            die();

        }
        
    }

}
