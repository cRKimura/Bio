using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.Base;

namespace Character
{
    public class PlayCharacter : CharacterBase
    {
        [SerializeField] private SpriteRenderer spriteRender;

        public override void UpdateCallBack(float addTime)
        {

            base.UpdateCallBack(addTime);
        }
    }
}
