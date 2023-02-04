using System.Drawing;
using System.Drawing.Imaging;

namespace GuildManager_Utils
{
    public class ImageConverter
    {
        public static string GetMimeTypeFromByteArray(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                Image image = Image.FromStream(ms);
                ImageFormat format = image.RawFormat;
                string mimeType = format.ToString();
                return mimeType;
            }
        }
    }
}
