using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.Base;

namespace GameMain {
    public class MainRoutine : BaseBehaviour
    {
        [SerializeField] private Title title;
        [SerializeField] private Battle gameMain;

        protected override void OnAwake()
        {
            UpdateManager.Instance.AddUpdateTarget(this);
            Application.targetFrameRate = Define.FrameRate;
            title.Initialize();
            title.TouchCallBack = GameStartCallBack;
            gameMain.GameOverCallBack = GameEndCallBack;
            base.OnAwake();
        }

        public override void UpdateCallBack(float addTime)
        {
            base.UpdateCallBack(addTime);
        }

        private void GameStartCallBack()
        {
            gameMain.GameStartInitialize();
        }

        private void GameEndCallBack()
        {
            title.Initialize();
        }

        protected override void Destroy()
        {
            UpdateManager.Instance.RemoveUpdateTarget(this);
            base.Destroy();
        }
    }
}
