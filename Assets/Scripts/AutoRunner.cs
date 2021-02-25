using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRunner : MonoBehaviour
{
    public bool isRunning = false;
    private Animator animatorController;
    // Start is called before the first frame update
    void Start()
    {
        animatorController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            transform.Translate(0, 0, -5f* Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            isRunning = true;
            animatorController.SetTrigger("isRunning");
        }
        else
        {
            isRunning = false;
        }
    }
}
