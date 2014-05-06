//FadeIn Script for Unity - Zerofractal 2006 
var buttonName="Up";
var fadeDuration:float=0.5;
var initialDelay:float=5;
private var timeLeft:float=0.5;
 
function Awake () {
   timeLeft = fadeDuration;
}
 
function Update () {
   if (initialDelay > 0){
      initialDelay = initialDelay-Time.deltaTime;
   } else {
      if (Input.GetButton (buttonName))
         fade(true);   
      else
         fade(false);
   }
}
 
function fade(direction:boolean){
   var alpha;
   if (direction){
      if (guiElement.color.a < 0.5){
         timeLeft = timeLeft - Time.deltaTime;
         alpha = (timeLeft/fadeDuration);
         guiElement.color.a=0.5-(alpha/2);
      } else {
         timeLeft = fadeDuration;
      }
   } else {
      if (guiElement.color.a > 0){
         timeLeft = timeLeft - Time.deltaTime;
         alpha = (timeLeft/fadeDuration);
         guiElement.color.a=alpha/2;
      } else {
         timeLeft = fadeDuration;
      }
   }
}