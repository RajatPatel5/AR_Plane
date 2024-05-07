using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovment : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    public float moveSpeed = 1f;

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(Input.GetMouseButton(0))
        {
            prefab.transform.Translate(Input.mousePosition);    
        }
    }
}
