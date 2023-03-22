using UnityEngine;

public class FortuneWhell : MonoBehaviour
{
    [SerializeField] private float _minSpin = 500;
    [SerializeField] private float _maxSpin = 1000;
    [SerializeField] private Quest _quest;
    [SerializeField] private Cell _cellPrefab;
    private new Rigidbody2D rigidbody2D;

    public float SpinVelocity
    { 
        get => Mathf.Abs(rigidbody2D.angularVelocity);
        set => rigidbody2D.angularVelocity = value * -1;
    }

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        for (var i = 0; i < _quest.Questions.Length; i++)
        {
            var cell = Instantiate(_cellPrefab);
            cell.Id = i;
            cell.transform.SetParent(transform);
            cell.transform.localScale = Vector3.one;
            cell.transform.Rotate(new Vector3(0,0,360/_quest.Questions.Length*i));
        }
    }

    public void Spin()
    {
        SpinVelocity = Random.Range(_minSpin, _maxSpin);
    }
}