package sun.nio.ch;

import java.lang.AssertionError;
import java.lang.IllegalAccessException;
import java.lang.InstantiationException;
import java.nio.file.spi.FileTypeDetector;

/**
 * Creates this platform's default file type detector.
 */
final class DefaultFileTypeDetector
{

    @SuppressWarnings("unchecked")
    private final static FileTypeDetector createDetector(String cn)
    {

        Class<FileTypeDetector> c;

        try
        {
            c = (Class<FileTypeDetector>)Class.forName(cn);
        }
        catch (ClassNotFoundException e)
        {
            throw new AssertionError(e);
        }

        try
        {
            return c.newInstance();
        }
        catch (IllegalAccessException | InstantiationException e)
        {
            throw new AssertionError(e);
        }
    }

    public final static FileTypeDetector create()
    {
        return createDetector("ikvm.nio.fs.NetFileTypeDetector");
    }

}
