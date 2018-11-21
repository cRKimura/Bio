using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Common.UI
{
    public class CullGraphic : Graphic
    {
        private readonly Color defaultColor = new Color32(0, 0, 0, 1);
        // Use this for initialization
        override protected void Awake()
        {
            this.color = defaultColor;
            base.Awake();
        }

        override protected void OnValidate()
        {
            #if UNITY_EDITOR
            if (EditorApplication.isPlaying)
            {
                return;
            }
            #endif
            this.color = defaultColor;
            base.OnValidate();
        }
    }
}