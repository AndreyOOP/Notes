using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RihterEvent
{
    [TestClass]
    public class Event
    {
        [TestMethod]
        public void TestMethod1()
        {
            //check console output
            MailManager mailManager = new MailManager();
            FaxReceiver faxReceiver = new FaxReceiver(mailManager);
            PcReceiver  pcReceiver  = new PcReceiver(mailManager);

            mailManager.ReceiveEmail("Boss", "Me");

            mailManager.ReceiveEmail("HR", "CEO");
        }
    }

    //Step 1
    public class MailEventArgs : EventArgs
    {
        public String From { get; }
        public String To { get; }

        public MailEventArgs(String From, String To)
        {
            this.From = From;
            this.To = To;
        }
    }

    public class MailManager
    {
        //Step 2:
        //delegate looks like below, it have to be: return type - void, sender is Object, event args is e
        //public delegate void EventHandler<TEventArgs>(Object sender, TEventArgs e);
        public event EventHandler<MailEventArgs> NewMail;

        //Step 3:
        //Method Responsible for Raising Event (Notify registered objects that event occurred)
        //by convention protected virtual void (so inheritance is possible, if class is sealed - private, nonvirtual)
        protected virtual void OnNewMail(MailEventArgs e)
        {
            //variant 1
            //not thread safe
            //if (NewMail != null) NewMail(this, e);

            //variant 2
            //Thread safe in theory but compiler could optimize it
            //EventHandler<MailEventArgs> TempNewMail = NewMail;
            //if (TempNewMail != null) TempNewMail(this, e);

            //variant 3
            //according to Rihter
            //EventHandler<MailEventArgs> TempNewMail = Volatile.Read(ref NewMail);
            //if (TempNewMail != null) TempNewMail(this, e);

            //variant 4
            //according to C#6.0 - it is thread safe
            NewMail?.Invoke(this, e);
        }

        //Step 4:
        //Method that translates the input into the desired event
        public void ReceiveEmail(String From, String To)
        {
            MailEventArgs e = new MailEventArgs(From, To);

            OnNewMail(e);
        }
    }

    //Step 5:
    //create event listeners types
    //listener type 1
    public class FaxReceiver
    {
        public FaxReceiver(MailManager mm)
        {
            //register interest in event
            mm.NewMail += FaxMsg;
        }

        private void FaxMsg(Object sender, MailEventArgs e)
        {
            //'sender' identifies the MailManager object in case we want communicate back to it

            Console.WriteLine("FAX received message from {0}, to {1}", e.From, e.To);
        }

        //to unsubscribe from event
        public void Unregister(MailManager mm)
        {
            mm.NewMail -= FaxMsg;
        }
    }

    //listener type 2
    public class PcReceiver
    {
        public PcReceiver(MailManager mm)
        {
            mm.NewMail += PcMsg;
        }

        private void PcMsg(object sender, MailEventArgs e)
        {
            Console.WriteLine("PC received message from {0}, to {1}", e.From, e.To);
        }
    }
}
