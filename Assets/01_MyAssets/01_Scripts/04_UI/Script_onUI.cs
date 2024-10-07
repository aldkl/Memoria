using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
[Serializable]
public class ScriptList
{
    public string InDex ;
    public string name  ;
    public Sprite sprite;
    public Sprite BackImage;
    public bool isLeft;
}

public class Script_onUI : MonoBehaviour
{
    public List<ScriptList> ScriptList;
    public Text Indexname;
    public TextingSc Index;
    public Image Left;
    public Animator Left_Ani;
    public Image Right;
    public Animator Right_Ani;
    public Image BackImage;
    public Sprite Blank;

    public GameObject IsGameObj;

    [ContextMenuItem("¿Ã∏ß", "Resetasdasdasd")]
    public int asdasd;


    private void Start()
    {
        Reset(false);
        Reset(true);
    }
    public void Resetasdasdasd()
    {
        Script(ScriptList[asdasd].InDex, ScriptList[asdasd].name, ScriptList[asdasd].sprite, ScriptList[asdasd].BackImage, ScriptList[asdasd].isLeft);
        asdasd++;
        if(asdasd == ScriptList.Count)
        {
            Application.Quit();
        }
        if(asdasd == 20)
        {
            Reset(false);
        }

        if (asdasd == 22)
        {
            IsGameObj.SetActive(false);
        }
    }

    public void Script(string InDex,string name,Sprite sprite, Sprite Back, bool isLeft)
    {
        BackImage.sprite = Back;
        Indexname.text = name;
        Index.Texting(InDex);
        if(isLeft)
        {
            Left.color = new Color(1, 1, 1, 1);
            Left.sprite = sprite;
            Left_Ani.gameObject.SetActive(false);
            Left_Ani.gameObject.SetActive(true);
            Left_Ani.Play(0);
            Right.color = new Color(0.7f, 0.7f, 0.7f, 1);
        }
        else
        {
            Right.color = new Color(1, 1, 1, 1);
            Right.sprite = sprite;
            Right_Ani.gameObject.SetActive(false);
            Right_Ani.gameObject.SetActive(true);
            Right_Ani.Play(0);
            Left.color = new Color(0.7f, 0.7f, 0.7f, 1);
        }
    }
    public void Reset(bool isLeft)
    {
        if (isLeft)
        {
            Left.sprite = Blank;
            Left.color = new Color(1, 1, 1, 1);
        }
        else
        {
            Right.sprite = Blank;
            Right.color = new Color(1, 1, 1, 1);
        }
    }
}
