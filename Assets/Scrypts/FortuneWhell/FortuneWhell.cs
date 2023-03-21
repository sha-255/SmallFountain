using TMPro;
using UnityEngine;

public class FortuneWhell : MonoBehaviour
{
    [SerializeField] private float minSpin;
    [SerializeField] private float maxSpin;
    private new Rigidbody2D rigidbody2D;

    public float SpinVelocity
    { 
        get => Mathf.Abs(rigidbody2D.angularVelocity);
        set => rigidbody2D.angularVelocity = value * -1;
    }

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Spin()
    {
        SpinVelocity = Random.Range(minSpin, maxSpin);
    }
}