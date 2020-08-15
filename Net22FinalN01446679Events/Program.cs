using System;

namespace Net22FinalN01446679Events
{

	/*
	Write classes for events, one class which exposes an event and another which handles the event.
	1)    Create a class to pass as an argument for the event handlers
	2)    Set up the delegate for the event
	3)    Declare the code for the event
	4)    Create code the will be run when the event occurs 
	5)    Associate the event with the event handler
	*/
    class Program
    {
		

		static void Main(string[] args)
        {

			AlertAdmin MyAlert = new AlertAdmin();
            GetUserInput GetUser = new GetUserInput();
            GetUser.MyEvent += MyAlert.MyEventListerner;
            GetUser.getInput();


        }
    }

	// event information (holds passed to listeners)
	public class PassEventAugument : EventArgs
	{
		public string passedargument { get; set; }
		public PassEventAugument(string PassedArgument)
		{
			passedargument = PassedArgument;
		}
	}

	public class GetUserInput
	{
		//public  delegate void mydelegate (object source, PassEventAugument e);
		//public  event mydelegate MyEvent;
		//	OR
		//public event EventHandler<PassEventAugument> MyEvent; 
		//OR
		public event Action<object, PassEventAugument> MyEvent;

		public void getInput()
		{
			Console.WriteLine("Enter string argument to pass to event:");
			string AurgentToPassToEvent = Console.ReadLine().ToString();
			PassEventAugument UserAugument = new PassEventAugument(AurgentToPassToEvent);
			MyEventCode(UserAugument);
		}

		protected void MyEventCode(PassEventAugument TheAugumentFromUser)
		{

				if (MyEvent != null)
				MyEvent(this, TheAugumentFromUser);
	
		}

	}


	class AlertAdmin //subscriber
	{
		public void MyEventListerner(object source, PassEventAugument e)

		{
			Console.WriteLine("{0} augument was passed", e.passedargument.ToUpper());
			Console.ReadLine();
		
		}

	}

	




}
