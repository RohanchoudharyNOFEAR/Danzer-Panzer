using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEvents : MonoBehaviour
{
    private PlayerController _playerController;
    private Animator _anim;




    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CameraStartGame()
    {
        SceneManager.LoadScene("GamePlay");
    } 


    void ResetShooting()
    {
        _playerController.CanShoot = true;
        _anim.Play("Idle");
    }

}
