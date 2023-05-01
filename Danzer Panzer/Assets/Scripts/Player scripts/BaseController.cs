using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    
    public Vector3 _speed;
    public float x_speed = 8f, z_speed = 15f;
    public float accelerated = 20f, deaccelerated = 10f;
    protected float _RotationSpeed = 10f;
    protected float _MaxAngle = 10f;
    public float low_pitched_sound, normal_pitched_sound, high_pitched_sound;
    public AudioClip Engine_on_sound, Engine_off_sound;
    private bool _isSlow;
    private AudioSource _soundManager;



    private void Awake()
    {
        _soundManager = GetComponent<AudioSource>();
        _speed = new Vector3(0f, 0f, z_speed);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected void MoveLeft()
    {
        _speed = new Vector3(-x_speed / 2, 0f, _speed.z);

    }

    protected void MoveRight()
    {
        _speed = new Vector3(x_speed / 2, 0f, _speed.z);

    }

    protected void Movestraight()
    {
        _speed = new Vector3(0f, 0f, _speed.z);

    }
    protected void MoveNormal()
    {
        if (_isSlow)
        {
            _isSlow = false;
            _soundManager.Stop();
            _soundManager.clip = Engine_on_sound;
            _soundManager.volume = 0.3f;
            _soundManager.Play();
        }
        _speed = new Vector3(_speed.x, 0f, z_speed);

    }

    protected void MoveSlow()
    {
        if (!_isSlow)
        {
            _isSlow = true;
            _soundManager.Stop();
            _soundManager.clip = Engine_off_sound;
            _soundManager.volume = 0.5f;
            _soundManager.Play();
        }
        _speed = new Vector3(_speed.x, 0f, deaccelerated);

    }
    protected void MoveFast()
    {
        _speed = new Vector3(_speed.x, 0f, accelerated);
    }


}
