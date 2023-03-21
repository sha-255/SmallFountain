using System;
using TMPro;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private bool _interactable = true;
    [SerializeField] private int _id;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Collider2D _trigger;
    private Color _textColor;
    private Action _notInteractable;
    private Action _onInteractable;

    public bool Interactable
    {
        get => _interactable;
        set
        {
            if (value)
                _onInteractable?.Invoke();
            else
                _notInteractable?.Invoke();
            _interactable = value;
        }
    }

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public Collider2D Trigger
    {
        get => _trigger;
        set => _trigger = value;
    }

    private void Awake()
    {
        _text.text = (_id + 1).ToString();
        _textColor = _text.color;
        _notInteractable += () =>
        {
            _text.color = new Color(
            _textColor.r,
            _textColor.g,
            _textColor.b,
            0.5f);
            _trigger.enabled = false;
        };
        _onInteractable += () => 
        { 
            _text.color = _textColor; 
            _trigger.enabled = true;
        };
    }
}