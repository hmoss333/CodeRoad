#pragma strict
#pragma downcast

var sceneCamera : Camera;

private var currentAnimation : String;

var lion : GameObject;
var giraffe : GameObject;
var elephant : GameObject;
var crocodile : GameObject;

var idleButton : Transform;
var talkButton : Transform;
var rollingButton : Transform;
var successButton : Transform;
var jumpButton : Transform;
var idle2Button : Transform;
var runButton : Transform;
var failureButton : Transform;
var sleepButton : Transform;
var walkButton : Transform;

var selectedButton : Transform;
private var selectedButtonScript : SelectedButton;

function Start () {
	lion.GetComponent.<Animation>().Play("Walk Lion");
	giraffe.GetComponent.<Animation>().Play("Walk Giraffe");
	elephant.GetComponent.<Animation>().Play("Walk Elephant");
	crocodile.GetComponent.<Animation>().Play("Walk Crocodile");

	selectedButtonScript = selectedButton.GetComponent(SelectedButton);
}

function Update () {
	if(Input.GetMouseButtonDown(0)){
		var ray = sceneCamera.ScreenPointToRay(Input.mousePosition);
		var hit : RaycastHit;
		if(Physics.Raycast(ray, hit)){;
			switch(hit.transform){
				case idleButton:
					if(currentAnimation != "Idle"){
						BlendAllCharactersToZero();
						selectedButtonScript.SetAnimationStart(Time.time);
						lion.GetComponent.<Animation>().Blend("Idle Lion");
						giraffe.GetComponent.<Animation>().Blend("Idle Giraffe");
						elephant.GetComponent.<Animation>().Blend("Idle Elephant");
						crocodile.GetComponent.<Animation>().Blend("Idle Crocodile");
						selectedButton.position = idleButton.position;
						currentAnimation = "Idle";
					}
					break;
				case talkButton:
					if(currentAnimation != "Talk"){
						BlendAllCharactersToZero();
						selectedButtonScript.SetAnimationStart(Time.time);
						lion.GetComponent.<Animation>().Blend("Talk Lion");
						giraffe.GetComponent.<Animation>().Blend("Talk Giraffe");
						elephant.GetComponent.<Animation>().Blend("Talk Elephant");
						crocodile.GetComponent.<Animation>().Blend("Talk Crocodile");
						selectedButton.position = talkButton.position;
						currentAnimation = "Talk";
					}
					break;
				case rollingButton:
					if(currentAnimation != "Rolling"){
						BlendAllCharactersToZero();
						selectedButtonScript.SetAnimationStart(Time.time);
						lion.GetComponent.<Animation>().Blend("Rolling Lion");
						giraffe.GetComponent.<Animation>().Blend("Rolling Giraffe");
						elephant.GetComponent.<Animation>().Blend("Rolling Elephant");
						crocodile.GetComponent.<Animation>().Blend("Rolling Crocodile");
						selectedButton.position = rollingButton.position;
						currentAnimation = "Rolling";
					}
					break;
				case successButton:
					if(currentAnimation != "Success"){
						BlendAllCharactersToZero();
						selectedButtonScript.SetAnimationStart(Time.time);
						lion.GetComponent.<Animation>().Blend("Success Lion");
						giraffe.GetComponent.<Animation>().Blend("Success Giraffe");
						elephant.GetComponent.<Animation>().Blend("Success Elephant");
						crocodile.GetComponent.<Animation>().Blend("Success Crocodile");
						selectedButton.position = successButton.position;
						currentAnimation = "Success";
					}
					break;
				case jumpButton:
					if(currentAnimation != "Jump"){
						BlendAllCharactersToZero();
						selectedButtonScript.SetAnimationStart(Time.time);
						lion.GetComponent(JumpTest).enabled = true;
						giraffe.GetComponent(JumpTest).enabled = true;
						elephant.GetComponent(JumpTest).enabled = true;
						crocodile.GetComponent(JumpTest).enabled = true;
						selectedButton.position = jumpButton.position;
						currentAnimation = "Jump";
					}
					break;
				case idle2Button:
					if(currentAnimation != "Idle 2"){
						BlendAllCharactersToZero();
						selectedButtonScript.SetAnimationStart(Time.time);
						lion.GetComponent.<Animation>().Blend("Idle 2 Lion");
						giraffe.GetComponent.<Animation>().Blend("Idle 2 Giraffe");
						elephant.GetComponent.<Animation>().Blend("Idle 2 Elephant");
						crocodile.GetComponent.<Animation>().Blend("Idle 2 Crocodile");
						selectedButton.position = idle2Button.position;
						currentAnimation = "Idle 2";
					}
					break;
				case runButton:
					if(currentAnimation != "Run"){
						BlendAllCharactersToZero();
						selectedButtonScript.SetAnimationStart(Time.time);
						lion.GetComponent.<Animation>().Blend("Run Lion");
						giraffe.GetComponent.<Animation>().Blend("Run Giraffe");
						elephant.GetComponent.<Animation>().Blend("Run Elephant");
						crocodile.GetComponent.<Animation>().Blend("Run Crocodile");
						selectedButton.position = runButton.position;
						currentAnimation = "Run";
					}
					break;
				case failureButton:
					if(currentAnimation != "Failure"){
						BlendAllCharactersToZero();
						selectedButtonScript.SetAnimationStart(Time.time);
						lion.GetComponent.<Animation>().Blend("Failure Lion");
						giraffe.GetComponent.<Animation>().Blend("Failure Giraffe");
						elephant.GetComponent.<Animation>().Blend("Failure Elephant");
						crocodile.GetComponent.<Animation>().Blend("Failure Crocodile");
						selectedButton.position = failureButton.position;
						currentAnimation = "Failure";
					}
					break;
				case sleepButton:
					if(currentAnimation != "Sleep"){
						BlendAllCharactersToZero();
						selectedButtonScript.SetAnimationStart(Time.time);
						lion.GetComponent.<Animation>().Blend("Sleep Lion");
						giraffe.GetComponent.<Animation>().Blend("Sleep Giraffe");
						elephant.GetComponent.<Animation>().Blend("Sleep Elephant");
						crocodile.GetComponent.<Animation>().Blend("Sleep Crocodile");
						selectedButton.position = sleepButton.position;
						currentAnimation = "Sleep";
					}
					break;
				case walkButton:
					if(currentAnimation != "Walk"){
						BlendAllCharactersToZero();
						selectedButtonScript.SetAnimationStart(Time.time);
						lion.GetComponent.<Animation>().Blend("Walk Lion");
						giraffe.GetComponent.<Animation>().Blend("Walk Giraffe");
						elephant.GetComponent.<Animation>().Blend("Walk Elephant");
						crocodile.GetComponent.<Animation>().Blend("Walk Crocodile");
						selectedButton.position = walkButton.position;
						currentAnimation = "Walk";
					}
					break;
			}
		}
	}
}

function BlendAllCharactersToZero(){
	BlendAllToZero(lion);
	BlendAllToZero(giraffe);
	BlendAllToZero(elephant);
	BlendAllToZero(crocodile);

	lion.GetComponent(JumpTest).enabled = false;
	giraffe.GetComponent(JumpTest).enabled = false;
	elephant.GetComponent(JumpTest).enabled = false;
	crocodile.GetComponent(JumpTest).enabled = false;
}

function BlendAllToZero(character : GameObject){
	var animation = character.GetComponent.<Animation>();
	for(var state : AnimationState in animation){
		animation.Blend(state.name, 0);
	}
}