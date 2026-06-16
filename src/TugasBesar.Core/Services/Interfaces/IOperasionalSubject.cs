using System;
using System.Collections.Generic;
using System.Text;

namespace TugasBesar.Core.Services.Interfaces
{
    public interface IOperasionalSubject
    {
        void Subscribe(IOperasionalObserver observer);
        void Unsubscribe(IOperasionalObserver observer);
        void NotifyOperasionalChanged();
    }
}
