using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    public Text labelText;

    public void Spawn(int index)
    {
        Instantiate(prefabs[index], transform.position, transform.rotation);
    }

    public void SetGestureLabel(string label)
    {
        labelText.text = label;
    }

}
