#pragma strict

var CPselGridInt : int = -1;
var CPselStrings : String[] = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14"];

	
	function OnGUI ()
	{
		CPselGridInt = GUI.SelectionGrid (Rect (Screen.width /2 *0.25, Screen.height * 0.92, Screen.width /2 *1.5, Screen.height /16 *1), CPselGridInt, CPselStrings, 14);
			
		 if (CPselGridInt == 0){
             Application.LoadLevel("MobileScene1");
         }
         
         if (CPselGridInt == 1){
             Application.LoadLevel("MobileScene2");
         }
         
         if (CPselGridInt == 2){
             Application.LoadLevel("MobileScene3");
         }
         
         if (CPselGridInt == 3){
             Application.LoadLevel("MobileScene4");
         }
         
         if (CPselGridInt == 4){
             Application.LoadLevel("MobileScene5");
         }
         
         if (CPselGridInt == 5){
             Application.LoadLevel("MobileScene6");
         }
         
         if (CPselGridInt == 6){
             Application.LoadLevel("MobileScene7");
         }
         
         if (CPselGridInt == 7){
             Application.LoadLevel("MobileScene8");
         }
         
         if (CPselGridInt == 8){
             Application.LoadLevel("MobileScene9");
         }
         
 		 if (CPselGridInt == 9){
             Application.LoadLevel("MobileScene10");
         }
         
         if (CPselGridInt == 10){
             Application.LoadLevel("MobileScene11");
         }
         
         if (CPselGridInt == 11){
             Application.LoadLevel("MobileScene12");
         }
         
         if (CPselGridInt == 12){
             Application.LoadLevel("MobileScene13");
         }
             
         if (CPselGridInt == 13){
             Application.LoadLevel("MobileScene14");
         }
	}