using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPlatform : MonoBehaviour
{


    public GameObject[] BlacksObj;

    public float ChangeTime;
    public float NowChangeTime;
    public int PerNum = -1;
    public int CurNum = 0;
    public int MaxNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        MaxNum = BlacksObj.Length;
    }

    // Update is called once per frame
    void Update()
    {

        NowChangeTime += Time.deltaTime;
        if (ChangeTime <= NowChangeTime)
        {
            NowChangeTime = 0;
            CurNum++;
            if (CurNum == MaxNum)
            {
                CurNum = 0;
            }
            if (PerNum != CurNum)
            {
                for (int i = 0; i < MaxNum; i++)
                {
                    if (i == CurNum)
                    {
                        BlacksObj[i].SetActive(true);
                    }
                    else
                    {
                        BlacksObj[i].SetActive(false);
                    }
                }
            }
        }

    }
}
