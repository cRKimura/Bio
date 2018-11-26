﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Tween
{
    [RequireComponent(typeof(Graphic))]
    public class TweenColor : TweenBase
    {
        [SerializeField] private Color startColor = Color.white;
        [SerializeField] private Color endColor = Color.white;

        private Graphic graphic = null;
        private float originalAlpha;
        private Color changeColor;
        protected override void OnAwake()
        {
            base.OnAwake();
            this.graphic = GetComponent<Graphic>();
            originalAlpha = this.graphic.color.a;
        }

        protected override void UpdateProc()
        {
            changeColor = Color.LerpUnclamped(startColor, endColor, GetPlayPer());
            changeColor.a = originalAlpha;
            this.graphic.color = changeColor;
        }
    }
}
