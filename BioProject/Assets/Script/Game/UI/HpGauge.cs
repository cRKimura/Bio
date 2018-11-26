using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common.Base;

namespace GameMain.UI
{
    public class HpGauge : BaseBehaviour
    {
        [SerializeField] private Image gauge;

        private readonly Color32[] gaugeColors = new Color32[]
        {
            new Color32(0,255,0,255),
            new Color32(255,255,0,255),
            new Color32(255,0,0,255)
        };

        private Vector3 gaugeScale = Vector3.one;

        public void UpdateHpBar(float maxHp, float nowHp)
        {
            float par = nowHp / maxHp;
            gaugeScale.x = par;
            if (par >= 0.4f)
            {
                gauge.color = gaugeColors[0];
            }
            else if (par >= 0.2f)
            {
                gauge.color = gaugeColors[1];
            }
            else
            {
                gauge.color = gaugeColors[2];
            }
            gauge.transform.localScale = gaugeScale;
        }
    }
}