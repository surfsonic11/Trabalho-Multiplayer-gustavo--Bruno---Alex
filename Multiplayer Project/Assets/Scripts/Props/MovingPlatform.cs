using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pos1, pos2;

    public float speed;

    public Transform startPos;

    public Vector3 nextPos;

    public GMDrag gmDrag;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.localPosition;
        gmDrag = GameObject.FindGameObjectWithTag("GameMaker").GetComponent<GMDrag>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gmDrag.isDragged == false)
        {
            if (transform.localPosition == pos1.localPosition)
            {
                nextPos = pos2.localPosition;

                Debug.Log("Posição 1");
            }
            if (transform.localPosition == pos2.localPosition)
            {
                nextPos = pos1.localPosition;

                Debug.Log("Posição 2");
            }

            transform.localPosition = Vector3.MoveTowards(transform.localPosition, nextPos, speed * Time.deltaTime);
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
