using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public struct CharaStatus
    {
        public float maxHp;
        public float hp;
        public float speed;
        public CharaState state;
    }

    public enum CharaState
    {
        Alone = 0, // 寄生等されていない時(共通)
        Parasitism, // 寄生しているかされている時(共通)
        Dead, // HPがなくなったとき(共通)
        Fear, // 対立している敵におびえている(Enemy)
        Warlike, // 有利な相手を見つけたとき(Enemy)
    }
}