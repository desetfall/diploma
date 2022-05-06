using UnityEngine;

namespace Logon
{
    public class LogonWindowsManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] logonWindowsPrefabs;
    
        private Canvas[] _logonWindowsCanvas;
    
        private Canvas _canvas;
        private void Start()
        {
            _canvas = GetComponent<Canvas>();
            _logonWindowsCanvas = new Canvas[logonWindowsPrefabs.Length];
            for (int i = 0; i < logonWindowsPrefabs.Length; i++)
            {
                _logonWindowsCanvas[i] = Instantiate(logonWindowsPrefabs[i], transform.parent).GetComponent<Canvas>();
                _logonWindowsCanvas[i].enabled = false;
            }
        }

        public void OpenWindow(int index)
        {
            _canvas.enabled = false;
            _logonWindowsCanvas[index].enabled = true;
            _logonWindowsCanvas[index].gameObject.SendMessage("SetParentCanvas", _canvas);
        }

        public void Exit()
        {
            Debug.Log("Exit game...");
            Application.Quit();
        }
    }
}
