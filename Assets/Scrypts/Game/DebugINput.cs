using TMPro;
using UnityEngine;

public class DebugINput : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] Quest Quest;

    private void Awake()
    {
        inputField.onEndEdit.AddListener((s) => Quest.OpenQuest(int.Parse(s)));
    }
}