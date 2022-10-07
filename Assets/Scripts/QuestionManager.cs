using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//public class QuestionManager : MonoBehaviour
//{

//    public QuestionData[] questions;
//    List<QuestionData> m_questions;
//    QuestionData m_curQuestion;

//    public QuestionData CurQuestion { get => m_curQuestion; set => m_curQuestion = value; }

//    private void Awake()
//    {
//        m_questions = new List<QuestionData>();
//        m_questions = questions.ToList();
//        Debug.Log(GetRandomQuestion().question);
//    }
//    public QuestionData GetRandomQuestion()
//    {
//        if(m_curQuestion==null && m_questions.Count >0)//
//    //    if(m_questions.Count >0)
//        {
//            int randIdx = Random.Range(0, m_questions.Count-1);
//            m_curQuestion = m_questions[randIdx];
//            m_questions.RemoveAt(randIdx);//xoa di luon,tranh bi lap
//        }    
//        return m_curQuestion;
//    }    
//}


public class QuestionManager : MonoBehaviour
{
    public static QuestionManager instance;

    public QuestionData[] questionDatas;
    private List<QuestionData> questionList;
    private QuestionData m_CurQuestion;
    
    public QuestionData CurQuestion { get => m_CurQuestion; set => m_CurQuestion = value; }

    private void Awake()
    {
        this.MakeSingleton();

        questionList = new List<QuestionData>();
        questionList = questionDatas.ToList();
    }
    private void Update()
    {
        
    }
    public QuestionData RandomQuestion()
    {
        if(questionList.Count>0 && questionList!=null)
        {
            int randomIdx = Random.Range(0,questionList.Count);
            m_CurQuestion = questionList[randomIdx];
            questionList.RemoveAt(randomIdx);
        }    
        return m_CurQuestion;
    }    
    public void MakeSingleton()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        } 
            
    }    
    
}