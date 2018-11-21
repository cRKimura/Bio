using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.Base;

namespace Character
{
    public class CharacterBase : BaseBehaviour
    {
        private Vector3 moveDir = Vector3.zero;
        private float speed = 0.1f;
        public void SetMoveDir(Vector3 dir)
        {
            moveDir = dir;
        }

        public override void UpdateCallBack(float addTime)
        {
            this.transform.localPosition += speed * moveDir;
            base.UpdateCallBack(addTime);
        }
    }
}
