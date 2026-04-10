using System.Collections;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
        private void Awake()
        {
            StartCoroutine(dialogueSequence());
        }

        private IEnumerator dialogueSequence()
        {
            for(int i=0; i<transform.childCount; i++)
            {
                Desactivate();
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
            }
            gameObject.SetActive(false);
            
            // Le comunicamos al GameManager que se encargue del salto a la escena
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null)
            {
                gm.LoadGameScene();
            }
            else
            {
                Debug.LogWarning("¡Falta un GameObject con el script GameManager en esta escena!");
            }
        }

        private void Desactivate()
        {
            for(int i=0; i<transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            
        }

        
    }
}
