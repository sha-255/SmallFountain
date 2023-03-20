using TMPro;
using UnityEngine;

public class FortuneWhellArrow : MonoBehaviour
{
    [SerializeField] private FortuneWhell FortuneWhell;
    [SerializeField] private float minVelosity;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (FortuneWhell.SpinVelocity < minVelosity)
        {
            FortuneWhell.SpinVelocity = 0;
            var text = collision.gameObject?.GetComponent<TMP_Text>();
            print(text?.text);
        }
    }
}