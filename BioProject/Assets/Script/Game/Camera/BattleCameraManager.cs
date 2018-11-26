using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.Base;

namespace GameMain
{
    public class BattleCameraManager : BaseBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private float dampTime;

        private Vector3 viewPoint;
        private Vector3 delta;
        private Vector3 destination;
        private Vector3 velocity;
        public void ChaseTarget(Vector3 targetPos)
        {
            viewPoint = mainCamera.WorldToViewportPoint(targetPos);
            delta = targetPos - mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, viewPoint.z));
            destination = mainCamera.transform.position + delta;
            mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, destination, ref velocity, dampTime);
        }
    }
}
