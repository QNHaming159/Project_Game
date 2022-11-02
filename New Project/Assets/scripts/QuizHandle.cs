using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizHandle : MonoBehaviour {
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

    //Public Variable
    public int Index, TotalQuestion, true_num;

    //Check if answer true
    void Checkiftrue (int button) {
        if (Index<=TotalQuestion-1) {
            //Correct answer
            if (true_num == button) {
                print("Correct!");
            }
            //Wrong answer
            else {
                print("Wrong!");
            }
        }
    }

    //New_Question function
    void New_Question() {
        if (Index<=TotalQuestion-1) {

            //Get true button
            true_num = Random.Range(1,5);
            Question_Text.text = Data[Index].Question;
            switch (true_num) {
                case 1:
                    AnswerA_Text.text = Data[Index].TrueAnswer;
                    AnswerB_Text.text = Data[Index].FalseAnswer1;
                    AnswerC_Text.text = Data[Index].FalseAnswer2;
                     AnswerD_Text.text = Data[Index].FalseAnswer3;
                     break;
                case 2:
                    AnswerA_Text.text = Data[Index].FalseAnswer1;
                    AnswerB_Text.text = Data[Index].TrueAnswer;
                    AnswerC_Text.text = Data[Index].FalseAnswer2;
                    AnswerD_Text.text = Data[Index].FalseAnswer3;
                    break;
                case 3:
                    AnswerA_Text.text = Data[Index].FalseAnswer1;
                    AnswerB_Text.text = Data[Index].FalseAnswer2;
                    AnswerC_Text.text = Data[Index].TrueAnswer;
                    AnswerD_Text.text = Data[Index].FalseAnswer3;
                    break;
                case 4:
                    AnswerA_Text.text = Data[Index].FalseAnswer1;
                    AnswerB_Text.text = Data[Index].FalseAnswer2;
                    AnswerC_Text.text = Data[Index].FalseAnswer3;
                    AnswerD_Text.text = Data[Index].TrueAnswer;
                    break;
                }
            Index += 1;
        }
    }


    //Start function
    void Start() {
        //Update variable
        TotalQuestion = Data.Count;
        Index = 0;

        New_Question();
    }

    //Button controller
    public void ButtonA() {
        Checkiftrue(1);
        New_Question();
    }
    public void ButtonB() {
        Checkiftrue(2);
        New_Question();
    }
    public void ButtonC() {
        Checkiftrue(3);
        New_Question();
    }
    public void ButtonD() {
        Checkiftrue(4);
        New_Question();
    }
}