using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float moveSpd = 1.0f;

	// Use this for initialization
	void OnEnable () {
        target = PlayerController.player.transform;
        SetCamera();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (target != null)
        {
            Vector3 targetPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpd);
            transform.rotation = Quaternion.identity;
        }
	}

    void SetCamera()
    {
        if (target != null)
        {
            transform.LookAt(target.position);
            offset = transform.position - target.position;
        }
    }
}
