using UnityEngine;
using TMPro;
using Projects.Scripts.Core;

namespace BenkiUI{
    public class UIManager : SingletonMonoBehaviour<UIManager>, IAltoManager
    {
        public TextMeshProUGUI textArea;
        // Start is called before the first frame update
        void Start()
        {
            textArea.text = "ドアに近づく．";
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        void IAltoManager.OnInitialize()
        {
            // throw new System.NotImplementedException();
        }
    }
}
