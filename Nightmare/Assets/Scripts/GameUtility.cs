using UnityEngine;
using System.Collections;

namespace UIFramework
{
    public class GameUtility
    {
        /// <summary>
        /// 添加到目标节点下
        /// </summary>
        /// <param name="target"></param>
        /// <param name="child"></param>
        public static void AddChildToTarget(Transform target, Transform child)
        {
            child.parent = target;
            child.localScale = Vector3.one;
            child.localPosition = Vector3.one;
            child.localEulerAngles = Vector3.zero;

            ChangeChildLayer(child, target.gameObject.layer);
        }
        /// <summary>
        /// 修改UIlayer与父节点相同
        /// </summary>
        /// <param name="target"></param>
        /// <param name="layer"></param>
        public static void ChangeChildLayer(Transform target ,int layer)
        {
            target.gameObject.layer = layer;
            for(int i =0;i<target.childCount;i++)
            {
                Transform child = target.GetChild(i);
                child.gameObject.layer = layer;
                ChangeChildLayer(child, layer);
            }
        }
    }
}
