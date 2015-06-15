﻿using System;
using ZeroMQ.Helpers.Interfaces;

namespace ZeroMQ.Helpers.Wrappers
{
    public class ContextWrapper : IContext
    {
        public ZContext Context { get; private set; }


        public string Address { get; private set; }

        public ContextWrapper(string address)
            : this(new ZContext(), address)
        {
        }

        internal ContextWrapper(ZContext context, string address)
        {
            Context = context;
            Address = address;
        }

    }
}
