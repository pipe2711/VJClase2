using System.Collections;
using UnityEngine;
using TMPro;

namespace DialogueSystem
{
    public class DialogueBase : MonoBehaviour
    {
        public bool finished{ get; private set; }

        protected IEnumerator WriteText(string input, TMP_Text textHolder, float delay, AudioClip sound, float delayBetweenLines)
        {
            for (int i = 0 ; i < input.Length ; i++)
            {
                textHolder.text += input[i];
                
                // Reproducimos el sonido cada 3 letras, evitando que suene
                // en los espacios en blanco
                if (i % 3 == 0 && input[i] != ' ')
                {
                    SoundManager.instance.PlaySound(sound);
                }

                yield return new WaitForSeconds(delay);
            }

            //yield return new WaitForSeconds(delayBetweenLines);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));


            finished = true;
        }
    }
}

