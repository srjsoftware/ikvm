using System;
using System.Net.Sockets;

using static IKVM.Java.Externs.java.net.SocketImplUtil;

namespace IKVM.Java.Externs.ikvm.nio.ch
{

    public static class NetAsynchronousServerSocketChannel
    {

        public static Socket createSocket(object this_)
        {
#if FIRST_PASS
            throw new NotSupportedException();
#else
            return SafeInvoke<global::ikvm.nio.ch.NetAsynchronousServerSocketChannel, Socket>(this_, impl =>
            {
                var socket = new Socket(SocketType.Stream, ProtocolType.Unspecified);

                // disable IPV6_V6ONLY to ensure dual-socket support
                if (Socket.OSSupportsIPv6)
                    socket.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, false);

                // this is a server socket then enable SO_REUSEADDR automatically
                socket.ExclusiveAddressUse = false;

                // initialize socket
                return socket;
            });
#endif
        }

        public static object bind(object this_, object local_, int backlog)
        {
#if FIRST_PASS
            throw new NotSupportedException();
#else
            return SafeInvoke<global::ikvm.nio.ch.NetAsynchronousServerSocketChannel, global::java.net.SocketAddress, global::ikvm.nio.ch.NetAsynchronousServerSocketChannel>(this_, local_, (impl, local) =>
            {
                return InvokeWithSocket(impl, socket =>
                {
                    socket.Bind(new IPEndPoint(local.ToIPAddress(), port));
                    return impl;
                });
            });
#endif
        }

#if !FIRST_PASS

        /// <summary>
        /// Invokes the given action with the current socket, catching and mapping any resulting .NET exceptions.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="impl"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="global::java.lang.NullPointerException"></exception>
        /// <exception cref="global::java.net.SocketException"></exception>
        static void InvokeWithSocket(global::ikvm.nio.ch.NetAsynchronousServerSocketChannel impl, Action<Socket> action)
        {
            var socket = (Socket)impl.getSocket();
            if (socket == null)
                throw new global::java.net.SocketException("Socket closed.");

            action(socket);
        }

        /// <summary>
        /// Invokes the given function with the current socket, catching and mapping any resulting .NET exceptions.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="impl"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        /// <exception cref="global::java.lang.NullPointerException"></exception>
        /// <exception cref="global::java.net.SocketException"></exception>
        static TResult InvokeWithSocket<TResult>(global::ikvm.nio.ch.NetAsynchronousServerSocketChannel impl, Func<Socket, TResult> func)
        {
            var socket = (Socket)impl.getSocket();
            if (socket == null)
                throw new global::java.net.SocketException("Socket closed.");

            return func(socket);
        }

    }

}

