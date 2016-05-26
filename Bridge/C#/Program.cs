using System;

namespace Bridge
{
    public interface IImageResolution
    {
        void DrawResolution(Image img);
    }

    class A2Image : IImageResolution
    {

        public void DrawResolution(Image img)
        {
            string imgFormat = img.GetImageExtension();
            Console.WriteLine( imgFormat+" in A2 format has been drawn.");
        }
    }

    class A4Image : IImageResolution
    {
        public void DrawResolution(Image img)
        {
            string imgFormat = img.GetImageExtension();
            Console.WriteLine(imgFormat + " in A4 format has been drawn.");
        }
    }

    public abstract class Image
    {
        protected IImageResolution imgResolution;
        public Image(IImageResolution image)
        {
            this.imgResolution = image;
        }

        public abstract void Draw();
        public abstract string GetImageExtension();
    }

    public class JpgImage : Image
    {
        public JpgImage(IImageResolution imgResolution) : base(imgResolution) { }

        public override void Draw()
        {
            base.imgResolution.DrawResolution(this);
        }

        public override string GetImageExtension()
        {
            return "JPG";
        }
    }

    class Bridge
    {
        static void Main(string[] args)
        {
            Image imgA2 = new JpgImage(new A2Image());
            Image imgA4 = new JpgImage(new A4Image());

            imgA2.Draw();
            imgA4.Draw();

            Console.ReadKey();
        }
    }
}
