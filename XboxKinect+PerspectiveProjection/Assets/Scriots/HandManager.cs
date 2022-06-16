using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [Header ("Kinect Data")]
    [SerializeField]private BodySourceView _bodySourceView;
    private Transform _kinectLeftHand;
    private Transform _kinectRightHand;
    
    [Header ("Target Objects")]
    [SerializeField]private Transform handLeft;
    [SerializeField]private Transform handRight;

    [Header ("Choose View")]
    [SerializeField]public bool isSideView;
    
    [Header("If Kinect Placed Infront or Behind of User:")]
    [SerializeField]private Vector3 offset;
    [SerializeField]private Vector3 scale;

    [Header("If Kinect Placed to either Side of the User:")]
    [SerializeField]private Vector3 sideOffset;
    [SerializeField]private Vector3 sideScale;

    [Header("Visual Debug Components:")] 
    [SerializeField]private Boolean viewHands;
    [SerializeField]private MeshRenderer handLeftMR;
    [SerializeField]private MeshRenderer handRightMR;
    [SerializeField]private Material handOpen;
    [SerializeField]private Material handClosed;



    // Update is called once per frame
    void Update()
    {
        if (_kinectRightHand == null) {
            getData();
            return;
        }
        
        if (_bodySourceView.leftHandOpen == "Open") { handLeftMR.material = handOpen; } else { handLeftMR.material = handClosed; }
        if (_bodySourceView.rightHandOpen == "Open") { handRightMR.material = handOpen; } else { handRightMR.material = handClosed; }
        
        if (isSideView) {
            handLeft.position = new Vector3(_kinectLeftHand.position.z * sideScale.z + sideOffset.z, _kinectLeftHand.position.y * sideScale.y + sideOffset.y, _kinectLeftHand.position.x * sideScale.x + sideOffset.x);
            handRight.position = new Vector3(_kinectRightHand.position.z * sideScale.z + sideOffset.z, _kinectRightHand.position.y * sideScale.y + sideOffset.y, _kinectRightHand.position.x * sideScale.x + sideOffset.x);

        }else
        {
            handLeft.position = new Vector3(_kinectLeftHand.position.x * scale.x + offset.x, _kinectLeftHand.position.y * scale.y + offset.y, _kinectLeftHand.position.z * scale.z + offset.z);
            handRight.position = new Vector3(_kinectRightHand.position.x * scale.x + offset.x, _kinectRightHand.position.y * scale.y + offset.y, _kinectRightHand.position.z * scale.z + offset.z);
        }
    }

    void getData()
    {
        try
        {
            _kinectLeftHand = GameObject.Find("HandLeft").GetComponent<Transform>();
            _kinectRightHand = GameObject.Find("HandRight").GetComponent<Transform>();
        }
        catch
        {
            Debug.Log("waiting to identify person in scene...");
        }
    }
}
