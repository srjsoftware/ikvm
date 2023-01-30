package sun.nio.ch;

public class NativeThread {

    private static native long current0();

    private static native void signal0(long nt);

    public static long current() {
        return current0();
    }

    public static void signal(long nt) {
        signal0(nt);
    }

}
