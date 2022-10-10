using MassTransit;
using MassTransit.Mediator;

namespace Catalogs.Tests
{
    public class MediatorFake : IMediator
    {
        public List<object> sentEvents = new List<object>();

        public ClientFactoryContext Context => throw new NotImplementedException();

        public ConnectHandle ConnectConsumeMessageObserver<T>(IConsumeMessageObserver<T> observer) where T : class
        {
            throw new NotImplementedException();
        }

        public ConnectHandle ConnectConsumeObserver(IConsumeObserver observer)
        {
            throw new NotImplementedException();
        }

        public ConnectHandle ConnectConsumePipe<T>(IPipe<ConsumeContext<T>> pipe) where T : class
        {
            throw new NotImplementedException();
        }

        public ConnectHandle ConnectConsumePipe<T>(IPipe<ConsumeContext<T>> pipe, ConnectPipeOptions options) where T : class
        {
            throw new NotImplementedException();
        }

        public ConnectHandle ConnectPublishObserver(IPublishObserver observer)
        {
            throw new NotImplementedException();
        }

        public ConnectHandle ConnectRequestPipe<T>(Guid requestId, IPipe<ConsumeContext<T>> pipe) where T : class
        {
            throw new NotImplementedException();
        }

        public ConnectHandle ConnectSendObserver(ISendObserver observer)
        {
            throw new NotImplementedException();
        }

        public RequestHandle<T> CreateRequest<T>(T message, CancellationToken cancellationToken = default, RequestTimeout timeout = default) where T : class
        {
            throw new NotImplementedException();
        }

        public RequestHandle<T> CreateRequest<T>(Uri destinationAddress, T message, CancellationToken cancellationToken = default, RequestTimeout timeout = default) where T : class
        {
            throw new NotImplementedException();
        }

        public RequestHandle<T> CreateRequest<T>(ConsumeContext consumeContext, T message, CancellationToken cancellationToken = default, RequestTimeout timeout = default) where T : class
        {
            throw new NotImplementedException();
        }

        public RequestHandle<T> CreateRequest<T>(ConsumeContext consumeContext, Uri destinationAddress, T message, CancellationToken cancellationToken = default, RequestTimeout timeout = default) where T : class
        {
            throw new NotImplementedException();
        }

        public RequestHandle<T> CreateRequest<T>(object values, CancellationToken cancellationToken = default, RequestTimeout timeout = default) where T : class
        {
            throw new NotImplementedException();
        }

        public RequestHandle<T> CreateRequest<T>(Uri destinationAddress, object values, CancellationToken cancellationToken = default, RequestTimeout timeout = default) where T : class
        {
            throw new NotImplementedException();
        }

        public RequestHandle<T> CreateRequest<T>(ConsumeContext consumeContext, object values, CancellationToken cancellationToken = default, RequestTimeout timeout = default) where T : class
        {
            throw new NotImplementedException();
        }

        public RequestHandle<T> CreateRequest<T>(ConsumeContext consumeContext, Uri destinationAddress, object values, CancellationToken cancellationToken = default, RequestTimeout timeout = default) where T : class
        {
            throw new NotImplementedException();
        }

        public IRequestClient<T> CreateRequestClient<T>(RequestTimeout timeout = default) where T : class
        {
            throw new NotImplementedException();
        }

        public IRequestClient<T> CreateRequestClient<T>(ConsumeContext consumeContext, RequestTimeout timeout = default) where T : class
        {
            throw new NotImplementedException();
        }

        public IRequestClient<T> CreateRequestClient<T>(Uri destinationAddress, RequestTimeout timeout = default) where T : class
        {
            throw new NotImplementedException();
        }

        public IRequestClient<T> CreateRequestClient<T>(ConsumeContext consumeContext, Uri destinationAddress, RequestTimeout timeout = default) where T : class
        {
            throw new NotImplementedException();
        }

        public Task Publish<T>(T message, CancellationToken cancellationToken = default) where T : class
        {
            throw new NotImplementedException();
        }

        public Task Publish<T>(T message, IPipe<PublishContext<T>> publishPipe, CancellationToken cancellationToken = default) where T : class
        {
            throw new NotImplementedException();
        }

        public Task Publish<T>(T message, IPipe<PublishContext> publishPipe, CancellationToken cancellationToken = default) where T : class
        {
            throw new NotImplementedException();
        }

        public Task Publish(object message, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Publish(object message, IPipe<PublishContext> publishPipe, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Publish(object message, Type messageType, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Publish(object message, Type messageType, IPipe<PublishContext> publishPipe, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Publish<T>(object values, CancellationToken cancellationToken = default) where T : class
        {
            throw new NotImplementedException();
        }

        public Task Publish<T>(object values, IPipe<PublishContext<T>> publishPipe, CancellationToken cancellationToken = default) where T : class
        {
            throw new NotImplementedException();
        }

        public Task Publish<T>(object values, IPipe<PublishContext> publishPipe, CancellationToken cancellationToken = default) where T : class
        {
            throw new NotImplementedException();
        }

        public Task Send<T>(T message, CancellationToken cancellationToken = default) where T : class
        {
            sentEvents.Add(message);
            return Task.CompletedTask;
        }

        public Task Send<T>(T message, IPipe<SendContext<T>> pipe, CancellationToken cancellationToken = default) where T : class
        {
            throw new NotImplementedException();
        }

        public Task Send<T>(T message, IPipe<SendContext> pipe, CancellationToken cancellationToken = default) where T : class
        {
            throw new NotImplementedException();
        }

        public Task Send(object message, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Send(object message, Type messageType, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Send(object message, IPipe<SendContext> pipe, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Send(object message, Type messageType, IPipe<SendContext> pipe, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task Send<T>(object values, CancellationToken cancellationToken = default) where T : class
        {
            throw new NotImplementedException();
        }

        public Task Send<T>(object values, IPipe<SendContext<T>> pipe, CancellationToken cancellationToken = default) where T : class
        {
            throw new NotImplementedException();
        }

        public Task Send<T>(object values, IPipe<SendContext> pipe, CancellationToken cancellationToken = default) where T : class
        {
            throw new NotImplementedException();
        }

        public bool HasEvent(object @event)
        {
            return sentEvents.Contains(@event);
        }
    }
}