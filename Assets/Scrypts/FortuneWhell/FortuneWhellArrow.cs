using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FortuneWhellArrow : MonoBehaviour
{
    [SerializeField] private FortuneWhell _fortuneWhell;
    [SerializeField] private float _minVelosity = 80;
    [SerializeField] private float _twistStrength = 20;
    [SerializeField] private UnityEvent<int> _cellSelected;
    private List<int> _cellsId = new List<int>();
    private bool a = true;

    private void Awake()
    {
        _fortuneWhell.StartSpin.AddListener(()=> 
        {
            a = true;
        });
    }

    private void FixedUpdate()
    {
        if (_fortuneWhell.SpinVelocity < _minVelosity && _fortuneWhell.IsSpin && a)
        {
            _fortuneWhell.SpinVelocity = _twistStrength;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_fortuneWhell.SpinVelocity < _minVelosity)
            CellCheck(collision);
    }

    private void CellCheck(Collider2D collision)
    {
        var cell = collision.gameObject.GetComponentInParent<Cell>();
        if (!_cellsId.Contains(cell.Id))
        {
            _fortuneWhell.SpinVelocity = 0;
            cell.Interactable = false;
            a = false;
            _cellsId.Add(cell.Id);
            _cellSelected?.Invoke(cell.Id);
        }
    }
}