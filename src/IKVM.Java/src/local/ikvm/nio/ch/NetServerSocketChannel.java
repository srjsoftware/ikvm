package ikvm.nio.ch;

import java.io.*;
import java.net.*;
import java.nio.channels.*;
import java.nio.channels.spi.*;

/**
 * .NET implementation of ServerSocketChannel.
 */
final class NetServerSocketChannel extends ServerSocketChannel
{

    NetServerSocketChannel(SelectorProvider provider)
    {
        super(provider);
    }

    @Override
    public final native ServerSocketChannel bind(SocketAddress local, int backlog) throws IOException;

    @Override
    public final native <T> ServerSocketChannel setOption(SocketOption<T> name, T value) throws IOException;

    @Override
    public final native ServerSocket socket();

    @Override
    public final native ServerSocket accept() throws IOException;

    @Override
    public final native SocketAddress getLocalAddress() throws IOException;

}
