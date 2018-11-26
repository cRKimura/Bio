using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.Base;

namespace Character
{
    public class PlayCharacter : CharacterBase
    {
        public override void UpdateCallBack(float addTime)
        {
            // Hpが減っていく
            if (charaStatus.state == CharaState.Alone || charaStatus.state == CharaState.Parasitism)
            {
                charaStatus.hp -= addTime;
                if (charaStatus.hp <= 0f)
                {
                    charaStatus.state = CharaState.Dead;
                    charaStatus.hp = 0;
                    if (DeadCallBack != null)
                    {
                        DeadCallBack();
                    }
                }
            }
            base.UpdateCallBack(addTime);
        }
    }
}
