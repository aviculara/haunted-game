using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviour : MonoBehaviour
{
    public int difficultyLevel = 1;
    public int currentDir = 0;
    public GameObject playerObject;

    public int counterTarget = 10;

    private Move moveScript;
    private int nextDir = 0;
    private Rigidbody2D playerRB;
    private Vector2 prevDist;
    private Vector2 currentDist;
    private int counter;

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
        counter = 0;
    }

    void FixedUpdate()
    {
        switch (difficultyLevel)
        {
            case 1:
                //difficulty level 1
                //if distance increased
                currentDist = findDistance(playerRB);
                counter = counter + 1;
                if(currentDist.magnitude > prevDist.magnitude && counter > counterTarget)
                {
                    //change direction
                    nextDir = moveScript.RandomNearbyDirection(currentDir);
                    moveScript.ChangeDirTo(nextDir);
                    currentDir = nextDir;
                    counter = 0;
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
