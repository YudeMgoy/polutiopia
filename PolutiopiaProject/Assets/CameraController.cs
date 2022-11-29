using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] Camera orthoCamera;
    [SerializeField, Range(0, 20)] float filterFactor = 1f;
    [SerializeField, Range(0, 2)] float dragFactor = 1f;
    [SerializeField, Range(0, 2)] float zoomFactor = 1f;
    [Tooltip("equal camera y position")]
    [SerializeField] float minCamPos = 50f;
    [SerializeField] float maxCamPos = 150f;
    [SerializeField] Collider camBarrier;

    float distance;


    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position.y;
    }

    Vector3 touchBeganWorldPos;
    Vector3 cameraBeganWorldPos;
    void Update()
    {
        if (Input.touchCount == 0)
            return;

        var touch0 = Input.GetTouch(0);


        if (touch0.phase == TouchPhase.Began)
        {
            touchBeganWorldPos = Camera.main.ScreenToWorldPoint(
                new Vector3(touch0.position.x, touch0.position.y, distance));
            cameraBeganWorldPos = this.transform.position;
        }


        if (Input.touchCount == 1 && touch0.phase == TouchPhase.Moved)
        {

            var touchMovedWorldPos = Camera.main.ScreenToWorldPoint(
                new Vector3(touch0.position.x, touch0.position.y, distance));


            var delta = touchMovedWorldPos - touchBeganWorldPos;

            var targetPos = cameraBeganWorldPos - delta * dragFactor;

            targetPos = new Vector3(
                Mathf.Clamp(targetPos.x, camBarrier.bounds.min.x, camBarrier.bounds.max.x),
                targetPos.y,
                Mathf.Clamp(targetPos.z, camBarrier.bounds.min.z, camBarrier.bounds.max.z)
                );

            this.transform.position = Vector3.Lerp(
                this.transform.position,
                targetPos,
                Time.deltaTime * filterFactor
            );
        }

        if (Input.touchCount < 2)
            return;

        var touch1 = Input.GetTouch(1);

        if (touch0.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Moved)
        {
            var touch0PrevPos = touch0.position - touch0.deltaPosition;
            var touch1PrevPos = touch1.position - touch1.deltaPosition;
            var prevDistance = Vector3.Distance(touch0PrevPos, touch1PrevPos);
            var currDistance = Vector3.Distance(touch0.position, touch1.position);
            var delta = currDistance - prevDistance;

            if (orthoCamera.orthographic)
            {
                orthoCamera.orthographicSize = Mathf.Clamp(
                    orthoCamera.orthographicSize - delta * zoomFactor,
                    minCamPos,
                    maxCamPos
                );
            }
            else
            {
                orthoCamera.fieldOfView = Mathf.Clamp(
                    orthoCamera.fieldOfView - delta * zoomFactor,
                    minCamPos,
                    maxCamPos
                );
            }
            distance = this.transform.position.y;
        }
    }
}
