using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Event.Events
{
    public interface IEventPublisher
    {
        public Task PublishAsync<TEvent>(TEvent @event);
    }
}
