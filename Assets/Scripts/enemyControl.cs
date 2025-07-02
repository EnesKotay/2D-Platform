using Unity.Cinemachine;
using UnityEngine;

public class enemyControl : MonoBehaviour
{
    public float speed;
    public Transform pointA;
    public Transform pointB;

    private Vector2 targetPosition;
    private bool movingToB;



    void Start()
    {
        targetPosition = pointB.position;
    }    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (movingToB)
            {
                targetPosition = pointA.position;
                movingToB = false;
            }
            else
            {
                targetPosition = pointB.position;
                movingToB = true;

                Flip();
            }
        }


    }
    private void Flip()
    {
        Vector2 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}

    
      
        