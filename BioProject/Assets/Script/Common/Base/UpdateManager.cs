using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Common.Base
{
    public class UpdateManager : SingletonBehaviour<UpdateManager>
    {
        private List<BaseBehaviour> updateTargetList = new List<BaseBehaviour>();
        // Update is called once per frame
        void Update()
        {
            float addTime = Time.deltaTime;
            foreach (BaseBehaviour obj in updateTargetList)
            {
                if (obj == null || !obj.isActiveAndEnabled)
                {
                    continue;
                }
                obj.UpdateCallBack(addTime);
            }
            foreach (BaseBehaviour obj in updateTargetList)
            {
                if (obj == null || !obj.isActiveAndEnabled)
                {
                    continue;
                }
                obj.LateUpdateCallBack(addTime);
            }
        }

        public void AddUpdateTarget(BaseBehaviour target)
        {
            if (updateTargetList.Where( v => v == target ).Any() )
            {
                // 同一のモノは登録しない
                return;
            }
            updateTargetList.Add(target);
        }

        public void RemoveUpdateTarget(BaseBehaviour target)
        {
            updateTargetList.Remove(target);
        }

        // シーン切り替え時に現在Singletonじゃないやつ以外をListから削除する
        // 対象となるObjectの削除はこっちでやるのかな...どうだろ
        public void ChangeScene()
        {
            for (int i = 0; i < updateTargetList.Count; i++)
            {
                if (updateTargetList[i] != null && updateTargetList[i].IsSingleton)
                {
                    continue;
                }

                updateTargetList.RemoveAt(i);
            }
        }
    }
}
