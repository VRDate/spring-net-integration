#region License

/*
 * Copyright 2002-2009 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF Any KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

using Spring.Integration.Core;
using Spring.Integration.Gateway;

namespace Spring.Integration.Adapter {
    /// <summary>
    /// Support class for inbound Messaging Gateways.
    /// </summary>
    /// <author>Mark Fisher</author>
    /// <author>Andreas D�hring (.NET)</author>
    public abstract class RemotingInboundGatewaySupport : SimpleMessagingGateway, IRemoteMessageHandler {

        private volatile bool _expectReply = true;


        /**
         * Specify whether the gateway should be expected to return a reply.
         * The default is '<code>true</code>'.
         */
        public bool ExpectReply {
            set { _expectReply = value; }
        }

        public IMessage Handle(IMessage message) {
            if(_expectReply) {
                return SendAndReceiveMessage(message);
            }
            Send(message);
            return null;
        }
    }
}
