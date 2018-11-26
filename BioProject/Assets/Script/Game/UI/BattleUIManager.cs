using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Common.Base;
using Common.JoyStick;


namespace GameMain.UI
{
    public class BattleUIManager : BaseBehaviour
    {
        [SerializeField] private JoyStickController joyStick;
        [SerializeField] private EventFrame inputFrame;
        [SerializeField] private HpGauge gauge;

        private float screenHurfSize = Screen.width / 2f;

        public void Initialize(System.Action<Vector2> joyStickOnDragCallBack)
        {
            inputFrame.AddCallBack(EventTriggerType.PointerDown, OnInputFrameDownCallBack);
            inputFrame.AddCallBack(EventTriggerType.PointerUp, OnInputFrameUpCallBack);
            joyStick.onDragCallBack = joyStickOnDragCallBack;
            joyStick.gameObject.SetActive(false);
            base.OnAwake();
        }

        public void UpdateUIManager(float maxHp, float nowHp)
        {
            if (joyStick.gameObject.activeSelf)
            {
                joyStick.UpdateDragPosition(Input.mousePosition);
            }
            gauge.UpdateHpBar(maxHp, nowHp);
        }
        private void OnInputFrameDownCallBack(BaseEventData b)
        {
            joyStick.selfRect.anchoredPosition3D = Input.mousePosition;
            if (screenHurfSize > joyStick.selfRect.anchoredPosition3D.x)
            {
                joyStick.gameObject.SetActive(true);
                joyStick.OnBeginJoyStick(joyStick.selfRect.anchoredPosition3D);
            }
        }

        private void OnInputFrameUpCallBack(BaseEventData b)
        {
            joyStick.gameObject.SetActive(false);
            joyStick.OnEndDrag();
        }
    }
}
