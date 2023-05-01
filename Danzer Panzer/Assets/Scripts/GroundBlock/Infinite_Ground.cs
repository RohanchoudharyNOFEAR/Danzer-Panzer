using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infinite_Ground : MonoBehaviour
{

    public Transform otherBlock;
    public float _halfLength = 100f;
    private float _endset=10f;
    public Transform Player;

   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveGround();
    }
   

    private void MoveGround()
    {
        if(transform.position.z + _halfLength < Player.transform.position.z -_endset )
        {
            transform.position = new Vector3(otherBlock.position.x, otherBlock.position.y, otherBlock.position.z + _halfLength * 2);

        }

    }





}
