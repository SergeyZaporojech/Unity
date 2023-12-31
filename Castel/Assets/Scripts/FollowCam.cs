using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;

    [Header("Set Inspection")]
    public float easing = 0.5f;
    public Vector2 minXY=Vector2.zero;

    [Header("Set Dynamicaly")]
    public float camZ;

    // Start is called before the first frame update
    void Awake()
    {
        camZ=this.transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (POI==null) { return; }
        Vector3 destination = POI.transform.position;
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);

        destination= Vector3.Lerp(transform.position, destination, easing);
        destination.z = camZ;
        transform.position = destination;
        Camera.main.orthographicSize = destination.y + 10;
    }
}
