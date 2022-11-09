using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizHandle_Remaster : MonoBehaviour {

    // GameObject Variables
    public GameObject[] Gameobject_Character;
    public GameObject[] Gameobject_Button;
    public GameObject[] Question_Text;
    public GameObject[] NextArrow_Image;

    public GameObject Button_Next;
    public GameObject Score_Text;
    public GameObject Number_Text;

    // Questions Variables
    [System.Serializable]
    public class Questions {
        public string Question;
        public string TrueAnswer;
        public string FalseAnswer1;
        public string FalseAnswer2;
        public string FalseAnswer3;
    }
    public List<Questions> Question_Data;

    // Array Variables
    int[] ID_array = new int [4];

    // Common Variables
    int ID, TotalQuestion, True_Answer, Score = 0, Index = 0;

    bool Enemy_Respawn = false;

    ///////////////////////////////////////////////////////////////////////////////

    // <= Player attack Enemy
    void AttackA_B() {
        Enemy_Respawn = true;
        // Animations
        Gameobject_Character[0].GetComponent<Animator>().SetTrigger("Attack");
        Gameobject_Character[1].GetComponent<Animator>().SetTrigger("Defeated");
        Button_Next.GetComponent<Animator>().SetTrigger("NextArrow");
        Button_Next.GetComponent<Image>().sprite = NextArrow_Image[0].GetComponent<Image>().sprite;
        // Score +10
        ScoreUpdate(+10);
    }

    // <= Enemy attack Player
    void AttackB_A() {
        // Animations
        Gameobject_Character[0].GetComponent<Animator>().SetTrigger("hurt");
        Gameobject_Character[1].GetComponent<Animator>().SetTrigger("attackSlime");
        Button_Next.GetComponent<Animator>().SetTrigger("ReturnArrow");
        Button_Next.GetComponent<Image>().sprite = NextArrow_Image[1].GetComponent<Image>().sprite;
        // Score -10
        ScoreUpdate(-10);
    }

    // <= Quit() // Ran out questions
    void Quit() {
        print("QUIT");
    }

    ///////////////////////////////////////////////////////////////////////////////

    // <= RenewArray()
    void RenewArray() {
        ID_array[0] = 1;
        ID_array[1] = 2;
        ID_array[2] = 3;
        ID_array[3] = 4;
    }

    // <= NextID()
    int NextID() {
        for (int i=0;i<=3;i++) {
            if (ID_array[i]==0) continue;
            if (ID_array[i]==True_Answer) continue;
            
            ID = ID_array[i];
            ID_array[i] = 0;
            break;
        }
        return ID;
    }

    // <= Enemy_Update() 
    void Enemy_Update() {
        if (Enemy_Respawn==true) {
            Gameobject_Character[1].GetComponent<Animator>().SetTrigger("Respawn");
            Enemy_Respawn = false;
        }
    }
    
    // <= ScoreUpdate()
    void ScoreUpdate(int num) {
        Score += num;
        Score_Text.GetComponent<TMP_Text>().text = "Score: " + (Score);
    }

    // <= NewQuestion()
    void NextQuestion() {
        // IF next Question is available
        if (Index<TotalQuestion) {
            RenewArray();
            Buttons_Enable(true);
            True_Answer = Random.Range(1,Gameobject_Button.Length+1);

            //Change text info
            Question_Text[0].GetComponent<TMP_Text>().text = Question_Data[Index].Question;
            Question_Text[True_Answer].GetComponent<TMP_Text>().text = Question_Data[Index].TrueAnswer;
            Question_Text[NextID()].GetComponent<TMP_Text>().text = Question_Data[Index].FalseAnswer1;
            Question_Text[NextID()].GetComponent<TMP_Text>().text = Question_Data[Index].FalseAnswer2;
            Question_Text[NextID()].GetComponent<TMP_Text>().text = Question_Data[Index].FalseAnswer3;
        }
        // Else run out Question
        else {Quit();}
    }

    // <= HighlightAnswers()
    void HighlightAnswers(int buttonpress) {
        // Hightlight wrong answer -- IF HAVE
        if (True_Answer != buttonpress) {
            AttackB_A();
            Gameobject_Button[buttonpress-1].GetComponent<Image>().color = Color.red;
        }
        else AttackA_B();
        // Hightlight right answer
        Gameobject_Button[True_Answer-1].GetComponent<Image>().color = Color.green;
    }

    // <= RemoveHighlight()
    void RemoveHighlight() {
        for (int i=0;i<=Gameobject_Button.Length-1;i++) {
            Gameobject_Button[i].GetComponent<Image>().color = Color.white;
        }
    }

    // <= Buttons_Enable()
    void Buttons_Enable(bool value) {
        for (int i=0;i<=Gameobject_Button.Length-1;i++) {
            Gameobject_Button[i].GetComponent<Button>().interactable = value;
        }
    }

    // <= NEXTButton_Enable()
    void NEXTButton_Enable(bool value) {
        Button_Next.GetComponent<Button>().interactable = value;
    }

    // <= ButtonPressed()
    void ButtonPressed(int buttonpress) {
        NEXTButton_Enable(true);
        Buttons_Enable(false);
        HighlightAnswers(buttonpress);
    }

    ///////////////////////////////////////////////////////////////////////////////

    // <= Start()
    void Start() {
        //Set value
        TotalQuestion = Question_Data.Count;

        // <= Start game
        NextQuestion();
    }

    ///////////////////////////////////////////////////////////////////////////////

    // <<<< Button function_event
    public void ButtonA() {
        ButtonPressed(1);
    }
    public void ButtonB() {
        ButtonPressed(2);
    }
    public void ButtonC() {
        ButtonPressed(3);
    }
    public void ButtonD() {
        ButtonPressed(4);
    }

    // <<<< Button_Next Pressed
    public void NEXTButton_Press() {
        Button_Next.GetComponent<Animator>().SetTrigger("HideArrow");
        NEXTButton_Enable(false);

        Index += 1;
        RemoveHighlight();
        NextQuestion();
        Enemy_Update();
    }

    // <<<< Wheel_SuperSpin()
    public void Wheel_SuperSpin() {
        Number_Text.GetComponent<TMP_Text>().text = "" + Random.Range(1,36);
    }
}