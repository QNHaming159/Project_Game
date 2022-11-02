using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionData : MonoBehaviour {

    //TMP_Text
    public TMP_Text Question_Text;
    public TMP_Text AnswerA_Text;
    public TMP_Text AnswerB_Text;
    public TMP_Text AnswerC_Text;
    public TMP_Text AnswerD_Text;

    //Question List
    [System.Serializable]
    public class DataList {
        public string Question;
        public string TrueAnswer;
        public string FalseAnswer1;
        public string FalseAnswer2;
        public string FalseAnswer3;
    }
    public List<DataList> Data;

    //Start function
    void Start() {
        Question_Text.text = Data[2].Question;
        AnswerA_Text.text = "16";
        AnswerB_Text.text = "13";
        AnswerC_Text.text = "14";
        AnswerD_Text.text = "23";
    }
}