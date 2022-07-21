using System.Collections;
using System.Collections.Generic;
using Windows.Kinect;
using UnityEngine;
using Joint = Windows.Kinect.Joint;

public class CameraFollow : MonoBehaviour
{
    private Joint _kinectHeadJoint;
    private Vector3 _target;

    [Header("Scene References")]
    [SerializeField]
    BodySourceManager m_BodySourceManager;

    [Header("Camera Lerp Speed:")]
    [SerializeField]private float lerpSpeed;

    [Header("When Kinect Placed Infront or Behind of User:")]
    [SerializeField]private Vector3 offset;
    [SerializeField]private Vector3 scale;

    [Header("When Kinect Placed to either Side of the User:")]
    [SerializeField]private bool isSideView;
    [SerializeField]private Vector3 sideOffset;
    [SerializeField]private Vector3 sideScale;
    
    void Update()
    {
        if (_kinectHeadJoint == default)
        {
            if (!TryGetHeadJoint())
            {
                return;
            }
        }

        var headPos = _kinectHeadJoint.Position;
        if (!isSideView)
        {
            _target.x = (headPos.X + offset.x) * scale.x;
            _target.y = (headPos.Y + offset.y) * scale.y;
            _target.z = (headPos.Z + offset.z) * scale.z;
        }
        else
        {
            _target.x = (headPos.X + sideOffset.z) * sideScale.z;
            _target.y = (headPos.Y + sideOffset.y) * sideScale.y;
            _target.z = (headPos.Z + sideOffset.x) * sideScale.x;
        }

        transform.position = Vector3.Lerp(transform.position, _target, Time.deltaTime * lerpSpeed);
    }
    
    bool TryGetHeadJoint()
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

        Joint joint = default;
        foreach (var body in data)
        {
            if (body.Joints.TryGetValue(JointType.Head, out joint))
                break;
        }

        if (joint == default)
            return false;
        
        _kinectHeadJoint = joint;
        return true;
    }
}
