using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GMDrag : NetworkBehaviour
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
    private Gameplay gp;

    GameObject t;

    Ray ray;
    RaycastHit2D hit;

    public LayerMask layerMask;

    private void OnEnable()
    {
        CmdItenSpawn();
    }

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

    [Command]
    public void CmdItenSpawn()
    {
        for (int i = 0; i < GameManager.instance.Itens.Length; i++)
        {
            if (GameManager.instance.Item1 == i)
            {
               t = Instantiate(GameManager.instance.Itens[i], GameManager.instance.ItensSpawn[0].transform.position, transform.rotation);
                NetworkServer.Spawn(t);
            }
            else if (GameManager.instance.Item2 == i)
            {
               t = Instantiate(GameManager.instance.Itens[i], GameManager.instance.ItensSpawn[1].transform.position, transform.rotation);
                NetworkServer.Spawn(t);
            }
            else if (GameManager.instance.Item3 == i)
            {
               t =  Instantiate(GameManager.instance.Itens[i], GameManager.instance.ItensSpawn[2].transform.position, transform.rotation);
                NetworkServer.Spawn(t);
            }
        }
    }

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
        if (isLocalPlayer)
        {
            while (isDragged)
            {
                hit.transform.position = initialObjectPosition + (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - initialMousePosition;
                if (hit.collider.gameObject.name == "springside(Clone)" && Input.GetMouseButtonDown(1))
                {

                    //sFlip = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                    //if(sFlip.flipX == true)
                    //{
                    //    Debug.Log("oi");

                    //    hit.collider.gameObject.GetComponent<Spring>().FlipX(false);
                    //}
                    //if(sFlip.flipX == false)
                    //{
                    //    Debug.Log("merda");
                    //    hit.collider.gameObject.GetComponent<Spring>().FlipX(true);
                    //}
                }

                yield return null;
            }

            Debug.Log("Soltou o objeto");
        }
    }
       


}
