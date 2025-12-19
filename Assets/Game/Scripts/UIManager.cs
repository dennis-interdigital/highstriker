using System;
using System.Collections.Generic;
using UnityEngine;

namespace HighStriker
{
    public enum UIState
    {
        Title,
        Gameplay
    }

    public enum PopupState
    {
        None,
        Result
    }

    [Serializable]
    public class UIClass
    {
        public UIState state;
        public BaseUI ui;
    }

    [Serializable]
    public class PopupClass
    {
        public PopupState state;
        public BaseUI ui;
    }

    public class UIManager : MonoBehaviour
    {
        public List<UIClass> uiList;
        public List<PopupClass> popupList;

        public BaseUI currActiveUI;
        public UIState currUIState;

        public BaseUI currActivePopup;
        public PopupState currPopupState;

        StageManager stageManager;

        public void Init(StageManager inStageManager)
        {
            stageManager = inStageManager;

            foreach (UIClass uiClass in uiList)
            {
                uiClass.ui.Init(stageManager);
            }

            foreach (PopupClass popupClass in popupList)
            {
                popupClass.ui.Init(stageManager);
            }
        }

        public void DoUpdate(float dt)
        {
            if (currActiveUI != null)
            {
                currActiveUI.DoUpdate(dt);
            }

            if (currActivePopup != null)
            {
                currActivePopup.DoUpdate(dt);
            }
        }

        public void ShowUI(UIState state)
        {
            UIClass toActive = null;
            int count = uiList.Count;
            foreach (UIClass ui in uiList)
            {
                ui.ui.Hide();

                if (ui.state == state)
                {
                    toActive = ui;
                }
            }

            toActive.ui.Show();
            currActiveUI = toActive.ui;
            currUIState = state;
        }

        public void ShowPopup(PopupState state)
        {
            PopupClass toShow = GetPopup(state);
            if (toShow != null)
            {
                toShow.ui.Show();
                currActivePopup = toShow.ui;
                currPopupState = state;
            }
            else
            {
                Debug.LogError($"[HighStriker] Popup {state} NULL");
            }
        }

        public void HidePopup(PopupState state)
        {
            currActivePopup.Hide();
            currActivePopup = null;
            currPopupState = PopupState.None;
        }

        PopupClass GetPopup(PopupState state)
        {
            PopupClass result = null;

            foreach (PopupClass popup in popupList)
            {
                if (popup.state == state)
                {
                    result = popup;
                    break;
                }
            }

            return result;
        }
    }
}

