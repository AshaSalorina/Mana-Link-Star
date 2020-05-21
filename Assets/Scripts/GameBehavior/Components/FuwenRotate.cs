using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asha.Component
{
    public class FuwenRotate : MonoBehaviour
    {
        public int Index = 0;

        // 两者相乘为旋转的每个fixedupdate的速度
        public float RotateX = 1;

        public float RotateY = 0;

        public float RotateZ = 0;

        public float Angle = 1;

        private void Update()
        {
            Angle = transform.parent.GetComponent<Asha.Data.BaseFazhen>().转速[Index];
        }

        private void FixedUpdate()
        {
            transform.Rotate(new Vector3(RotateX, RotateY, RotateZ), Angle);
        }
    }
}

