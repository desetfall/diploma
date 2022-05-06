using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace Logon.Authorization
{
    public class Authorization : MonoBehaviour
    {
        private Canvas _parentCanvas;
        
        [SerializeField]
        private TMP_InputField tmpEmail;
        
        [SerializeField]
        private TMP_InputField tmpLogin;
        
        [SerializeField]
        private TMP_InputField tmpPass;
        
        [SerializeField]
        private TMP_Text tmpLabel;

        private const string AUT_FAIL = "Ошибка авторизации, проверьте введённые данные...";
        private const string PASS_SENDED = "Пароль выслан на почту";
        private const string INVALID_EMAIL = "Проверьте введённую почту";

        public void SetParentCanvas(Canvas canvas)
        {
            _parentCanvas = canvas;
        }
        
        public void CloseWindow()
        {
            ClearEverything();
            _parentCanvas.enabled = true;
        }
        
        private void ClearEverything()
        {
            tmpLabel.text = string.Empty;
            tmpEmail.text = string.Empty;
            tmpLogin.text = string.Empty;
            tmpPass.text = string.Empty;
        }

        public void TryAuthorization()
        {
            if (tmpLogin.text != string.Empty && tmpPass.text != string.Empty)
            {
                TryValidateLogPass();
            }
            else
            {
                AuthorizationStatusChanged(AUT_FAIL);
            }
        }
        
        private void AuthorizationStatusChanged(string msg)
        {
            tmpPass.text = string.Empty;
            tmpLabel.text = msg;
        }

        private void TryValidateLogPass()
        {
            if (true) //TODO: Проверка логина и пароля в бд
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                AuthorizationStatusChanged(AUT_FAIL);
            }
        }

        public void ForgotPass() //TODO: реализовать высылку пароля с БД на почту
        {
            if (tmpEmail.text != string.Empty)
            {
                AuthorizationStatusChanged(PASS_SENDED);
            }
            else
            {
                tmpLabel.text = INVALID_EMAIL;
            }

        }
        
    }
}
