using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace HighStriker
{
    public class ResultPopup : BaseUI
    {
        [SerializeField] TextMeshProUGUI textScore;
        [SerializeField] Button buttonTryAgain;

        HammerController hammerController;

        public override void Init(StageManager inStageManager)
        {
            base.Init(inStageManager);
            hammerController = stageManager.hammerController;

            buttonTryAgain.onClick.AddListener(OnClickTryAgain);
        }

        public override void Show()
        {
            float score = hammerController.currentPower;
            int scoreInt = (int)(score * 100);

            textScore.SetText(scoreInt.ToString());

            base.Show();
        }

        void OnClickTryAgain()
        {
            uiManager.HidePopup(PopupState.Result);
            stageManager.hammerController.StartCharge();
        }
    }
}

