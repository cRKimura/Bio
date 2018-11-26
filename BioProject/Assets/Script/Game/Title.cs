using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Common.Base;

namespace GameMain {
    public class Title : BaseBehaviour
    {
        [SerializeField] private GameObject titleObject;
        [SerializeField] private Button startButton;

        public System.Action TouchCallBack { set; private get; }

        protected override void OnAwake()
        {
            startButton.onClick.AddListener(GameStartCallBack);
            titleObject.SetActive(false);
            base.OnAwake();
        }

        public void Initialize()
        {
            titleObject.SetActive(true);
        }
        protected override void Destroy()
        {
            startButton.onClick.RemoveAllListeners();
            base.Destroy();
        }

        private void GameStartCallBack()
        {
            titleObject.SetActive(false);
            if (TouchCallBack != null)
            {
                TouchCallBack();
            }
        }
    }
}
