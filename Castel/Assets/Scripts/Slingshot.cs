using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{

    [Header("Set in Inspector")]
    public GameObject prefabProgectile;
    public float velocityMult = 8f;

    [Header("Set in Dynamicaly")]
    public GameObject lanchPoint;
    public Vector3 launchPos;
    public GameObject projecline;
    public bool aimingMode;
    public Rigidbody projectileRegibody;



    public GameObject launchPoint;
    private void Awake()
    {
        Transform launchPointTrans= transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }

    private void OnMouseEnter()
    {
        //print("OnMouseEnter");
        launchPoint.SetActive(true);

    }

    private void OnMouseExit() {
        //print("OnMouseExit");
        launchPoint.SetActive(false);
    }

    private void OnMouseDown()
    {
        aimingMode = true;
        projecline = Instantiate(prefabProgectile);
        projecline.transform.position = launchPos;
        projectileRegibody= projecline.GetComponent<Rigidbody>();
        projectileRegibody.isKinematic = true; 
    }

    private void Update() {
    Vector3 mousPos2D= Input.mousePosition;
        mousPos2D.z= - Camera.main.transform.position.z;
        Vector3 mousePos3D= Camera.main.ScreenToWorldPoint(mousPos2D);

        Vector3 mouseDelta = mousePos3D - launchPos;
        float maxMagmitude =  this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude>maxMagmitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagmitude;
        }

        Vector3 projPos = launchPos + mouseDelta;
        projecline.transform.position = projPos;
        if (Input.GetMouseButtonUp(0))
        {
            aimingMode = false;
            projectileRegibody.isKinematic= false;
            projectileRegibody.velocity = -mouseDelta * velocityMult;
            FollowCam.POI = projecline;
            projecline = null;
        }

    }
}
