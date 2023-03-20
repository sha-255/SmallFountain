using UnityEngine;

public class MouseRectParallax : MonoBehaviour
{
    [SerializeField] float strench;

    private void LateUpdate()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) * strench;
    }
}