using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float moveSpd = 1.0f;

	// Use this for initialization
	void Start () {
        SetCamera();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 targetPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpd);
	}

    void SetCamera()
    {
        transform.LookAt(target.position);
        offset = transform.position - target.position;
    }
}
