using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.Base;

namespace Character
{
    public class CharacterBase : BaseBehaviour
    {
        private Vector3 moveDir = Vector3.zero;
        protected CharaStatus charaStatus;
        public CharaStatus GetStatus() { return charaStatus; }

        public System.Action DeadCallBack = null;
        public void SetCharaStatus(float hp, float speed)
        {
            charaStatus.maxHp = hp;
            charaStatus.hp = hp;
            charaStatus.speed = speed;
            charaStatus.state = CharaState.Alone;
        }

        public void SetMoveDir(Vector2 dir)
        {
            moveDir.x = dir.x;
            moveDir.y = dir.y;
        }

        public override void UpdateCallBack(float addTime)
        {
            this.transform.localPosition += charaStatus.speed * moveDir;
            base.UpdateCallBack(addTime);
        }

        public virtual void DeadEffects()
        {
            // 死亡演出関数
        }
    }
}
