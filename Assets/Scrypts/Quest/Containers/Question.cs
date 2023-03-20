using System;
using UnityEngine;

[Serializable]
public class Question
{
    [SerializeField] private string _questionText;
    public string QuestionText
    {
        get => _questionText;
        set => _questionText = value;
    }

    [SerializeField] private AudioClip _voiceover;
    public AudioClip Voiceover
    {
        get => _voiceover;
        set => _voiceover = value;
    }

    [SerializeField] private Answer[] _answers;
    public Answer[] Answers
    {
        get => _answers;
        set => _answers = value;
    }

    public Question() { }

    public Question(string questionText, params Answer[] answers)
        => (QuestionText, Answers) = (questionText, answers);
}