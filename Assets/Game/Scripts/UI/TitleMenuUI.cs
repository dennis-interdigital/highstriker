using UnityEngine;
using UnityEngine.UI;

namespace HighStriker
{
    public class TitleMenuUI : BaseUI
    {
        [SerializeField] Button buttonPlay;

        public override void Init(StageManager inStageManager)
        {
            base.Init(inStageManager);

            buttonPlay.onClick.AddListener(OnClickPlay);
        }

        public override void Show()
        {
            base.Show();
        }

        void OnClickPlay()
        {
            uiManager.ShowUI(UIState.Gameplay);
            stageManager.hammerController.StartCharge();
        }
    }
}

