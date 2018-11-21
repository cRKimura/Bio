using UnityEngine;
using UnityEngine.Events;

namespace Common.Base
{
    public class TweenBase : BaseBehaviour
    {
        public enum PlayStyle
        {
            Once, //1回だけ
            Loop, //繰り返し
            Pong  //往復
        }

        public enum PlayType
        {
            None,  // 等速
            Early, // 最初早い終わり遅い
            Slow   // 最初遅く終わり早い
        }

        [SerializeField] private AnimationCurve animCurve = AnimationCurve.Linear(0, 0, 1, 1);
        [SerializeField] private PlayStyle playStyle = PlayStyle.Once;
        [SerializeField] private int playFrame = 1;
        public System.Action startCallBack { private get; set; }
        public System.Action finishedCallBack { private get; set; }

        private float playTime = 0f;
        private float addFrame = 0f;
        private bool isPlay = false;
        private bool isPlayTurnBack = false;
        private bool isPouse = false;

        private readonly float startTime = 0f;
        private readonly float turnBackTime = 1f;

        protected override void OnAwake()
        {
            isPlay = true;
            isPouse = false;
            isPlayTurnBack = false;
            base.OnAwake();
        }

        public virtual void SetUp(int playFrame, bool isTurnBack = false)
        {
            this.playFrame = playFrame;
            this.isPlayTurnBack = isTurnBack;
        }

        public void PlayTween()
        {
            if (isPlay)
            {
                // 現在実行中の際はどうするか、リセットするか、はじくか
                return;
            }

            isPlay = true;
            isPouse = false;
            playTime = isPlayTurnBack ? turnBackTime : startTime;
            addFrame = (float)(playFrame / Application.targetFrameRate);
        }

        public void StopTween()
        {

        }

        public override void UpdateCallBack(float addTime)
        {
            if (!isPlay)
            {
                return;
            }

            base.UpdateCallBack(addTime);
        }
    }
}
