using UnityEngine;
using System.Collections;

public class TestBoneMove : MonoBehaviour {

    private SkinnedMeshRenderer smr;
	// Use this for initialization
	void Start () {
	    //smr = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        //smr.bones[0].transform.position
        Vector3 pos = new Vector3(0, 0, 0);
        Transform leftHand = gameObject.transform.Find("Dana/Hips/Spine/Spine1/Spine2/LeftShoulder/LeftArm/LeftForeArm/LeftHand");
        Debug.Log("left hand position: "+leftHand.position);
        leftHand.transform.Translate(new Vector3(-1,0,0));
        // leftHand.position.x += 10;
       // gameObject.transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
