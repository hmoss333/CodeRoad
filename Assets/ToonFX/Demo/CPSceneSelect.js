#pragma strict

var CPselGridInt : int = -1;
var CPselStrings : String[] = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14"];

	
	function OnGUI ()
	{
		CPselGridInt = GUI.SelectionGrid (Rect (Screen.width /2 *0.25, Screen.height * 0.92, Screen.width /2 *1.5, Screen.height /16 *1), CPselGridInt, CPselStrings, 14);
			
		 if (CPselGridInt == 0){
             Application.LoadLevel("Scene1");
         }
         
         if (CPselGridInt == 1){
             Application.LoadLevel("Scene2");
         }
         
         if (CPselGridInt == 2){
             Application.LoadLevel("Scene3");
         }
         
         if (CPselGridInt == 3){
             Application.LoadLevel("Scene4");
         }
         
         if (CPselGridInt == 4){
             Application.LoadLevel("Scene5");
         }
         
         if (CPselGridInt == 5){
             Application.LoadLevel("Scene6");
         }
         
         if (CPselGridInt == 6){
             Application.LoadLevel("Scene7");
         }
         
         if (CPselGridInt == 7){
             Application.LoadLevel("Scene8");
         }
         
         if (CPselGridInt == 8){
             Application.LoadLevel("Scene9");
         }
         
 		 if (CPselGridInt == 9){
             Application.LoadLevel("Scene10");
         }
         
         if (CPselGridInt == 10){
             Application.LoadLevel("Scene11");
         }
         
         if (CPselGridInt == 11){
             Application.LoadLevel("Scene12");
         }
         
         if (CPselGridInt == 12){
             Application.LoadLevel("Scene13");
         }
             
         if (CPselGridInt == 13){
             Application.LoadLevel("Scene14");
         }
	}