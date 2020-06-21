using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
/// <summary>
/// Manages the Cube with the Oculus Hands base functionalities
/// When the Left Index touches the cube, it becomes blue;
/// When the Right Index touches the cube, it become green;
/// When the Left hand pinches the middle finger, it becomes red;
/// </summary>
[RequireComponent(typeof(Collider))]
public class cubeInteraction : MonoBehaviour
{
    private Renderer m_renderer;
    
    // private OVRHand leftHand;
    // private OVRHand rightHand;

    public Material leftHandMat;
    public Material rightHandMat;
    // check if its a left hand (red) or a right hand (blue) cube
    public Boolean isLeftCube = false;
    public float cubeSpeed = 1f;
    public float destroyAt = 5f;

    public Action cubeHit;
    public Action cubeMiss;
 
    void Start()
    {
        m_renderer = GetComponent<Renderer>();
        // leftHand = GameObject.Find("OVRCameraRig/TrackingSpace/LeftHandAnchor/OVRHandPrefab").GetComponent<OVRHand>();
        // rightHand = GameObject.Find("OVRCameraRig/TrackingSpace/RightHandAnchor/OVRHandPrefab").GetComponent<OVRHand>();

        if (isLeftCube) {
            m_renderer.material = leftHandMat;
        } else {
            m_renderer.material = rightHandMat;
        }
    }

    void Update() {
        updateCubesWithTimeInterval();
    }

    public void handCollisionEnter() {
        // GetComponent<Collider>().enabled = false;
        // Destroy(gameObject);
        // cubeHit();
    }

 
    // Trigger enter.
    // Notice that this gameobject must have a trigger collider
    private void OnTriggerEnter(Collider collider)
    {
        //get hand associated with trigger
        // int handIdx = GetIndexFingerHandId(collider);
        // int targetIndex = isLeftCube ? 0 : 1;
 
        // //if there is an associated hand, it means that an index of one of two hands is entering the cube
        // //change the color of the cube accordingly (blue for left hand, green for right one)
        // if (handIdx == targetIndex)
        // {
            // disable collider so it wont be called by multiple finger bones
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject);
        cubeHit();
        //}
    }
 
    // Gets the hand id associated with the index finger of the collider passed as parameter, if any
    // returns 0 if the collider represents the finger tip of left hand, 1 if it is the one of right hand, -1 if it is not an index fingertip
    // private int GetIndexFingerHandId(Collider collider)
    // {
    //     //Checking Oculus code, it is possible to see that physics capsules gameobjects always end with _CapsuleCollider
    //     if (collider.gameObject.name.Contains("_CapsuleCollider"))
    //     {
    //         //get the name of the bone from the name of the gameobject, and convert it to an enum value
    //         string boneName = collider.gameObject.name.Substring(0, collider.gameObject.name.Length - 16);
    //         OVRPlugin.BoneId boneId = (OVRPlugin.BoneId)Enum.Parse(typeof(OVRPlugin.BoneId), boneName);
 
    //         //if it is the tip of the Index
    //         if (boneId == OVRPlugin.BoneId.Hand_Index3 || boneId == OVRPlugin.BoneId.Hand_Index2 || boneId == OVRPlugin.BoneId.Hand_Index1)
    //             //check if it is left or right hand, and change color accordingly.
    //             //Notice that absurdly, we don't have a way to detect the type of the hand
    //             //so we have to use the hierarchy to detect current hand
    //             if (collider.transform.IsChildOf(leftHand.transform))
    //             {
    //                 return 0;
    //             }
    //             else if (collider.transform.IsChildOf(rightHand.transform))
    //             {
    //                 return 1;
    //             }
    //     }
 
    //     return -1;
    // }

    void updateCubesWithTimeInterval() {
        Vector3 updateVector = new Vector3(0f, 0f, -Time.deltaTime * cubeSpeed);
        transform.position += updateVector;
        if (Math.Abs(transform.localPosition.z) > destroyAt) {
            cubeMiss();
            Destroy(gameObject);
        }
    }
}