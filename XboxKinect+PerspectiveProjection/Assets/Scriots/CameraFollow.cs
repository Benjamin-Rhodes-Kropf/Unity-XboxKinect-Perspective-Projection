using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _kinectHeadTransform;
    private Vector3 _target;

    [Header("Camera Lerp Speed:")]
    [SerializeField]private float lerpSpeed;

    [Header("When Kinect Placed Infront or Behind of User:")]
    [SerializeField]private Vector3 offset;
    [SerializeField]private Vector3 scale;

    [Header("When Kinect Placed to either Side of the User:")]
    [SerializeField]private bool isSideView;
    [SerializeField]private Vector3 sideOffset;
    [SerializeField]private Vector3 sideScale;



    // Update is called once per frame
    void Update()
    {
        if (_kinectHeadTransform == null) {
            getData();
            return;
        }

        if (!isSideView)
        {
            _target.x = (_kinectHeadTransform.position.x + offset.x) * scale.x;
            _target.y = (_kinectHeadTransform.position.y + offset.y) * scale.y;
            _target.z = (_kinectHeadTransform.position.z + offset.z) * scale.z;
        }
        else
        {
            _target.x = (_kinectHeadTransform.position.z + sideOffset.z) * sideScale.z;
            _target.y = (_kinectHeadTransform.position.y + sideOffset.y) * sideScale.y;
            _target.z = (_kinectHeadTransform.position.x + sideOffset.x) * sideScale.x;
        }

        transform.position = Vector3.Lerp(transform.position, _target, Time.deltaTime * lerpSpeed);
    }

    void getData()
    {
        try
        {
             _kinectHeadTransform = GameObject.Find("Head").GetComponent<Transform>();
        }
        catch
        {
            Debug.Log("failed to find person in scene");
        }
    } 
}

