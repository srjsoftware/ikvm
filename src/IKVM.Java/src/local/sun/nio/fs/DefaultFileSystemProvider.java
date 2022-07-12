package sun.nio.ch;

import java.lang.AssertionError;
import java.lang.IllegalAccessException;
import java.lang.InstantiationException;
import java.nio.file.spi.FileSystemProvider;

/**
 * Creates this platform's default file system provider.
 */
final class DefaultFileSystemProvider
{

    @SuppressWarnings("unchecked")
    private final static FileSystemProvider createProvider(String cn)
    {

        Class<FileSystemProvider> c;

        try
        {
            c = (Class<FileSystemProvider>)Class.forName(cn);
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

    public final static FileSystemProvider create()
    {
        return createProvider("ikvm.nio.fs.NetFileSystemProvider");
    }

}
