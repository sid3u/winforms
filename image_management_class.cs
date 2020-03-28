using System.IO;
using System.Windows.Media.Imaging;
using System.Web;


public class image_managment_class
{
    // Generic File Stream Object
    protected FileStream _fileStream(string s)
    {
        FileStream fs = new FileStream(s, FileMode.Open, FileAccess.Read, FileShare.Read);
        return fs;
    }
    // Generic BitmapSource Object
    protected BitmapSource _bitmapSource(string s)
    {
        BitmapSource bs = BitmapFrame.Create(_fileStream(s));
        return bs;
    }
    // BitmapMetadata Object
    public BitmapMetadata _returnBitmapMetaData(string s)
    {
        // s = file virtual path
        BitmapMetadata md = (BitmapMetadata)_bitmapSource(s).Metadata;
        return md;
    }


}