package ikvm.nio.ch;

import java.io.*;
import java.net.*;
import java.nio.*;
import java.nio.channels.*;
import java.nio.channels.spi.*;
import java.util.concurrent.*;

import cli.System.Net.Sockets.Socket;

/**
 * .NET implementation of AsynchronousSocketChannel.
 */
final class NetAsynchronousSocketChannel extends AsynchronousSocketChannel
{

    AsynchronousChannelGroup group;
    Socket socket;

    NetAsynchronousSocketChannel(AsynchronousChannelGroup group)
    {
        super(group.provider());
        this.group = group;
    }

    @Override
    public final native AsynchronousSocketChannel bind(SocketAddress local) throws IOException;
    
    @Override
    public final native <T> AsynchronousSocketChannel setOption(SocketOption<T> name, T value) throws IOException;
    
    @Override
    public final native SocketAddress getRemoteAddress() throws IOException;
    
    @Override
    public final native SocketAddress getLocalAddress() throws IOException;
    
    @Override
    public final native <A> void connect(SocketAddress remote, A attachment, CompletionHandler<Void, ? super A> handler);
    
    @Override
    public final native Future<Void> connect(SocketAddress remote);
    
    @Override
    public final native <A> void read(ByteBuffer dst, long timeout, TimeUnit unit, A attachment, CompletionHandler<Integer, ? super A> handler);
    
    @Override
    public final native Future<Integer> read(ByteBuffer dst);
    
    @Override
    public final native <A> void read(ByteBuffer[] dsts, int offset, int length, long timeout, TimeUnit unit, A attachment, CompletionHandler<Long, ? super A> handler);
    
    @Override
    public final native <A> void write(ByteBuffer src, long timeout, TimeUnit unit, A attachment, CompletionHandler<Integer, ? super A> handler);
    
    @Override
    public final native Future<Integer> write(ByteBuffer src);
    
    @Override
    public final native <A> void write(ByteBuffer[] srcs, int offset, int length, long timeout, TimeUnit unit, A attachment, CompletionHandler<Long, ? super A> handler);
    
    @Override
    public final native AsynchronousSocketChannel shutdownInput() throws IOException;
    
    @Override
    public final native AsynchronousSocketChannel shutdownOutput() throws IOException;
    
    @Override
    public final native void close();

}
