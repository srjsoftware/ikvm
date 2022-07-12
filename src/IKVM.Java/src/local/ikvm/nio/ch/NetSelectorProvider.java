package ikvm.nio.ch;

import java.io.*;
import java.net.*;
import java.nio.channels.*;
import java.nio.channels.spi.*;

/**
 * .NET implementation of SelectorProvider.
 */
final class NetSelectorProvider extends SelectorProvider
{

    @Override
    public final AbstractSelector openSelector() throws IOException
    {
        return new NetSelector(this);
    }

    @Override
    public final DatagramChannel openDatagramChannel() throws IOException
    {
        return new NetDatagramChannel(this);
    }

    @Override
    public final DatagramChannel openDatagramChannel(ProtocolFamily family) throws IOException
    {
        return new NetDatagramChannel(this, family);
    }

    @Override
    public final Pipe openPipe() throws IOException
    {
        return new NetPipe(this);
    }

    @Override
    public final ServerSocketChannel openServerSocketChannel() throws IOException
    {
        return new NetServerSocketChannel(this);
    }

    @Override
    public final SocketChannel openSocketChannel() throws IOException
    {
        return new NetSocketChannel(this);
    }

}
