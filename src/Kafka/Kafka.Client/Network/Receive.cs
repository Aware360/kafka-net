﻿namespace Kafka.Client.Network
{
    using System.IO;

    /// <summary>
    /// A transmission that is being received from a channel
    /// </summary>
    public abstract class Receive : Transmission
    {
        public abstract MemoryStream Buffer { get; }

        public abstract int ReadFrom(Stream channel);

        public int ReadCompletely(Stream channel)
        {
            var totalRead = 0;
            while (!complete)
            {
                var read = this.ReadFrom(channel);
                Logger.DebugFormat("{0} bytes read", read);
                totalRead += read;
            }

            return totalRead;
        }
    }
}