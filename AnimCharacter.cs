using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCharacter : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Sleep()
    {
        StartCoroutine(Sleepy());
    }

    private IEnumerator Sleepy()
    {
        animator.SetBool("Sleep",true);
        yield return new WaitForSeconds(10f);
        animator.SetBool("Sleep",false);
    }
}
