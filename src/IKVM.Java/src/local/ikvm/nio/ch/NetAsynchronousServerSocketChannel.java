package ikvm.nio.ch;

import java.io.*;
import java.nio.channels.*;
import java.util.concurrent.*;

import cli.System.Net.Sockets.Socket;

/**
 * .NET implementation of AsynchronousServerSocketChannel.
 */
final class NetAsynchronousServerSocketChannel extends AsynchronousServerSocketChannel
{

    private Socket socket;

    NetAsynchronousServerSocketChannel(AsynchronousChannelGroup group) throws IOException
    {
        super(group.provider());

        this.socket = createSocket();
    }

    private native Socket createSocket();

    Socket getSocket()
    {
        return socket;
    }

    @Override
    public native AsynchronousServerSocketChannel bind(SocketAddress local, int backlog);
    
    @Override
    public native <T> AsynchronousServerSocketChannel setOption(SocketOption<T> name, T value) throws IOException;
    
    @Override
    public native SocketAddress getLocalAddress() throws IOException;

    @Override
    public native <A> void accept(A attachment, CompletionHandler<AsynchronousSocketChannel, ? super A> handler);

    @Override
    public native Future<AsynchronousSocketChannel> accept();
    
    @Override
    public native void close() throws IOException;

}
