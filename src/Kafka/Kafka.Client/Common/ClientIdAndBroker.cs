namespace Kafka.Client.Common
{
    /// <summary>
    /// Convenience case class since (clientId, brokerInfo) pairs are used to create
    /// SyncProducer Request Stats and SimpleConsumer Request and Response Stats.
    /// </summary>
    public class ClientIdAndBroker : System.IEquatable<ClientIdAndBroker>
    {
        public string ClientId { get; private set; }

        public string BrokerInfo { get; private set; }

        public ClientIdAndBroker(string clientId, string brokerInfo)
        {
            this.ClientId = clientId;
            this.BrokerInfo = brokerInfo;
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}", this.ClientId, this.BrokerInfo);
        }
        public bool Equals(ClientIdAndBroker obj)
        {
            return ClientId.Equals(obj.ClientId) && BrokerInfo.Equals(obj.BrokerInfo);
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + ClientId.GetHashCode();
            hash = hash * 31 + BrokerInfo.GetHashCode();            
            return hash;
        }
    }
}