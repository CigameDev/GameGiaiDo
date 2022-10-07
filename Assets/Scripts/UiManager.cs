using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager Ins;
    public Text timeText;
    public Text questionText;
    public Dialog dialog;
    public AnswerButton[] answerButtons;//mang 4 dap an
    private void Awake()
    {
        MakeSingleton();
        //ShuffAnswers();//?? ? start bi sai ? Tim hieu nguyen nhan 
    }
    private void Start()
    {
        //ShuffAnswers();
    }
    public void SetTimeText(string content)
    {
        if(timeText)
        {
            timeText.text = content;
        }    
    }   
    public void SetQuestionText(string content)
    {
        if(questionText)
        {
            questionText.text = content;
        }    
    }   
    
    public void ShuffAnswers()//ham de quy dinh dap an dung ngau nhien,dap an dung co tag rightanswer con lai la untagged
    {
        if(answerButtons != null && answerButtons.Length >0)
        {
            for(int i=0;i<answerButtons.Length;i++)//gan tat ca cac nut dap an(4) co tag la Untagged
            {
                if (answerButtons[i])
                {
                    answerButtons[i].tag = "Untagged";
                }    
            }
            int randIdx = Random.Range(0, answerButtons.Length - 1);//random ra 1 cai button va gan tag RightAnswer
            if (answerButtons[randIdx])
            {
                answerButtons[randIdx].tag = "RightAnswer";
            }    
        }    
    }    

    public void MakeSingleton()
    {
        if(Ins == null)
        {
            Ins = this;
        }
        else
        {
            Destroy(gameObject);//neu Ins da co roi thi huy di(chinh no)
        } 
            
    }    
}
