using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleExplosives : MonoBehaviour
{


    
    public GameObject _explosionPrefab;
    public int Damage = 20;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.tag == "Player")
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);

            other.gameObject.GetComponent<PlayerHealth>().ApplyDamage(Damage);

            gameObject.SetActive(false);
        }
       else if(other.gameObject.tag == "Bullet")
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }




   



}
