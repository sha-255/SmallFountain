using Assets.Scrypts.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Quest : MonoBehaviour
{
    [Header("Quest")]
    [SerializeField] private Question[] _questions;
    [Space]
    [Header("Software")]
    [SerializeField] private QuestionView _questionPrefab;
    [SerializeField] private AnswerView _ansverPrefab;
    [SerializeField] private UnityEvent _succesfull;
    [SerializeField] private UnityEvent _failed;
    private AudioSource audioSource;
    private QuestionView _questionInstance;
    private int _questionIndex;
    private List<AnswerView> _questAnswers = new List<AnswerView>();

    public Question[] Questions
    { 
        get => _questions;
        private set => _questions = value;
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        _succesfull.AddListener(() => StartCoroutine(OnSuccesfull()));
        _failed.AddListener(() => StartCoroutine(OnFailed()));
    }
    //
    private IEnumerator OnSuccesfull()
    {
        yield return null;
    }

    private IEnumerator OnFailed()
    {
        yield return null;
    }

    public void OpenQuest(int id)
    {
        _questionIndex = id;
        InstantiateQuestion();
        InstantiateAnswers();
        _questionInstance.CheckAnswersButton.onClick.AddListener(() => 
        {
            var succesfulItems = 0;
            for (var i = 0; i < Questions[_questionIndex].Answers.Length; i++)
                if (_questAnswers.Find(x => x.Id == i).CurrentType 
                    == Questions[_questionIndex].Answers[i].Type)
                    succesfulItems++;
            if (succesfulItems == Questions[_questionIndex].Answers.Length)
                _succesfull?.Invoke();
            else
                _failed?.Invoke();
        });
    }

    private void InstantiateQuestion()
    {
        _questionInstance = Instantiate(_questionPrefab);
        _questionInstance.transform.SetParent(transform);
        _questionInstance.transform.localScale = Vector3.one;
        _questionInstance.Question = Questions[_questionIndex].QuestionText;
        _questionInstance.VoiceButton.onClick.AddListener(() => 
        {
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(Questions[_questionIndex].Voiceover);
        });
    }

    private void InstantiateAnswers()
    {
        _questAnswers.Clear();
        var index = 0;
        foreach (var answer in Questions[_questionIndex].Answers)
        {
            var a = Instantiate(_ansverPrefab);
            a.Text = answer.Text;
            a.Id = index;
            _questAnswers.Add(a);
            a.VoiceButton.onClick.AddListener(() =>
            {
                if (!audioSource.isPlaying)
                    audioSource.PlayOneShot(Questions[_questionIndex].Answers[a.Id].Voiceover);
            });
            index++;
        }
        _questAnswers = _questAnswers.ToArray().Mix().ToList();
        foreach (var answer in _questAnswers)
        {
            answer.transform.SetParent(_questionInstance.Answers.transform);
            answer.transform.localScale = Vector3.one;
        }
    }
}