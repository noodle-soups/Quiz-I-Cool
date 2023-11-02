using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Quiz Question", order = 0)]
public class QuestionSO : ScriptableObject 
{
    [TextArea(2, 6)]
    [SerializeField] string question = "Enter new question here";

    public string GetQuestion()
    {
        return question;
    }

}
