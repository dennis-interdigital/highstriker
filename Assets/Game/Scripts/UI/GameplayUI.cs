using UnityEditor.ProjectWindowCallback;
using UnityEngine;
using UnityEngine.UI;

namespace HighStriker
{
    public class GameplayUI : BaseUI
    {
        [SerializeField] Slider sliderBar;
        [SerializeField] Image imgBar;
        [SerializeField] ButtonHitListener buttonHitListener;

        HammerController hammerController;

        float colorFactor;

        public override void Init(StageManager inStageManager)
        {
            base.Init(inStageManager);
            hammerController = stageManager.hammerController;

            buttonHitListener.Init(this);

            colorFactor = 0.5f;
        }

        public override void DoUpdate(float dt)
        {
            if (hammerController.isPlaying)
            {
                sliderBar.value = hammerController.currentPower;
            }
        }

        public void RefreshSliderHitBar(float value)
        {
            sliderBar.value = value;
        }

        void Update()
        {
            if (hammerController.isPlaying)
            {
                if (hammerController.currentPower < colorFactor)
                {
                    float value = hammerController.currentPower / colorFactor;
                    imgBar.color = Color.Lerp(Color.red, Color.yellow, value);
                }
                else
                {
                    float value = (hammerController.currentPower - colorFactor) / colorFactor;
                    imgBar.color = Color.Lerp(Color.yellow, Color.green, value);
                }
            }
        }

        public void SetButtonHit(bool enable)
        {
            buttonHitListener.gameObject.SetActive(enable);
        }

        public void Hit()
        {
            hammerController.Hit();
            SetButtonHit(false);
        }
    }
}


