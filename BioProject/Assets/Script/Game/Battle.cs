using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Common.Base;
using Common.JoyStick;
using GameMain.UI;
namespace GameMain
{
    public class Battle : BaseBehaviour
    {
        [SerializeField] private BattleCameraManager cameraManager;
        [SerializeField] private CharacterManager charaManager;
        [SerializeField] private BattleUIManager uiManager;

        private Vector2 moveDir = Vector2.zero;

        public System.Action GameOverCallBack = null;

        protected override void OnAwake()
        {
            uiManager.gameObject.SetActive(false);
            base.OnAwake();
        }

        public void GameStartInitialize()
        {
            uiManager.gameObject.SetActive(true);
            UpdateManager.Instance.AddUpdateTarget(this);
            charaManager.GameStartInitialize(PlayerDeadCallBack);
            uiManager.Initialize(JoyStickOnDragCallBack);
        }

        public override void UpdateCallBack(float addTime)
        {
            charaManager.UpdateCallBack(addTime);
            cameraManager.ChaseTarget(charaManager.playChara.transform.position);
            charaManager.playChara.SetMoveDir(moveDir);
            uiManager.UpdateUIManager(charaManager.playChara.GetStatus().maxHp, charaManager.playChara.GetStatus().hp);
            base.UpdateCallBack(addTime);
        }

        private void PlayerDeadCallBack()
        {
            UpdateManager.Instance.RemoveUpdateTarget(this);
            charaManager.GameEnd();
            uiManager.gameObject.SetActive(false);
            if (GameOverCallBack != null)
            {
                GameOverCallBack();
            }
        }

        private void JoyStickOnDragCallBack(Vector2 dir)
        {
            moveDir = dir;
        }
    }
}