using System;

namespace Factory
{
    public enum OSTypeEnum
    {
        OS1 = 1,
        OS2,
        OS3
    }

    public interface IWindow
    {
        void WindowRender();
    }

    public class OS1Window : IWindow
    {
        public void WindowRender()
        {
            Console.WriteLine("OS1 - WINDOW RENDER");
        }
    }

    public class OS2Window : IWindow
    {
        public void WindowRender()
        {
            Console.WriteLine("OS2 - WINDOW RENDER");
        }
    }

    public class OS3Window : IWindow
    {
        public void WindowRender()
        {
            Console.WriteLine("OS3 - WINDOW RENDER");
        }
    }


    public class WindowFactory
    {
        public WindowFactory(){}
        public IWindow GetWindow(OSTypeEnum osType)
        {
            switch (osType)
            {
                case OSTypeEnum.OS1:
                    return new OS1Window();
                case OSTypeEnum.OS2:
                    return new OS2Window();
                case OSTypeEnum.OS3:
                    return new OS3Window();
                default:
                    return null;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            WindowFactory windowFactory = new WindowFactory();
            windowFactory.GetWindow(OSTypeEnum.OS1).WindowRender();
            windowFactory.GetWindow(OSTypeEnum.OS2).WindowRender();
            windowFactory.GetWindow(OSTypeEnum.OS3).WindowRender();
            Console.ReadKey();
        }
    }
}
