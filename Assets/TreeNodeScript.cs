using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreeNodeScript : MonoBehaviour
{
    public string saveKey;

    public SaveHandler saveScript;
    public UnityEngine.UI.Image image;

    public Sprite saveImage;

    void Start()
    {
        if (saveScript.IsSave(saveKey))
        {
            //print("joo");
            image.sprite = saveImage;
        }
        else
        {
            //print("ei");
        }
        
    }

    
}
