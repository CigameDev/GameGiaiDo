using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//class nay dung de Set dap an cho cac nut dap an
public class AnswerButton : MonoBehaviour
{
    public Text answerText;
    public Button btnComp;
    public void SetAnswerText(string content)
    {
        if(answerText)
        {
            answerText.text = content;
        }    
    }    
}
