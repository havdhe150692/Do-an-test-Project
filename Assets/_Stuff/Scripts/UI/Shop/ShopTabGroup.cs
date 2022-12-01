using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTabGroup : MonoBehaviour
{
    public List<ShopTabButton> tabButton;

    public void Subscribe(ShopTabButton button)
    {
        if (tabButton != null)
        {
            tabButton = new List<ShopTabButton>();
        }
        
        tabButton.Add(button);
    }

    public void OnTabSelected(ShopTabButton tabButton)
    {
        
    }

    public void OnTabEnter(ShopTabButton tabButton)
    {
        ResetTabs();
    }

    public void OnTabExit(ShopTabButton tabButton)
    {
        
    }

    public void ResetTabs()
    {
        
    }
}
