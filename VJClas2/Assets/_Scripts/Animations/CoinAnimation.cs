using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
       CoinAnim(); 
    }

    public void CoinAnim()
    {
        if(Input.GetKeyDown(KeyCode.R))
            anim.SetTrigger("Anim");
    }
}
