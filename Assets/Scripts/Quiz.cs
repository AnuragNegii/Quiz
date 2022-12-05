using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{   
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSo question;

    [SerializeField] GameObject[] answerButtons;

    int correctAnswerIndex;

    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    Image buttonImage;

    void Start()
    {
        GetNextQuestiom();
        // DisplayQuestion();
    }

    void GetNextQuestiom(){

        SetButtonState(true);
        SetDefaultButtonSprite();
        DisplayQuestion();
    }

    private void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index){
        
        if(index == question.GetCorrectAnswerIndex()){
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else{
            correctAnswerIndex = question.GetCorrectAnswerIndex();
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            questionText.text = "Sorry, the correct answer was:\n" + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        SetButtonState(false);
    }

    void SetButtonState(bool state){
        for(int i = 0; i< answerButtons.Length; i++){
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprite(){
         for(int i = 0; i< answerButtons.Length; i++){
            buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
