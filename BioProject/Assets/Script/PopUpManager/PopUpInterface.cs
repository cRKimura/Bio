using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Common.Base;
namespace PopUp
{
    public abstract class PopUpInterface<OpenData, CloseCallBack> : BaseBehaviour
    {
        // Alphaや押せなくするなどの管理用
        [SerializeField] private CanvasGroup canvasGroup;
        // Xボタン
        [SerializeField] private Button closeButton;
        // 枠外タップ時に反応する板
        [SerializeField] private EventTrigger backPlate;

        protected bool isOpen = false;
        public bool IsOpen { get { return isOpen; } }

        abstract public void Create();
        abstract public void Open(OpenData openData, System.Action openEndCallBack, CloseCallBack closeEndCallBack, bool isAnime = true );
        abstract public void Close(bool isAnime = false);
        abstract public void BackKey();
    }
}
