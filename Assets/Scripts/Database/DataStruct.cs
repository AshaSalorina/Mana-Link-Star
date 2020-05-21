using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Asha.Data
{

    /// <summary>
    /// 按钮对象单选组
    /// </summary>
    public class ButtonSingle : Single<Button>
    {
        public ButtonSingle()
        {
            singleDatas = new List<Button>();
        }
        /// <summary>
        /// 添加按钮到组中，并自动添加选中监听
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override Single<Button> Add(Button obj)
        {
            if (!singleDatas.Contains(obj))
            {
                obj.onClick.AddListener(()=> 
                {
                    Choise(obj);
                });
                singleDatas.Add(obj);
            }
            return this;
        }

        /// <summary>
        /// 设置一个组中的某个按钮为选中状态
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override Single<Button> Choise(Button obj)
        {
            foreach (var item in singleDatas)
            {
                item.interactable = item != obj ;
            }
            return this;
        }

        /// <summary>
        /// 移除并销毁一个按钮
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override Single<Button> Remove(Button obj)
        {
            if (singleDatas.Contains(obj))
            {
                singleDatas.Remove(obj);
                GameObject.Destroy(obj.gameObject);
            }
            return this;
        }
    }

    /// <summary>
    /// GameObject对象单选组
    /// </summary>
    public class GameObjectSingle : Single<GameObject>
    {

        public override Single<GameObject> Add(GameObject obj)
        {
            if (!singleDatas.Contains(obj))
            {
                singleDatas.Add(obj);
            }
            return this;
        }

        public override Single<GameObject> Choise(GameObject obj)
        {
            foreach (var item in singleDatas)
            {
                item.SetActive(反转 ? item != obj : item == obj);
            }
            return this;
        }

        public override Single<GameObject> Remove(GameObject obj)
        {
            if (singleDatas.Contains(obj))
            {
                singleDatas.Remove(obj);
            }
            return this;
        }
    }

    /// <summary>
    /// 数据组抽象基类：单选,可反转
    /// </summary>
    public abstract class Single<T>
    {
        protected List<T> singleDatas = new List<T>();
        public bool 反转 { get; set; } = false;

        public abstract Single<T> Add(T obj);

        public abstract Single<T> Choise(T obj);

        public abstract Single<T> Remove(T obj);
    }
}