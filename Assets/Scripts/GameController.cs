using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int m_rightCount;
    private float m_CurTime;
    public float timePerQuestion;

    private void Awake()
    {
        m_CurTime = timePerQuestion;
    }
    void Start()
    {
        UiManager.Ins.SetTimeText("00 : "+m_CurTime);
        CreateQuestion();//Stuff phai de o awake vi phai khoi tao ra vi tri dung thi tao cau hoi moi biet vi tri dung
        //de ma gan ,khong thi doi luc se bi nham lan
        //chu y cac ham goi lai nhau neu thay loi thi hay de y den awake va start
        StartCoroutine(TimeLine());
    }
   
    public void CreateQuestion()
    {
        QuestionData qs = QuestionManager.instance.RandomQuestion();
        if(qs!=null)
        {
            UiManager.Ins.SetQuestionText(qs.question);//truy cap vao Uimanager de gan cau hoi len text cau h?i
            string[] wrongAnswer = new string[] {qs.answerA,qs.answerB,qs.answerC};
            UiManager.Ins.ShuffAnswers();//random ra nut co cau tra loi dung,cac nut con lai co cau tra loi sai
            var temp = UiManager.Ins.answerButtons;//temp = mang cac cau tra loi
            if(temp!=null && temp.Length>0)
            {
                int wrongAnswerCount = 0;
                for(int i=0;i<temp.Length;i++)
                {
                    int answerId = i;
                    if (temp[i].tag == "RightAnswer")
                    {
                        temp[i].SetAnswerText(qs.rightAnswer);
                    }
                    else
                    {
                        temp[i].SetAnswerText(wrongAnswer[wrongAnswerCount]);
                        wrongAnswerCount++;
                    }
                    temp[answerId].btnComp.onClick.RemoveAllListeners();//xoa tat ca listerrer tr??c ?i,dam bao an toàn thoi
                    temp[answerId].btnComp.onClick.AddListener(() => CheckRightAnswerEvent(temp[answerId]));
                }    
            }    
        }    
    }    

    void CheckRightAnswerEvent(AnswerButton answerButton)
    {
        //Khi nhan vao right answer va khi nhan wrong answer
        if(answerButton.CompareTag("RightAnswer"))
        {
            AudioController.instance.PlayRightSound();
            m_rightCount++;
            if (m_rightCount == QuestionManager.instance.questionDatas.Length)
            {
                Debug.Log("Ban da gianh chien thang");
                UiManager.Ins.dialog.SetDialogContent("Ban da gianh chien thang !");
                UiManager.Ins.dialog.Show(true);
                AudioController.instance.PlayWinSound();

            }    
            else
            {
                CreateQuestion();
            }    
        }
        else
        {
            Debug.Log("Ban da tra loi sai,tro choi ket thuc ");
            
            UiManager.Ins.dialog.SetDialogContent("Ban da thua ,tro choi ket thuc !");
            UiManager.Ins.dialog.Show(true);
            AudioController.instance.PlayLoseSound();
        }
    }  
    public void ExitGame()
    {
        Application.Quit();
    }   
    public void ReplayGame()
    {
        AudioController.instance.StopMusic();//khi nguoi choi nhan vao replay thi dung phat nhac
        SceneManager.LoadScene("GamePlay");
    }
    private IEnumerator TimeLine()
    {
        yield return new WaitForSeconds(1f);
        if (m_CurTime > 0)
        {
            m_CurTime--;
            if (m_CurTime >= 10)
            {
                UiManager.Ins.SetTimeText("00 : " + m_CurTime);
            }
            else
            {
                UiManager.Ins.SetTimeText("00 : 0" + m_CurTime);
            }

        }
        else
        {
            UiManager.Ins.dialog.SetDialogContent("Het thoi gian,ban da thua cuoc : ");
            UiManager.Ins.dialog.Show(true);
            StopAllCoroutines();
            AudioController.instance.PlayLoseSound();
        } 
            
        StartCoroutine(TimeLine());
    }
}
