using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public int Health = 100;
    private Slider _healthSlider;
    private GameObject _uiHolder;




    // Start is called before the first frame update
    void Start()
    {
        _healthSlider = GameObject.Find("HealthBar").GetComponent<Slider>();
        _healthSlider.value = Health;
        _uiHolder = GameObject.Find("UIholder");



        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


  public   void ApplyDamage(int Damage)
    {
        Health -= Damage;

        if (Health < 0)
        {
            Health = 0;
        }

        _healthSlider.value = Health;

        if(Health == 0)
        {
            _uiHolder.SetActive(false);
            GamePlay_Controller.Instance.GameOver();

        }


    }





}
