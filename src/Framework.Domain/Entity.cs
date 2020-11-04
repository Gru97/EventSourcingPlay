using System;

namespace Framework.Domain
{
    public class Entity<T>
    {
        public T Id { get; protected set; }
    }
}
