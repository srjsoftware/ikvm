package sun.nio.ch;

import java.lang.AssertionError;
import java.lang.IllegalAccessException;
import java.lang.InstantiationException;
import java.nio.channels.spi.SelectorProvider;

/**
 * Creates this platform's default selector provider.
 */
public final class DefaultSelectorProvider
{

    @SuppressWarnings("unchecked")
    private final static SelectorProvider createProvider(String cn)
    {

        Class<SelectorProvider> c;

        try
        {
            c = (Class<SelectorProvider>)Class.forName(cn);
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

    public final static SelectorProvider create()
    {
        return createProvider("ikvm.nio.ch.SelectorProvider");
    }

}
