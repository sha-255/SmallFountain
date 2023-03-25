using UnityEngine;
using UnityEngine.Events;

public class FortuneWhell : MonoBehaviour
{
    [SerializeField] private float _minSpin = 500;
    [SerializeField] private float _maxSpin = 1000;
    [SerializeField] private Quest _quest;
    [SerializeField] private Cell _cellPrefab;
    private new Rigidbody2D rigidbody2D;
    public bool IsSpin { get; private set; }
    public UnityEvent StartSpin;

    public float SpinVelocity
    { 
        get => Mathf.Abs(rigidbody2D.angularVelocity);
        set => rigidbody2D.angularVelocity = value * -1;
    }

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        InstantiateCells();
    }

    private void InstantiateCells()
    {
        for (var i = 0; i < _quest.Questions.Length; i++)
        {
            var cell = Instantiate(_cellPrefab);
            var currentAngle = -(360 / _quest.Questions.Length * i);
            cell.Id = i;
            cell.transform.SetParent(transform);
            cell.transform.localScale = Vector3.one;
            cell.transform.localPosition = Vector3.zero;
            cell.transform.Rotate(new Vector3(0, 0, currentAngle));
        }
    }

    public void Spin()
    {
        IsSpin = true;
        StartSpin?.Invoke();
        SpinVelocity = Random.Range(_minSpin, _maxSpin);
    }

    private void FixedUpdate()
    {
        if (SpinVelocity == 0)
            IsSpin = false;
    }
}