using System;
 
delegate void MyDelegate(String message);
 
class App{
   public static void Main(){
      MyDelegate call = new MyDelegate(FirstMethod);
      call += new MyDelegate(SecondMethod);
 
      call("Message A");
      call("Message B");
      call("Message C");
   }
 
   static void FirstMethod(String str){
      Console.WriteLine("1st method: "+str);
   }
 
   static void SecondMethod(String str){
      Console.WriteLine("2nd method: "+str);
   }
}