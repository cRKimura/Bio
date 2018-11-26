using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Tween
{
    [RequireComponent(typeof(Graphic))]
    public class TweenAlpha : TweenBase
    {
        [SerializeField, Range(0f, 1f)] private float startAlpha = 1f;
        [SerializeField, Range(0f, 1f)] private float endAlpha = 1f;

        private Graphic graphic = null;
        private float originalAlpha;
        private Color changeColor;
        private float changeAlpha;
        // Use this for initialization
        protected override void OnAwake()
        {
            base.OnAwake();
            this.graphic = GetComponent<Graphic>();
            originalAlpha = this.graphic.color.a;
        }

        protected override void UpdateProc()
        {
            changeAlpha = Mathf.Lerp(startAlpha, endAlpha, GetPlayPer());
            changeColor = this.graphic.color;
            changeColor.a = changeAlpha;
            this.graphic.color = changeColor;
        }
    }
}
