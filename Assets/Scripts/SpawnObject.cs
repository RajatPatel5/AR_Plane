using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]    
public class SpawnObject : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private GameObject spawnObject;

     [SerializeField]
     public GameObject placeablePreFab;
  
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    public void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();  
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0) 
        {
            touchPosition = Input.GetTouch(0).position;
            return true;    
        }
        touchPosition = default;
        return false;
    }
    private void Update()
    {
        if(!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }   
        if(raycastManager.Raycast(touchPosition,s_Hits,TrackableType.PlaneWithinPolygon))
        {
            var hitPos = s_Hits[0].pose;

            if(spawnObject == null)
            {
                spawnObject = Instantiate(placeablePreFab, hitPos.position, hitPos.rotation);
            }
            else
            {
                spawnObject.transform.position = hitPos.position; 
                spawnObject.transform.rotation = hitPos.rotation;   
            }
        }   
    }
}
