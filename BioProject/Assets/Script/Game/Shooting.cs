using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Common.Base;

namespace GameMain
{
    public class Shooting : BaseBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private EventFrame inputFrame;
        [SerializeField] private CharacterManager charaManager;

        private Vector3 touchPos = Vector3.zero;
        private Vector3 nowTouchPos = Vector3.zero;
        private bool isTouch = false;

        protected override void OnAwake()
        {
            UpdateManager.Instance.AddUpdateTarget(this);
            inputFrame.AddCallBack(EventTriggerType.PointerDown, OnInputFrameDownCallBack);
            inputFrame.AddCallBack(EventTriggerType.PointerUp, OnInputFrameUpCallBack);
            base.OnAwake();
        }

        public void GameStartInitialize()
        {
            charaManager.GameStartInitialize();
        }

        public override void UpdateCallBack(float addTime)
        {
            charaManager.playChara.SetMoveDir( UpdatePlayerDir() );
            charaManager.UpdateCallBack(addTime);
            base.UpdateCallBack(addTime);
        }

        private void OnInputFrameDownCallBack(BaseEventData b)
        {
             isTouch = true;
        }

        private void OnInputFrameUpCallBack(BaseEventData b)
        {
            isTouch = false;
        }

        private Vector3 UpdatePlayerDir()
        {
            if (!isTouch)
            {
                return Vector3.zero;
            }

            nowTouchPos = Input.mousePosition;
            nowTouchPos.z = 20;
            return mainCamera.ScreenToWorldPoint(nowTouchPos);
        }
    }
}