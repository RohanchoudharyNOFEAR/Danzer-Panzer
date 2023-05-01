using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController: BaseController
{

    private Rigidbody _mybody;

    public Transform Bullet_startpoint;
    public GameObject Bullet_prefab;
    public ParticleSystem ShootFx;
    public Animator Shoot_Slider_anim;
    [HideInInspector]
    public bool CanShoot;


    // Start is called before the first frame update
    void Start()
    {

        _mybody = GetComponent<Rigidbody>();
        GameObject.Find("ShootBtn").GetComponent<Button>().onClick.AddListener(ShootControl);
        CanShoot = true;
        Shoot_Slider_anim = GameObject.Find("FireBar").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ControlMovementInput();
      
    }

    private void FixedUpdate()
    {
        _ChangeRotation();
        Movement();
    }

    private void Movement()
    {
        _mybody.MovePosition(_mybody.position + _speed * Time.deltaTime);

    }

    private void ControlMovementInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MoveLeft();


        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            MoveFast();
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            MoveSlow();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            Movestraight();


        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            Movestraight();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            MoveNormal();
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            MoveNormal();
        }
    }
    
       void _ChangeRotation()
        {

            if (_speed.x > 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, _MaxAngle, 0f), Time.deltaTime * _RotationSpeed);

            }
            else if (_speed.x < 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, -_MaxAngle, 0f), Time.deltaTime * _RotationSpeed);
            }

            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * _RotationSpeed);
            }         
            
        }


    public void ShootControl()
    {
        if (Time.timeScale !=0 && CanShoot)
        {
            GameObject Bullet = Instantiate(Bullet_prefab, Bullet_startpoint.position, Quaternion.identity);

            Bullet.GetComponent<BulletScript>().Move(2000f);
            ShootFx.Play();

            CanShoot = false;

            // play anim
            Shoot_Slider_anim.Play("fill");
        }


    }

}
