using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DebugINput : MonoBehaviour
{
    [SerializeField] private GameObject _debugObject;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Quest _Quest;
    [SerializeField] private UnityEvent _F2KeyDown;

    private void Awake()
    {
        _inputField.onEndEdit.AddListener((s) => 
        {
            if (s != null && s != "")
                if (s[0] == '/')
                    _Quest.OpenQuest(int.Parse(s.Substring(1)));
        });
        _F2KeyDown.AddListener(() => _debugObject.SetActive(!_debugObject.activeInHierarchy));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
            _F2KeyDown?.Invoke();
    }
}