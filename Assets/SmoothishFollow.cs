using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SmoothishFollow : MonoBehaviour
{



	public GameObject followTarget;

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	private float cameraZ = 0;

	private Camera cam;

	void Start () {
		cameraZ = transform.position.z;
		cam = GetComponent<Camera>();
        pPC = GetComponent<PixelPerfectCamera>();
	}
	


// 		if(_camera && followTarget){
// 			Vector2 newPosition = new Vector2(followTarget.transform.position.x, followTarget.transform.position.y);
// 			float nextX = Mathf.Round(_pixelLockedPPU * newPosition.x);
// 			float nextY = Mathf.Round(_pixelLockedPPU * newPosition.y);
// 			_camera.transform.position = new Vector3(nextX/_pixelLockedPPU, nextY/_pixelLockedPPU, _camera.transform.position.z);
// 		}
// 	}
// }
public PixelPerfectCamera pPC; 
void NextPos()
{
    Vector2 newPosition = new Vector2(followTarget.transform.position.x, followTarget.transform.position.y);
			float nextX = Mathf.Round(_pixelLockedPPU * newPosition.x);
			float nextY = Mathf.Round(_pixelLockedPPU * newPosition.y);
}

	void LateUpdate () {
		if (followTarget) {



			Vector3 delta = followTarget.transform.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, cameraZ));
			Vector3 destination = transform.position + delta;
			destination.z = cameraZ;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
	}
}



//     public Transform target;
//     public Vector3 camOffset;
//     public float followSpeed;
//     public float xMin = 0f;
//     Vector3 velocity = Vector3.zero;

//     void FixedUpdate()
//     {

//         Vector3 targetPos = target.position + camOffset;
//         Vector3 clampedPos = new Vector3(Mathf.Clamp(targetPos.x, xMin, float.MaxValue), targetPos.y, targetPos.z);
//         Vector3 smoothPos = Vector3.SmoothDamp(transform.position, clampedPos, ref velocity, followSpeed * Time.fixedDeltaTime);
//     }

//     // Start is called before the first frame update
//     void Start()
//     {

//     }

//     // Update is called once per frame
//     void Update()
//     {

//     }
// }
