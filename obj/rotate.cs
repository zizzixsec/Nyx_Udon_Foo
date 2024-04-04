
using UdonSharp;
using UnityEngine;

namespace nyx.obj {
    public class rotate : UdonSharpBehaviour {

        public GameObject gameObj;
        public float angleX,angleY,angleZ;
        public bool rotateEnabled = false;

        public void Update() {
            float d = Time.deltaTime;
            if(rotateEnabled) {
                gameObj.transform.Rotate(angleX * d, angleY * d, angleZ * d);
            }
        }

        public override void Interact() {
            rotateEnabled = !rotateEnabled;
        }
    }
}

