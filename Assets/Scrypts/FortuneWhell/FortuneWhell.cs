using TMPro;
using UnityEngine;

public class FortuneWhell : MonoBehaviour
{
    [SerializeField] private float minSpin;
    [SerializeField] private float maxSpin;
    private new Rigidbody2D rigidbody2D;
    public float SpinVelocity 
    { 
        get => rigidbody2D.angularVelocity;
        set => rigidbody2D.angularVelocity = value;
    }

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Spin()
    {
        rigidbody2D.angularVelocity = Random.Range(minSpin, maxSpin);
    }
}