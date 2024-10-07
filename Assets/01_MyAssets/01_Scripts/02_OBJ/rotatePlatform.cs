using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePlatform : MonoBehaviour
{

    float rotateTime;
    float RotateSpeed;

    public float MaxrotateTime;
    bool OnRotate;

    int Num;
    void Start()
    {
        
    }

    void Update()
    {
        rotateTime += Time.deltaTime;
        if(!OnRotate)
        {
            if (MaxrotateTime <= rotateTime)
            {
                if (OnRotate) OnRotate = false;
                else
                {
                    OnRotate = true;
                    Num++;
                }
                rotateTime = 0;
            }
        }

        if(OnRotate)
        {
            transform.Rotate(RotateSpeed * Time.deltaTime, 90, -90, Space.Self);
            if(Num * 90 >= transform.rotation.eulerAngles.z)
            {
                transform.rotation = Quaternion.Euler(Num * 90, 90, -90);
                OnRotate = false;
            }
        }
    }

}
