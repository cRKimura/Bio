using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Common.Base;

namespace GameMain {
    public class Title : BaseBehaviour
    {
        [SerializeField] private EventFrame touchFrame;

        public System.Action TouchCallBack { set; private get; }

        protected override void OnAwake()
        {
            touchFrame.AddCallBack(EventTriggerType.PointerUp, OnTouchFrameCallBack);
            base.OnAwake();
        }

        public void Initialize()
        {
            this.gameObject.SetActive(true);
            UpdateManager.Instance.AddUpdateTarget(this);
        }
        protected override void Destroy()
        {
            Debug.Log("e???");
            touchFrame.AllRemoveCallBack();
            base.Destroy();
        }

        private void OnTouchFrameCallBack(BaseEventData b)
        {
            Debug.Log("あれ？");
            if (TouchCallBack != null)
            {
                TouchCallBack();
            }
            this.gameObject.SetActive(false);
        }
    }
}
