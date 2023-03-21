using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FortuneWhellArrow : MonoBehaviour
{
    [SerializeField] private FortuneWhell _fortuneWhell;
    [SerializeField] private float _minVelosity = 80;
    [SerializeField] private UnityEvent<int> _cellSelected;
    private List<int> _cellsId = new List<int>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_fortuneWhell.SpinVelocity < _minVelosity)
        {
            _fortuneWhell.SpinVelocity = 0;
            var cell = collision.gameObject.GetComponentInParent<Cell>();
            if (!_cellsId.Contains(cell.Id))
            {
                cell.Interactable = false;
                _cellsId.Add(cell.Id);
                _cellSelected?.Invoke(cell.Id);
            }
        }
    }
}