using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviour : MonoBehaviour
{
    public int difficultyLevel = 1;
    public int currentDir = 0;
    private Move moveScript;
    private int nextDir = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Enemy script start");
        moveScript = GetComponent<Move>();
        if(moveScript == null)
        {
            Debug.Log("null");
        }

    }

    void FixedUpdate()
    {
        switch (difficultyLevel)
        {
            case 1:
                //difficulty level 1
                nextDir = moveScript.RandomNearbyDirection(currentDir);
                moveScript.ChangeDirTo(nextDir);
                currentDir = nextDir;
                break;
            default:
                //idk yet
                break;
        }
    }
}
