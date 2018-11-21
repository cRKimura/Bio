using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Base
{
    public class SingletonBehaviour<T> : BaseBehaviour where T : BaseBehaviour, new()
    {
        private static T instance;
        public static T Instance {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject(typeof(T).Name).AddComponent<T>();
                    DontDestroyOnLoad(instance);
                }

                return instance;
            }
        }

        protected override void OnAwake()
        {
            isSingleton = true;
            Create();
        }

        protected virtual void Create()
        {

        }
    }
}
