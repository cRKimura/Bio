using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common.Base;
using Character;

namespace GameMain
{
    public class CharacterManager : BaseBehaviour {
        [SerializeField] private GameObject charaParent;

        public PlayCharacter playChara { get; private set; }
        public List<EnemyCharacter> enemyCharaList { get; private set; }

        protected override void OnAwake()
        {
            base.OnAwake();
        }

        public override void UpdateCallBack(float addTime)
        {
            playChara.UpdateCallBack(addTime);
            base.UpdateCallBack(addTime);
        }

        public void GameStartInitialize()
        {
            // Playerの作成
            playChara = GameObject.Instantiate<PlayCharacter>( Resources.Load<PlayCharacter>("Prefab/Chara/tubasa") );
            playChara.transform.SetParent(charaParent.transform);
        }
    }
}