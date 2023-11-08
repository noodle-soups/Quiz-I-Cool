using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
   
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    
    int answerIndexCorrect;
    [SerializeField] Sprite answerSpriteDefault;
    [SerializeField] Sprite answerSpriteCorrect;

    void Start()
    {
       GetNextQuestion();
       //DisplayQuestion();
    }

    public void OnAnswerSelect(int index)
    {
        Image buttonImage;

        if(index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = answerSpriteCorrect;
        }
        else
        {
            answerIndexCorrect = question.GetCorrectAnswerIndex();
            string answerCorrect = question.GetAnswer(answerIndexCorrect);
            questionText.text = "Wrong, the correct answer was:\n" + answerCorrect;
            buttonImage = answerButtons[answerIndexCorrect].GetComponent<Image>();
            buttonImage.sprite = answerSpriteCorrect;
        }

        SetButtonState(false);
    }

    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprite();
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    void SetButtonState(bool state)
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprite()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = answerSpriteDefault;
        }
    }

}
