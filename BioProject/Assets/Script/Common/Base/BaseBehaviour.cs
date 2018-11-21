using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Base
{
    public class BaseBehaviour : MonoBehaviour
    {
        protected bool isSingleton = false;
        public bool IsSingleton { get { return isSingleton; } }
        // UpdateManager側に登録されて実行される
        public virtual void UpdateCallBack(float addTime) { }
        public virtual void LateUpdateCallBack(float addTime) { }


        protected virtual void OnStart() { }
        protected virtual void OnAwake() { }
        protected virtual void Destroy() { }
        void Awake()
        {
            OnAwake();
        }
        void Start()
        {
            OnStart();
        }
        private void OnDestroy()
        {
            Destroy();
        }
    }
}
