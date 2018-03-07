using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnhancedToggleGroup : ToggleGroup {

    public delegate void ChangedEventHandler(Toggle newActive);
 
    public event ChangedEventHandler OnChange;
    public void Start() {
        //Loop through the children of the gameobject this 
        //component is attached.
        foreach (Transform transformToggle in gameObject.transform)
        {
            var toggle = transformToggle.gameObject.GetComponent<Toggle>();
            if (toggle != null)
            {
                toggle.onValueChanged.AddListener((isSelected) =>
                {
                    if (!isSelected)
                    {
                        return;
                    }
                    var activeToggle = Active();
                    DoOnChange(activeToggle);
                });
            }
        }
     }

     public Toggle Active() {
         return ActiveToggles().FirstOrDefault();
     }
 
     protected virtual void DoOnChange(Toggle newactive)
     {
         var handler = OnChange;
         if (handler != null) handler(newactive);
     }
}
