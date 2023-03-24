using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Drops : MonoBehaviour
{
    [SerializeField] private TMP_Text _dropsText;
    [SerializeField] private Image _logo;
    [SerializeField] private Color _color;
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private GameObject _childrenCommandPanel;
    [SerializeField] private GameObject _parentCommandPanel;
    [SerializeField] private UnityEvent<int> _finish;
    private int _count;
    public int CurrentCount
    {
        get => _count;
        set
        {
            _count = value;
            _dropsText.text = _count.ToString();
            StartCoroutine(RecolorizeLogo());
            if (value == _max)
                _finish?.Invoke(_count);
            //print($"{value}|{MaxCount}");
        }
    }

    private IEnumerator RecolorizeLogo()
    {
        var color = _logo.color;
        _logo.color = _color;
        yield return new WaitForSeconds(.3f);
        _logo.color = color;
    }

    private int _max;
    public int MaxCount
    {
        get => _max;
        set => _max = value;
    }

    private void Awake()
    {
        _finish.AddListener((i) =>
        { 
            _mainPanel.SetActive(false);
            _finishPanel.SetActive(true);
            if (CurrentCount > 0)
            {
                _parentCommandPanel.SetActive(false);
                _childrenCommandPanel.SetActive(true);
            }
            else
            {
                _parentCommandPanel.SetActive(true);
                _childrenCommandPanel.SetActive(false);
            }
        });
    }
}