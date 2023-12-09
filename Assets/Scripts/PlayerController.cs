using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Move moveScript;
    private Animator animator;
    public GameObject playerObject;
    public bool buttonsEnabled = true ;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<Move>();
        if (moveScript == null)
        {
            Debug.Log("null");
        }
        animator = playerObject.GetComponent<Animator>();
    }

    
    public void Fall()
    {
        StartCoroutine(FallCoroutine());

    }

    private IEnumerator FallCoroutine()
    {
        buttonsEnabled = false;
        moveScript.speed = 0;
        animator.SetBool("Fall", true);

        yield return new WaitForSeconds(1.0f);
        animator.SetBool("Fall", false);
        moveScript.ChangeOppositeDir();
        moveScript.speed = 1;
        buttonsEnabled = true;
    }

    public void ButtonUp()
    {
        if (buttonsEnabled) moveScript.ChangeDirUp(); 
    }

    public void ButtonDown()
    {
        if (buttonsEnabled) moveScript.ChangeDirDown();
    }

    public void ButtonRight()
    {
        if (buttonsEnabled) moveScript.ChangeDirRight();
    }

    public void ButtonLeft()
    {
        if (buttonsEnabled) moveScript.ChangeDirLeft();
    }
}
