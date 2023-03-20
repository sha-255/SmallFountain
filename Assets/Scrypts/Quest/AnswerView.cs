using Assets.Scrypts.Enums;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerView : MonoBehaviour
{
    public int Id { get; set; }

    [SerializeField] private Toggle _toggle;
    public AnswerType CurrentType
    {
        get => _toggle.isOn ? AnswerType.Correct : AnswerType.Uncorrect;
        set => _toggle.isOn = Convert.ToBoolean(value);
    }

    [SerializeField] private TMP_Text _label;
    public string Text 
    {
        get => _label.text;
        set => _label.text = value;
    }

    [SerializeField] private Button _voice;
    public Button VoiceButton
    {
        get => _voice;
        set => _voice = value;
    }
}