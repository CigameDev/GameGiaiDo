using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//class nay dung de an va hien Dialog ,thay doi thong bao cho dialog
public class Dialog : MonoBehaviour
{
    
    public Text dialogContentText;

    

    public void Show(bool isShow)
    {
        gameObject.SetActive(isShow);
    }    
    public void SetDialogContent(string content)
    {
        if(dialogContentText != null)
            dialogContentText.text = content;
    }  
    
}
