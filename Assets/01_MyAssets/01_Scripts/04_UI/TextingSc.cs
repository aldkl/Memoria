using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextingSc : MonoBehaviour
{
    public Text text;
    public float intervarl=0;
    string Index = "";
    int Indexnum=0;
    float PlayBackTime=0;
    void Update()
    {
        if(Index.Length > Indexnum)
        {
            PlayBackTime += Time.deltaTime;
            if (intervarl < PlayBackTime)
            {
                PlayBackTime = 0;
                Indexnum++;
                text.text = Index.Substring(0, Indexnum);
            }
        }
    }
    public void Texting(string texttt)
    {
        Index = texttt;
        PlayBackTime = 0;
        Indexnum = 0;
    }
}
