
using UdonSharp;
using UnityEngine;
using UnityEngine.UIElements;
// using VRC.SDKBase;
// using VRC.Udon;

namespace nyx.obj {
    public class rotate : UdonSharpBehaviour {

        public GameObject gameObj;
        public float angleX,angleY,angleZ;
        private bool rotateEnabled = false;

        private void Start() {
            float currentDelta = Time.deltaTime;
            angleX *= currentDelta;
            angleX *= currentDelta;
            angleX *= currentDelta;
        }

        public void Update() {
            if(rotateEnabled) {
                gameObj.transform.Rotate(angleX, angleY, angleZ);
            }
        }

        public override void Interact() {
            rotateEnabled = !rotateEnabled;
        }
    }
}

