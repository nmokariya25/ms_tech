namespace IAFLogistic_DemandManagementService.MQ
{
    public interface IRabitMQProducer
    {
        public void SendMessage<T>(T message);

    }
}
