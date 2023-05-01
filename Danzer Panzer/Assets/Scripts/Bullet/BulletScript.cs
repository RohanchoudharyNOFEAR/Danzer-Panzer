using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody MyBody;
    


    
    void Start()
    {
        
    }

    // Update is called once per frame
  

    public void Move(float speed)
    {
        MyBody.AddForce(transform.forward.normalized * speed);
        Invoke("DeactivateBullet", 4f);
    }


    public void DeactivateBullet()
    {
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle" || other.gameObject.tag =="Zombie")
        {
            gameObject.SetActive(false);
        }
        
    }
}
