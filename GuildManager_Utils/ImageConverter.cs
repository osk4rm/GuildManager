namespace GuildManager_Utils
{
    public class ImageConverter
    {
        private static readonly Dictionary<string, string> MimeTypes = new Dictionary<string, string>
        {
            { "FFD8FF", "image/jpeg" },
            { "89504E47", "image/png" },
            { "47494638", "image/gif" },
            { "49492A00", "image/tiff" },
            { "424D", "image/bmp" }
        };

        public static string GetMimeType(byte[] byteArray)
        {
            string magicNumber = string.Empty;

            // JPEG
            if (byteArray[0] == 0xFF && byteArray[1] == 0xD8 && byteArray[2] == 0xFF)
            {
                magicNumber = "FFD8FF";
            }
            // PNG
            else if (byteArray[0] == 0x89 && byteArray[1] == 0x50 && byteArray[2] == 0x4E && byteArray[3] == 0x47)
            {
                magicNumber = "89504E47";
            }
            // GIF
            else if (byteArray[0] == 0x47 && byteArray[1] == 0x49 && byteArray[2] == 0x46 && byteArray[3] == 0x38)
            {
                magicNumber = "47494638";
            }
            // TIFF
            else if (byteArray[0] == 0x49 && byteArray[1] == 0x49 && byteArray[2] == 0x2A && byteArray[3] == 0x00)
            {
                magicNumber = "49492A00";
            }
            // BMP
            else if (byteArray[0] == 0x42 && byteArray[1] == 0x4D)
            {
                magicNumber = "424D";
            }

            if (MimeTypes.TryGetValue(magicNumber, out string mimeType))
            {
                return mimeType;
            }
            return "application/octet-stream";
        }


    }
}
