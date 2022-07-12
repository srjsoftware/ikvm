package ikvm.nio.ch;

import java.io.*;
import java.net.*;
import java.nio.*;
import java.nio.channels.*;
import java.nio.channels.spi.*;

/**
 * .NET implementation of SocketChannel.
 */
final class NetSocketChannel extends SocketChannel
{

    NetSocketChannel(SelectorProvider provider)
    {
        super(provider);
    }

    @Override
    public final native SocketChannel bind(SocketAddress local) throws IOException;

    @Override
    public final native <T> SocketChannel setOption(SocketOption<T> name, T value) throws IOException;

    @Override
    public final native Socket socket();

    @Override
    public final native boolean connect() throws IOException;

    @Override
    public final native boolean isConnected();

    @Override
    public final native boolean isConnectionPending();

    @Override
    public final native boolean finishConnect() throws IOException;

    @Override
    public final native SocketAddress getRemoteAddress() throws IOException;

    @Override
    public final native SocketAddress getLocalAddress() throws IOException;

    @Override
    public final native int read(ByteBuffer dst) throws IOException;

    @Override
    public final native long read(ByteBuffer[] dsts, int offset, int length) throws IOException;

    @Override
    public final native int write(ByteBuffer src) throws IOException;

    @Override
    public final native long write(ByteBuffer[] srcs, int offset, int length) throws IOException;

    @Override
    public final native SocketChannel shutdownInput() throws IOException;

    @Override
    public final native SocketChannel shutdownOutput() throws IOException;

}
