using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIController : MonoBehaviour
{
    private const float speed = 40f;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer slime;

    private int currentPathIndex;
    private List<Vector3> pathVectorList;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();      
    }

    public void DestroyAI()
    {
        Destroy(gameObject);
    }

    private void HandleMovement()
    {
        if(pathVectorList != null)
        {
            Vector3 targetPosition = pathVectorList[currentPathIndex];
            if(Vector3.Distance(transform.position, targetPosition) > 1f)
            {
                Vector3 moveDir = (targetPosition - transform.position).normalized;

                float distanceBefore = Vector3.Distance(transform.position, targetPosition);
                transform.position = transform.position + moveDir * speed * Time.deltaTime;
            } else
            {
                currentPathIndex++;
                if(currentPathIndex >= pathVectorList.Count)
                {
                    StopMoving();
                    //gameObject.SetMoveVector(Vector3.zero);
                }
            }
        /*} else
        {
            // Animation : ignore
            //this.SetMoveVector(Vector3.zero);
            //animatedWalker.SetMoveVector(Vector3.zero);*/
        }
    }

    // Only for animation
    public void SetMoveVector(Vector3 moveVector)
       {
        if (moveVector == Vector3.zero)
        {
            // Idle
            //gameobject.Animation.Play("SlimeIdle");
        }
        else
        {
            // Moving
            //lastMoveVector = moveVector;
            //unitAnimation.PlayAnim(walkAnimType, lastMoveVector, walkFrameRate, null, null, null);
        }
    }
    private void StopMoving()
    {
        pathVectorList = null;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        currentPathIndex = 0;
        pathVectorList = AIPathfinding.Instance.FindPath(GetPosition(), targetPosition);

        if (pathVectorList != null && pathVectorList.Count > 1)
        {
            pathVectorList.RemoveAt(0);
        }
    }
}
