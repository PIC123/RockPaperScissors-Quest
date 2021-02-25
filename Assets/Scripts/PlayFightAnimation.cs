using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFightAnimation : MonoBehaviour
{
    private Animator animatorController;
    private AutoRunner runner;

    private void Start()
    {
        runner = GetComponent<AutoRunner>();
        animatorController = GetComponent<Animator>();
    }

    private void Update()
    {
        animatorController.SetFloat("vertical", Input.GetAxis("Vertical"));
        animatorController.SetFloat("horizontal", Input.GetAxis("Horizontal"));
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("touch start");
        if (other.CompareTag("Target"))
        {
            if (other.gameObject.tag == "Winner")
            {
                Debug.Log("fight");
                animatorController.SetTrigger("isNearTarget");
                runner.isRunning = true;
            }
            else if(other.gameObject.tag == "Loser")
            {
                Debug.Log("die");
                animatorController.SetTrigger("isDying");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("touch end");
        if (other.CompareTag("Target"))
        {
            animatorController.ResetTrigger("isNearTarget");
        }
    }

    public void TeleportAfterAnimation(float dist)
    {
        transform.Translate(0, 0, dist);
    }

    public void StopRunning()
    {
        animatorController.ResetTrigger("isRunning");
        runner.isRunning = false;
    }
}
