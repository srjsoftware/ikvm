package ikvm.nio.ch;

import java.io.*;
import java.net.*;
import java.nio.*;
import java.nio.channels.*;
import java.nio.channels.spi.*;

/**
 * .NET implementation of DatagramChannel.
 */
final class NetDatagramChannel extends DatagramChannel
{

    NetDatagramChannel(SelectorProvider provider)
    {
        super(provider);
    }

    NetDatagramChannel(SelectorProvider provider, ProtocolFamily family)
    {
        super(provider);
    }

    @Override
    public final native DatagramChannel bind(SocketAddress local) throws IOException;

    @Override
    public final native DatagramSocket socket();

    @Override
    public final native DatagramChannel connect() throws IOException;

    @Override
    public final native boolean isConnected();

    @Override
    public final native SocketAddress getRemoteAddress() throws IOException;

    @Override
    public final native SocketAddress getLocalAddress() throws IOException;

    @Override
    public final native DatagramChannel disconnect() throws IOException;

    @Override
    public final native SocketAddress receive(ByteBuffer dst) throws IOException;

    @Override
    public final native int send(ByteBuffer src, SocketAddress target) throws IOException;

    @Override
    public final native int read(ByteBuffer dst) throws IOException;

    @Override
    public final native long read(ByteBuffer[] dsts, int offset, int length) throws IOException;

    @Override
    public final native int write(ByteBuffer src) throws IOException;

    @Override
    public final native long write(ByteBuffer[] srcs, int offset, int length) throws IOException;

}
