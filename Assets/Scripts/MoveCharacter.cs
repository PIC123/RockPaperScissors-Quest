using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = -Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float v = -Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(h,0,v);
    }
}
