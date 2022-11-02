using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public TMP_Text Question;
    public TMP_Text AnswerA;
    public TMP_Text AnswerB;
    public TMP_Text AnswerC;
    public TMP_Text AnswerD;

    // Start is called before the first frame update
    void Start()
    {
        Question.text = "How old I am?";
        AnswerA.text = "16";
        AnswerB.text = "13";
        AnswerC.text = "14";
        AnswerD.text = "23";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
