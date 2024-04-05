using TMPro;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace nyx.obj {
    public class move : UdonSharpBehaviour {
                // public Slider m_SliderX, m_SliderY, m_SliderZ;
        // public TextMeshProUGUI m_TextX, m_TextY, m_TextZ;

        void Start() {
            // m_SliderX.maxValue = 180f;
            // m_SliderX.minValue = -180f;
            // m_SliderY.maxValue = 180f;
            // m_SliderY.minValue = -180f;
            // m_SliderZ.maxValue = 180f;
            // m_SliderZ.minValue = -180f;
            // m_SliderX.SetValueWithoutNotify(transform.rotation.x);
            // m_SliderY.SetValueWithoutNotify(transform.rotation.y);
            // m_SliderZ.SetValueWithoutNotify(transform.rotation.z);
        }

        public void _SetPosition() {
            // transform.rotation = Quaternion.Euler(m_X, m_Y, m_Z);
        }

        private void Update() {
            // m_X = m_SliderX.value;
            // m_Y = m_SliderY.value;
            // m_Z = m_SliderZ.value;
            // m_TextX.text = " X : " + m_X;
            // m_TextY.text = " Y : " + m_Y;
            // m_TextZ.text = " Z : " + m_Z;
            _SetPosition();
        }
    }
}
