public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        var buffer = new byte[9];

        //ushort
        if(reading >= ushort.MinValue && reading <= ushort.MaxValue)
        {
            ushort value = (ushort)reading;
            byte[] payload = BitConverter.GetBytes(value);

            buffer[0] = (byte)payload.Length;

            Array.Copy(payload,0,buffer,1,payload.Length);
            return buffer;
        }
        
        else // Caso o valor caiba em short (-32768 até 32767)
        if (reading >= short.MinValue && reading <= short.MaxValue)
        {
            short value = (short)reading;
            byte[] payload = BitConverter.GetBytes(value);

            // signed → prefix = 256 - payload.Length
            buffer[0] = (byte)(256 - payload.Length); // 256 - 2 = 254

            Array.Copy(payload, 0, buffer, 1, payload.Length);
            return buffer;
        }
        //int
        else if(reading >= int.MinValue && reading <= int.MaxValue)
        {
            int value = (int)reading;
            byte[] payload = BitConverter.GetBytes(value);

            buffer[0] = (byte)(256 - payload.Length);

            Array.Copy(payload,0,buffer,1,payload.Length);
            return buffer;
        }
        //uint
        else if(reading >= uint.MinValue && reading <= uint.MaxValue)
        {
            uint value = (uint)reading;
            byte[] payload = BitConverter.GetBytes(value);

            buffer[0] = (byte)payload.Length;

            Array.Copy(payload,0,buffer,1,payload.Length);
            return buffer;
        }
        //long
        else
        {
            long value = (long)reading;
            byte[] payload = BitConverter.GetBytes(value);

            buffer[0] = (byte)(256 - payload.Length);

            Array.Copy(payload,0,buffer,1,payload.Length);
            return buffer;
        }

    }

    public static long FromBuffer(byte[] buffer)
{
    byte prefix = buffer[0];
    int size;
    bool isSigned;

    if (prefix > 8)
    {
        // signed
        size = 256 - prefix;
        isSigned = true;
    }
    else
    {
        // unsigned
        size = prefix;
        isSigned = false;
    }
    if (buffer.Length < 1 + size)
        return 0;
    byte[] payload = new byte[size];
    Array.Copy(buffer, 1, payload, 0, size);

    if (size == 2 && isSigned) return BitConverter.ToInt16(payload, 0);
    if (size == 2 && !isSigned) return BitConverter.ToUInt16(payload, 0);
    if (size == 4 && isSigned) return BitConverter.ToInt32(payload, 0);
    if (size == 4 && !isSigned) return BitConverter.ToUInt32(payload, 0);
    if (size == 8 && isSigned) return BitConverter.ToInt64(payload, 0);
    return -1;

}
}