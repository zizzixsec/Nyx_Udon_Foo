using AudioLink;
using TMPro;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace nyx.obj {
    public class rotate : UdonSharpBehaviour {

        public GameObject[] m_OBJS;
        public Slider m_SliderX, m_SliderY, m_SliderZ, m_SliderSpeed;
        public TextMeshProUGUI m_TextX, m_TextY, m_TextZ, m_TextSpeed;
        public Toggle m_ToggleSpin;

        private float m_X, m_Y, m_Z, m_Speed = 0f;
        void Start() {
            m_SliderX.maxValue = 180f;
            m_SliderX.minValue = -180f;
            m_SliderY.maxValue = 180f;
            m_SliderY.minValue = -180f;
            m_SliderZ.maxValue = 180f;
            m_SliderZ.minValue = -180f;
            m_SliderSpeed.maxValue = 1f;
            m_SliderSpeed.minValue = 0f;
            m_ToggleSpin.isOn = false;
            
            foreach(GameObject obj in m_OBJS) {
                m_SliderX.SetValueWithoutNotify(obj.transform.rotation.x);
                m_SliderY.SetValueWithoutNotify(obj.transform.rotation.y);
                m_SliderZ.SetValueWithoutNotify(obj.transform.rotation.z);
                m_SliderSpeed.SetValueWithoutNotify(m_Speed);
            }
        }

        public void _SetRotation(GameObject obj) {
            if(!m_ToggleSpin.isOn)
                obj.transform.rotation = Quaternion.Euler(m_X, m_Y, m_Z);
            else
                obj.transform.Rotate(m_X * m_Speed, m_Y * m_Speed, m_Z * m_Speed);
        }

        private void Update() {
            m_X = m_SliderX.value;
            m_Y = m_SliderY.value;
            m_Z = m_SliderZ.value;
            m_Speed = m_SliderSpeed.value;
            m_TextX.text = " X : " + m_X;
            m_TextY.text = " Y : " + m_Y;
            m_TextZ.text = " Z : " + m_Z;
            m_TextSpeed.text = " Speed : " + m_Speed;
            foreach(GameObject obj in m_OBJS)
                _SetRotation(obj);
        }
    }
}

