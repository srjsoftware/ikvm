package sun.nio.ch;

import java.lang.AssertionError;
import java.lang.IllegalAccessException;
import java.lang.InstantiationException;
import java.nio.channels.spi.AsynchronousChannelProvider;

/**
 * Creates this platform's default asynchronous channel provider.
 */
public final class DefaultAsynchronousChannelProvider
{

    @SuppressWarnings("unchecked")
    private final static AsynchronousChannelProvider createProvider(String cn)
    {

        Class<AsynchronousChannelProvider> c;

        try
        {
            c = (Class<AsynchronousChannelProvider>)Class.forName(cn);
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

    public final static AsynchronousChannelProvider create()
    {
        return createProvider("ikvm.nio.ch.NetAsynchronousChannelProvider");
    }

}
