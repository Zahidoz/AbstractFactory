using System;

namespace Abstract_Factory
{
    class Program
    {
        public interface ICheckbox
        {
            void Paint();
        }
        public interface IButton
        {
            void Paint();
        }
        public interface IGuiFactory
        {
            IButton CreateButton();
            ICheckbox CreateCheckbox();
        }


        public class MacButton : IButton
        {
            public void Paint()
            {
                Console.WriteLine("MacBtn Created");
            }
        }
        public class MacCheckbox : ICheckbox
        {
            public void Paint()
            {
                Console.WriteLine("MacCheckbox Created");

            }
        }
        public class MacFactory : IGuiFactory
        {
            public IButton CreateButton() => new MacButton();
            

            public ICheckbox CreateCheckbox() => new MacCheckbox();
        }

        public class WinButton : IButton
        {
            public void Paint()
            {
                Console.WriteLine("WindowsBtn Created");
            }
        }
        public class WinCheckbox : ICheckbox
        {
            public void Paint()
            {
                Console.WriteLine("WindowsCheckbox Created");

            }
        }
        public class WinFactory : IGuiFactory
        {
            public IButton CreateButton() => new WinButton();
            

            public ICheckbox CreateCheckbox() => new WinCheckbox();
        }


        public class Applicaion
        {
            private IButton _button;
            private ICheckbox _checkbox;
            private readonly IGuiFactory _guiFactory;

            public Applicaion(IGuiFactory guiFactory)
            {
                _guiFactory = guiFactory;
            }

            public void CreateUI()
            {
                _button = _guiFactory.CreateButton();
                _checkbox = _guiFactory.CreateCheckbox();
            }

            public void Print()
            {
                _button.Paint();
                _checkbox.Paint();
            }

                 
        }
      


        public static void Main(string[] args)
        {


            
            Applicaion winApp = new Applicaion(new WinFactory());
            winApp.CreateUI();
            winApp.Print();
             
            
            Applicaion macApp = new Applicaion(new MacFactory());
            macApp.CreateUI();
            macApp.Print();

         }
    }
}
