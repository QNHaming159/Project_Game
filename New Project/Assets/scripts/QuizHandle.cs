using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizHandle : MonoBehaviour {
    //Buttons
    public Button Button_A;
    public Button Button_B;
    public Button Button_C;
    public Button Button_D;

    //TMP_Texts
    public TMP_Text Question_Text;
    public TMP_Text AnswerA_Text;
    public TMP_Text AnswerB_Text;
    public TMP_Text AnswerC_Text;
    public TMP_Text AnswerD_Text;

    //Questions List
    [System.Serializable]
    public class DataList {
        public string Question;
        public string TrueAnswer;
        public string FalseAnswer1;
        public string FalseAnswer2;
        public string FalseAnswer3;
    }
    public List<DataList> Data;

    //Animation
    Animator animator;

    //Variable
    int Index, TotalQuestion, true_num;
    bool Pause = false;
    float delay_time = 3f;
    
    ////////////////////////////////////////////////////////////////////////////////

    //refresh button color
    void refresh_color() {
        Button_A.GetComponent<Image>().color = Color.white;
        Button_B.GetComponent<Image>().color = Color.white;
        Button_C.GetComponent<Image>().color = Color.white;
        Button_D.GetComponent<Image>().color = Color.white;
    }

    //Check if answer true
    void Checkiftrue(int button) {
        if (!(Index<=TotalQuestion)) {return;}
        if (!(Pause==false)) {return;}

        Button_manager();
        //Highlight wrong answer
        if (true_num != button) {
            switch (button) {
            case 1:
                Button_A.GetComponent<Image>().color = Color.red;
                break;
            case 2:
                Button_B.GetComponent<Image>().color = Color.red;
                break;
            case 3:
                Button_C.GetComponent<Image>().color = Color.red;
                break;
            case 4:
                Button_D.GetComponent<Image>().color = Color.red;
                break;
            }
            // <= enemy attack
        }
        //I
        else if (true_num == button) {
            // <= player attack action
            animator.SetTrigger("swordAttack");
        }

        //Highlight true answer
        switch (true_num) {
            case 1:
                Button_A.GetComponent<Image>().color = Color.green;
                break;
            case 2:
                Button_B.GetComponent<Image>().color = Color.green;
                break;
            case 3:
                Button_C.GetComponent<Image>().color = Color.green;
                break;
            case 4:
                Button_D.GetComponent<Image>().color = Color.green;
                break;
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

    //Button manager
    public void Button_manager() {
        Button_A.interactable = false;
        Button_B.interactable = false;
        Button_C.interactable = false;
        Button_D.interactable = false;
        this.Wait(delay_time,()=>{
            Button_A.interactable = true;
            Button_B.interactable = true;
            Button_C.interactable = true;
            Button_D.interactable = true;
            New_Question();
            refresh_color();
        });
    }

    //Start function
    void Start() {
        //Update variable
        TotalQuestion = Data.Count;
        Index = 0;

        animator = GetComponent<Animator>();

        New_Question();
    }

    //Button controller
    public void ButtonA() {
        Checkiftrue(1);
    }
    public void ButtonB() {
        Checkiftrue(2);
    }
    public void ButtonC() {
        Checkiftrue(3);
    }
    public void ButtonD() {
        Checkiftrue(4);
    }
}