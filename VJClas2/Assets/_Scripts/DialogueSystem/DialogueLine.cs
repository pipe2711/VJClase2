using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace DialogueSystem
{
    public class DialogueLine : DialogueBase
    {
        private TMP_Text textHolder;
        [SerializeField] private string input;

        [Header("Time Delay")]
        [SerializeField] private float delay;
        [SerializeField] private float delayBetweenLines;

        [Header("Sound")]
        [SerializeField] private AudioClip sound;  

        [Header("Character Image")]
        [SerializeField] private Sprite characterSprite;
        [SerializeField] private Image imageHolder;
        
        
        private void Awake()
        {
            textHolder = GetComponent<TMP_Text>();
            textHolder.text = "";

            imageHolder.sprite = characterSprite;
            imageHolder.preserveAspect = true;
        }

        private void Start()
        {
            StartCoroutine(WriteText(input, textHolder, delay, sound, delayBetweenLines));
        }

    }
}