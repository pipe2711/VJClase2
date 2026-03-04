using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator openDoor;

    // Update is called once per frame
    void Update()
    {
       OpenD(); 
    }

    public void OpenD()
    {
        if(Input.GetKeyDown(KeyCode.P))
            openDoor.SetTrigger("OpenDoor");
    }
}

