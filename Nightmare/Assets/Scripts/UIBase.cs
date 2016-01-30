using UnityEngine;
using System.Collections;

namespace UIFramework
{
    public class UIBase : MonoBehaviour
    {
        protected UIID id = UIID.UIID_Invaild;
        protected UIType type = UIType.Normal;

        bool isShown = false;
        bool isLock = true;

        private Transform mTrs;

        public UIID GetUIID
        {
            get
            {
                if (this.id == UIID.UIID_Invaild)
                    Debug.LogError("The UIID is " + UIID.UIID_Invaild);
                return id;
            }
            private set { id = value; }
        }


        protected virtual void Awake()
        {
            this.gameObject.SetActive(true);
            mTrs = this.gameObject.transform;

            InitUIOnAwake();
        }

        //显示UI
        public virtual void ShowUI()
        {
            isLock = false;
            isShown = true;
            mTrs.gameObject.SetActive(true);
        }
        //隐藏UI（非关闭）
        public virtual void HideUI()
        {
            isShown = false;
            isLock = true;
            mTrs.gameObject.SetActive(false);
        }
        //销毁UI
        public virtual void DestroyUI()
        {
            GameObject.Destroy(this.gameObject);
        }

        /// <summary>
        /// 获得UITYPE
        /// </summary>
        /// <returns></returns>
        public UIType GetUIType()
        {
            return type;
        }

        /// <summary>
        /// 由各个界面重写，用于初始化界面
        /// </summary>
        public virtual void InitUIOnAwake()
        {

        }
    }
}