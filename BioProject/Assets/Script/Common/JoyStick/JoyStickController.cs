using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Common.Base;

namespace Common.JoyStick
{
    public class JoyStickController : BaseBehaviour
    {
        [SerializeField] private RectTransform StickRect;

        private Vector3 dragStartPosition;
        private Vector3 basePosition;
        public RectTransform selfRect;

        protected override void OnAwake()
        {
            this.selfRect = this.GetComponent<RectTransform>();
            base.OnAwake();
        }

        /// <summary>
        /// ジョイスティックで使用する円の構造体
        /// </summary>
        [Serializable]
        public struct Circle
        {
            public Image img;

            public float Radius
            {
                get { return (img) ? img.rectTransform.sizeDelta.x / 2 : 0f; }
            }

            public Vector3 Center
            {
                get { return (img) ? img.rectTransform.anchoredPosition3D : Vector3.zero; }
            }
        }

        /// <summary>
        /// 台座部分
        /// </summary>
        [SerializeField]
        private Circle padBase;

        /// <summary>
        /// 入力部分
        /// </summary>
        [SerializeField]
        private Circle inputStick;

        /// <summary>
        /// ドラッグした距離
        /// </summary>
        private Vector2 dragDir;

        /// <summary>
        /// 完了イベント
        /// </summary>
        public System.Action onDragEndCallBack = null;

        /// <summary>
        /// 完了イベント
        /// </summary>
        public System.Action<Vector2> onDragCallBack = null;

        public void OnBeginJoyStick(Vector3 startPos)
        {
            dragStartPosition = startPos;
            basePosition = startPos;
            dragDir = Vector2.zero;
        }

        private Vector3 totalMove = Vector2.zero;
        private Vector3 nextPosition = Vector2.zero;
        public void UpdateDragPosition(Vector3 mousePos)
        {
            totalMove = mousePos - dragStartPosition;
            nextPosition = basePosition + totalMove;
            if (CanSwipe(nextPosition))
            {
                float rate = GetDistanceRate(mousePos);
                StickRect.position = nextPosition;
                dragDir = totalMove.normalized * rate;
            }
            else
            {
                float rate = SafeStick(mousePos);
                var fixedNextPosition = basePosition + totalMove * rate;
                dragDir = totalMove.normalized;
                StickRect.position = fixedNextPosition;
            }
            if (onDragCallBack !=null)
            {
                onDragCallBack(dragDir);
            }
        }

        public void OnEndDrag()
        {
            StickRect.anchoredPosition = Vector2.zero;
            if(onDragEndCallBack != null)
            {
                onDragEndCallBack();
            }
            if (onDragCallBack != null)
            {
                onDragCallBack(Vector2.zero);
            }
        }

        private bool CanSwipe(Vector3 nextPosition)
        {
            float distance = Vector3.Distance(padBase.Center, nextPosition);
            bool canSwipe = (distance + inputStick.Radius) <= padBase.Radius;

            return canSwipe;
        }

        private float SafeStick(Vector3 input)
        {
            float max = padBase.Radius - inputStick.Radius;
            float current = Vector3.Distance(padBase.Center, input);
            float distanceRate = max / current;
            return distanceRate;
        }

        private float GetDistanceRate(Vector3 input)
        {
            float max = padBase.Radius - inputStick.Radius;
            float current = Vector3.Distance(padBase.Center, input);
            float distanceRate = current / max;
            return distanceRate;
        }
    }
}
