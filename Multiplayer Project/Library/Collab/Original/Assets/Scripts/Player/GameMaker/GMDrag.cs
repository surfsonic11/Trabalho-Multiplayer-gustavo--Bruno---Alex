using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMDrag : MonoBehaviour
{
    public float gridSize;
    public bool snapToGrid;
    public bool smartDrag = true;
    public bool isDragged = false;
    public bool dragdropGrabbed;
    public Vector2 initialMousePosition;
    public bool clickAgain;
    public Vector2 initialObjectPosition;
    public SpriteRenderer sFlip;
    [SerializeField]
    GameObject currentObject;

    Ray ray;
    RaycastHit2D hit;

    public LayerMask layerMask;


    private void Start()
    {
        layerMask = LayerMask.GetMask("Draggable");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(isDragged)
            {
                isDragged = false;
                sFlip = null;
                currentObject = null;
            }
            else
            {
                PerformRaycast();
            }
        }

        //ObjectClick();
    }

    void PerformRaycast()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        hit = Physics2D.Raycast(ray.origin, ray.direction, 3000, layerMask);

        if(hit.collider != null)
        {
            Debug.Log("tocou em " + hit.collider.gameObject.name);

            if(currentObject == null)
            {
                currentObject = hit.collider.gameObject;

                isDragged = true;

                DragObject();
            }
        }
    }
        
    void ObjectClick()
    {
        //if(Physics2D.Raycast(Camera.main.transform.position, Input.mousePosition))
            

        /*
            * Debug.Log(Input.mousePosition);

        Debug.Log("Origin: " + ray.origin + " Direction: " + ray.direction);
            */

            
        if (hit.collider != null)
        {
            currentObject = hit.transform.gameObject;

            DragDrop objectDrag = currentObject.GetComponent<DragDrop>();

            if (objectDrag != null)
            {
                SmartDrag();
                ClickAgain();
                IsDraggin();
                //if(objectDrag.isMoving == true)
                //{
                //    MovePlat();
                //}
                    
            }               
        }            
    }

    //void OnMouseUp()
    //{
    //    isDragged = false;

    //}

    //private void OnMouseDown()
    //{
    //    if (hit.collider.gameObject && Input.GetMouseButtonDown(0))
    //    {
    //        if (smartDrag)
    //        {
    //            initialMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //            initialObjectPosition = transform.position;
    //        }
    //        isDragged = true;
    //    }
    //}
    //void MovePlat()
    //{
            
    //   MovingPlatform movingPlatform = currentObject.GetComponent<MovingPlatform>();
    //    movingPlatform.nextPos = movingPlatform.startPos.position;
    //}

    void ClickAgain()
    {
        if (isDragged && Input.GetMouseButtonUp(0))
        {
            clickAgain = true;
        }
        if (clickAgain && Input.GetMouseButtonDown(0))
        {
            isDragged = false;
            clickAgain = false;
        }
    }


    void SmartDrag()
    {
        if (hit.collider.gameObject && Input.GetMouseButtonDown(0))
        {
            if (smartDrag)
            {
                initialMousePosition = Input.mousePosition;
                initialMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                initialObjectPosition = hit.transform.position;
            }
            isDragged = true;
                
        }
    }

    void IsDraggin()
    {
        if (isDragged == true)
        {

            
            if (!smartDrag)
            {
                hit.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else
            {
                hit.transform.position = initialObjectPosition + (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - initialMousePosition;
            }
            if (snapToGrid)
            {
                hit.transform.position = new Vector2(Mathf.RoundToInt(transform.position.x / gridSize) * gridSize, Mathf.RoundToInt(transform.position.y / gridSize) * gridSize);
            }

        }
    }

    private void DragObject()
    {
        StartCoroutine("DragCoroutine");
    }

    private IEnumerator DragCoroutine()
    {
        while(isDragged)
        {
            hit.transform.position = initialObjectPosition + (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - initialMousePosition;
            if(hit.collider.gameObject.name == "springside(Clone)" && Input.GetMouseButtonDown(1))
            {

                sFlip = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                if(sFlip.flipX == true)
                {
                    Debug.Log("oi");

                    hit.collider.gameObject.GetComponent<Spring>().FlipX(false);
                }
                if(sFlip.flipX == false)
                {
                    Debug.Log("merda");
                    hit.collider.gameObject.GetComponent<Spring>().FlipX(true);
                }
            }
            
            yield return null;
        }

        Debug.Log("Soltou o objeto");
    }


}
