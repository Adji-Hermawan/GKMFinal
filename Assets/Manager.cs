using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    public GameObject buttonAnimation, popUp;
    private Animator animator1, animator2;

    void Start()
    {
        animator1 = popUp.GetComponent<Animator>();
        animator2 = buttonAnimation.GetComponent<Animator>();
    }

    public void PopUpSystemOpen() => StartCoroutine(ShowPopUpCoroutine());

    public void PopUpSystemClose() => StartCoroutine(HidePopUpCoroutine());

    private IEnumerator ShowPopUpCoroutine()
    {
        animator2.Play("Hide");
        yield return new WaitForSeconds(0.1f);
        animator1.Play("play");
    }

    private IEnumerator HidePopUpCoroutine()
    {
        animator1.Play("Close");
        yield return new WaitForSeconds(0.3f);
        animator2.Play("Show");
    }

}