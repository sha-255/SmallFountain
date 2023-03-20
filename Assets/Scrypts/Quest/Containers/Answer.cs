using Assets.Scrypts.Enums;
using System;
using UnityEngine;

[Serializable]
public class Answer
{
    [SerializeField] private AnswerType _answerType;
    public AnswerType Type
    {
        get => _answerType;
        set => _answerType = value;
    }

    [SerializeField] private string _answerText = string.Empty;
    public string Text
    {
        get => _answerText;
        set => _answerText = value;
    }

    [SerializeField] private AudioClip voiceover;
    public AudioClip Voiceover
    {
        get => voiceover;
        set => voiceover = value;
    }

    public Answer() { }
    public Answer(AnswerType answerType, string answerText)
        => (Type, Text) = (answerType, answerText);
}