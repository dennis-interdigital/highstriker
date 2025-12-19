using UnityEngine;

namespace HighStriker
{
    public class BaseUI : MonoBehaviour
    {
        protected StageManager stageManager;
        protected UIManager uiManager;

        public virtual void Init(StageManager inStageManager)
        {
            stageManager = inStageManager;
            uiManager = stageManager.uiManager;
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        public virtual void DoUpdate(float dt)
        {

        }
    }
}

