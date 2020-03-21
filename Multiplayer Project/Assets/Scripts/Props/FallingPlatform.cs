using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public BoxCollider2D bCol;

    public bool fall;

    public Animator animplat;

    private void Start()
    {
        animplat = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            StartCoroutine(FallPlat());
        }            
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject)
        {
            StopCoroutine(FallPlat());
            StartCoroutine(FallPlatOff());
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag == "Player")
    //    {
    //        fall = true;
    //    }

    //}
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (fall)
    //    {
    //        //animplat.SetBool("isFalling", true);
    //        //animplat.SetFloat("BlockSpeed", 1);
    //        StartCoroutine(FallPlat());
    //    }
    //    else
    //    {
    //        animplat.SetBool("isFalling", false);
    //        animplat.SetFloat("BlockSpeed", -2);
    //        bCol.enabled = true;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if(collision.tag == "Player")
    //    {
    //        fall = false;
    //        //enableCol();
    //    }

    //}

    //void disableCol()
    //{
    //    bCol.enabled = false;
    //}

    //void enableCol()
    //{
    //    bCol.enabled = true;
    //}
    public IEnumerator FallPlat()
    {
        Debug.Log("SIM");
        animplat.SetBool("isFalling", true);
        animplat.SetFloat("BlockSpeed", 2.5f);
        yield return new WaitForSeconds(0.75f);
        bCol.enabled = false;
    }

    public IEnumerator FallPlatOff()
    {
        yield return new WaitForSeconds(0.5f);
        animplat.SetBool("isFalling", false);
        animplat.SetFloat("BlockSpeed", -2.5f);
        yield return new WaitForSeconds(0.75f);
        bCol.enabled = true;
        StopCoroutine(FallPlatOff());
    }
}
