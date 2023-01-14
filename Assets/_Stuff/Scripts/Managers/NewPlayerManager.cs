using System;
using _Stuff.Scripts.Objects;
using UnityEngine;
using UnityEngine.UI;

namespace _Stuff.Scripts.Managers
{
    public class NewPlayerManager : MonoBehaviour
    {
        private string[] textToDisplay;
        [SerializeField] private Text textField;
        [SerializeField] private Button btnNextButton;
        private int progress = 0;

        private void Awake()
        {
            btnNextButton.onClick.AddListener(OnClickNextText);
            textToDisplay = new string[]
            {
                "Welcome to Toad King!",
                "In this game, you can take care of toad, raise and fuse new special toad",
                "Did you know: Toad is the icon for FPT University!",
                "I'm Toad Guide! I will give you an egg, this is your first toad friend.",
                "Also, I will give you 500 TKT, this is our token currency",
                "You can use this to buy new friends in the market",
                "Read the guide and start your journey!"
            };
            
        }
        


        private void OnClickNextText()
        {
            if (progress >= textToDisplay.Length-1)
            {
                // Open Guide .setActive(true)
                TotalManager.Instance.uiManager.uiWaitingForData.SetActive(true);
                TotalManager.Instance.initialFetcherManager.toadListFetcher.GetAllToad();
               
                this.gameObject.SetActive(false);
            }
            else if (progress == 3)
            {
                TotalManager.Instance.dynamicFetcherManager.toadGenerationFetcher.RequestACommonToad();
                progress++; 
                textField.text = textToDisplay[progress];
            }
            else if (progress == 4)
            {

                TotalManager.Instance.dynamicFetcherManager.tokenFetcher.RequestNewPlayerMoney();
                progress++; 
                textField.text = textToDisplay[progress];
            }
            else
            {
                progress++; 
                textField.text = textToDisplay[progress];
            }
        }

        private void Start()
        {
            if (true)
            {
                textField.text = textToDisplay[progress];
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }


        public bool CheckIfThisIsNewPlayer()
        {
            if (TotalManager.Instance.dataManager.tokenBalance == 0
                && TotalManager.Instance.dataManager.listData.Count == 0)
            {
                return true;
            }

            return false;
        }
    }
}