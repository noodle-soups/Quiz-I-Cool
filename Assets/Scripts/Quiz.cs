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
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }

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
    }

}
