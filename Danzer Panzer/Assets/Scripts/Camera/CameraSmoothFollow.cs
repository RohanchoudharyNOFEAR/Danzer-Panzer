using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour
{

    public float Distance = 6.3f;
    public Transform Target;
    public float Height = 3.5f;

    public float Height_Dumping = 3.25f;
    public float Rotation_Dumping= 0.27f;






    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void LateUpdate()
    {
        follow();

    }

    private void follow()
    {
        float Wanted_Rotation = Target.eulerAngles.y;
        float Wanted_Height = Target.position.y + Height;
        

        float Current_Rotation_Angle = transform.eulerAngles.y;
        float Current_Heigth = transform.position.y;

        // here, we are making our camrea rotate with current_rotation_anagle to wanted_rotation in time (rotation_dumping)
        // and to do that we use lerpangle for rotation
        Current_Rotation_Angle = Mathf.LerpAngle(Current_Rotation_Angle, Wanted_Rotation, Rotation_Dumping * Time.deltaTime);

        // here, we are moving our camera from currentheigth from watned heigth using lerp
        // lerp will linearly move the camera to desgired position 
        Current_Heigth = Mathf.Lerp(Current_Heigth, Wanted_Height, Height_Dumping * Time.smoothDeltaTime);

        Quaternion Current_rotation = Quaternion.Euler(0f, Current_Rotation_Angle, 0f);


        transform.position = Target.position;
        // here, we are making distance between player and camera both lines 
        transform.position -= Current_rotation *Vector3.forward *Distance;
        transform.position = new Vector3(transform.position.x, Current_Heigth, transform.position.z);



    }













}
