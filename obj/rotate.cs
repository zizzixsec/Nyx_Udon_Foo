
using UdonSharp;
using UnityEngine;
using UnityEngine.UIElements;
// using VRC.SDKBase;
// using VRC.Udon;

namespace nyx.obj {
    public class rotate : UdonSharpBehaviour {

        public GameObject gameObj;
        private bool spin = false;

        public void Update() {
            float rotAngle = 90f * Time.deltaTime;
            float noRotAngle = 0f;
            if(spin) {
                gameObj.transform.Rotate(rotAngle, rotAngle, noRotAngle);
            }
        }

        public override void Interact() {
            spin = !spin;
        }
    }
}

