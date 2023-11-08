using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
   
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    
    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int answerIndexCorrect;
    bool hasAnsweredEarly;

    [Header("Button Colors")]
    [SerializeField] Sprite answerSpriteDefault;
    [SerializeField] Sprite answerSpriteCorrect;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;


    void Start()
    {
       timer = FindObjectOfType<Timer>();
       GetNextQuestion();
       //DisplayQuestion();
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;

        if(timer.loadNextQuestion)
        {
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if(!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void OnAnswerSelect(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
    }

    void DisplayAnswer(int index)
    {
        Image buttonImage;

        if (index == question.GetCorrectAnswerIndex())
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
