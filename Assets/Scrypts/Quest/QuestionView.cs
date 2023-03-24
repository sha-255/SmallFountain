using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionView : MonoBehaviour
{
    [SerializeField] private TMP_Text _header;
    public string Question
    {
        get => _header.text;
        set => _header.text = value;
    }

    [SerializeField] private VerticalLayoutGroup _answers;
    public VerticalLayoutGroup Answers
    {
        get => _answers;
        set => _answers = value;
    }

    [SerializeField] private Button _voice;
    public Button VoiceButton
    {
        get => _voice;
        set => _voice = value;
    }

    [SerializeField] private Button _checkAnswers;
    public Button CheckAnswersButton
    {
        get => _checkAnswers;
        set => _checkAnswers = value;
    }

    [SerializeField] private Image bacGround;
    public Image BacGround
    {
        get => bacGround;
        set => bacGround = value;
    }

    public void Destroy() => Destroy(gameObject);
}