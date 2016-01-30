using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace UIFramework
{
    /// <summary>
    /// UI界面管理类
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        //UI根节点
        public Transform UIRoot;

        //普通UI结构节点
        [System.NonSerialized]
        public Transform UINormalRoot;
        //弹出式UI结构节点
        [System.NonSerialized]
        public Transform UIPopUpRoot;
        //遮罩UI结构节点
        [System.NonSerialized]
        public Transform UIMaskRoot;

        //节点层级
        private int normalRootDepth = 2;
        private int popupRootDepth = 100;
        private int maskRootDepth = 150;

        //所有已打开的UI（包含隐藏）
        protected Dictionary<UIID, UIBase> allUI = new Dictionary<UIID, UIBase>();
        //所有正在显示的UI
        protected Dictionary<UIID, UIBase> shownUI = new Dictionary<UIID, UIBase>();

        private static UIManager _instance;
        public static UIManager GetInstance()
        {
            if (_instance == null)
                _instance = new UIManager();
            return _instance;
        }

        protected void Awake()
        {
            Debug.Log("UIManager Awake ");
            _instance = this;
            InitUIManager();
        }

        public void InitUIManager()
        {
            DontDestroyOnLoad(UIRoot);
            CheckUIRoot();
        }

        private void CheckUIRoot()
        {
            if (UINormalRoot == null)
            {
                UINormalRoot = new GameObject("UINormalRoot").transform;
                GameUtility.AddChildToTarget(UIRoot, UINormalRoot);
            }
            if (UIPopUpRoot == null)
            {
                UIPopUpRoot = new GameObject("UIPopUpRoot").transform;
                GameUtility.AddChildToTarget(UIRoot, UIPopUpRoot);
            }
            if (UIMaskRoot == null)
            {
                UIMaskRoot = new GameObject("UIMaskRoot").transform;
                GameUtility.AddChildToTarget(UIRoot, UIMaskRoot);
            }
        }

        public void ShowUI(UIID id)
        {
            UIBase uibase = ReadyToShowUI(id);
            if (uibase != null)
            {
                DoShowUI(uibase, id);
            }
        }

        private UIBase ReadyToShowUI(UIID id)
        {
            if (shownUI.ContainsKey(id))
                return null;

            UIBase ui = GetUIBase(id);
            //如果ui没有被打开，则重新创建
            if (!ui)
            {
                if (UIResourceDefine.UIPrefabPath.ContainsKey(id))
                {
                    string prefabPath = UIResourceDefine.UIPrefabPathString + UIResourceDefine.UIPrefabPath[id];
                    GameObject prefab = Resources.Load<GameObject>(prefabPath);
                    if (prefab != null)
                    {
                        GameObject uiObject = (GameObject)GameObject.Instantiate(prefab);
                        uiObject.SetActive(true);
                        ui = uiObject.GetComponent<UIBase>();
                        if (!ui)
                            Debug.LogError(id + " cannot get component <UIBase>");

                        Transform targetRoot = GetTargetRoot(ui.GetUIType());
                        GameUtility.AddChildToTarget(targetRoot, ui.gameObject.transform);

                        allUI[id] = ui;
                    }
                }
            }
            return ui;
        }

        void DoShowUI(UIBase ui, UIID id)
        {
            ui.ShowUI();
            shownUI[id] = ui;
        }

        /// <summary>
        /// 获取UIBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private UIBase GetUIBase(UIID id)
        {
            if (allUI.ContainsKey(id))
                return allUI[id];
            else
                return null;
        }

        private Transform GetTargetRoot(UIType type)
        {
            if (type == UIType.Normal)
                return UINormalRoot;
            if (type == UIType.Popup)
                return UIPopUpRoot;
            if (type == UIType.Mask)
                return UIMaskRoot;
            return UIRoot;
        }
    }
}


