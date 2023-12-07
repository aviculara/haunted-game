using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviour : MonoBehaviour
{
    public int difficultyLevel = 1;
    public int currentDir = 0;
    public GameObject playerObject;

    private Move moveScript;
    private int nextDir = 0;
    private Rigidbody2D playerRB;
    private Vector2 prevDist;
    private Vector2 currentDist;

    // Start is called before the first frame update
    void Start()
    {
        
        moveScript = GetComponent<Move>();
        if(moveScript == null)
        {
            Debug.Log("null");
        }

        playerRB = playerObject.GetComponent<Rigidbody2D>();
        prevDist = findDistance(playerRB);
    }

    void FixedUpdate()
    {
        switch (difficultyLevel)
        {
            case 1:
                //difficulty level 1
                //if distance increased
                currentDist = findDistance(playerRB);
                if(currentDist.magnitude > prevDist.magnitude)
                {
                    //change direction
                    nextDir = moveScript.RandomNearbyDirection(currentDir);
                    moveScript.ChangeDirTo(nextDir);
                    currentDir = nextDir;
                }
                prevDist = currentDist;
                break;
            default:
                //idk yet
                break;
        }
    }

    private Vector2 findDistance(Rigidbody2D targetRB)
    {
        Vector2 distance;
        Vector2 targetPos = targetRB.transform.position;
        Vector2 selfPos = moveScript.objectToMove.transform.position;
        distance = targetPos - selfPos;
        return distance;
    }

}
