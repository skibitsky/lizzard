//
//  UnityPureMVC C# Multicore
//
//  Copyright(c) 2017 Saad Shams <saad.shams@UnityPureMVC.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using System;
using System.Collections.Generic;
using UnityPureMVC.Interfaces;

namespace UnityPureMVC.Core
{
    /// <summary>
    /// A Multiton <c>IModel</c> implementation
    /// </summary>
    /// <remarks>
    ///     <para>In UnityPureMVC, the <c>Model</c> class provides access to model objects (ProxyNames) by named lookup</para>
    ///     <para>The <c>Model</c> assumes these responsibilities:</para>
    ///     <list type="bullet">
    ///         <item>Maintain a cache of <c>IProxy</c> instances</item>
    ///         <item>Provide methods for registering, retrieving, and removing <c>IProxy</c> instances</item>
    ///     </list>
    ///     <para>
    ///         Your application must register <c>IProxy</c> instances
    ///         with the <c>Model</c>. Typically, you use an 
    ///         <c>ICommand</c> to create and register <c>IProxy</c> 
    ///         instances once the <c>Facade</c> has initialized the Core actors
    ///     </para>
    /// </remarks>
    /// <seealso cref="UnityPureMVC.Patterns.Proxy"/>
    /// <seealso cref="UnityPureMVC.Interfaces.IProxy" />
    public class Model: IModel
    {
        public static IModel GetInstance
        {
            get
            {
                if (Model.Instance != null) return Model.Instance;
                return Model.Instance ?? (Model.Instance = new Model());
            }
        }

        /// <summary>
        /// Constructs and initializes a new model
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         This <c>IModel</c> implementation is a Multiton, 
        ///         so you should not call the constructor 
        ///         directly, but instead call the static Multiton 
        ///     </para>
        /// </remarks>
        public Model()
        {
            ProxyMap = new Dictionary<string, IProxy>();
            InitializeModel();
        }

        /// <summary>
        /// Initialize the Multiton <c>Model</c> instance.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Called automatically by the constructor, this 
        ///         is your opportunity to initialize the Multiton 
        ///         instance in your subclass without overriding the 
        ///         constructor
        ///     </para>
        /// </remarks>
        protected virtual void InitializeModel()
        {
        }

        /// <summary>
        /// Register an <c>IProxy</c> with the <c>Model</c>.
        /// </summary>
        /// <param name="proxy">proxy an <c>IProxy</c> to be held by the <c>Model</c>.</param>
        public virtual void RegisterProxy(IProxy proxy)
        {
            ProxyMap[proxy.ProxyName] = proxy;
            proxy.OnRegister();
        }

        /// <summary>
        /// Retrieve an <c>IProxy</c> from the <c>Model</c>.
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns>the <c>IProxy</c> instance previously registered with the given <c>proxyName</c>.</returns>
        public virtual IProxy RetrieveProxy(string proxyName)
        {
            IProxy proxy;
            ProxyMap.TryGetValue(proxyName, out proxy);
            return proxy;
        }

        /// <summary>
        /// Remove an <c>IProxy</c> from the <c>Model</c>.
        /// </summary>
        /// <param name="proxyName">proxyName name of the <c>IProxy</c> instance to be removed.</param>
        /// <returns>the <c>IProxy</c> that was removed from the <c>Model</c></returns>
        public virtual IProxy RemoveProxy(string proxyName)
        {
            var proxy = ProxyMap[proxyName];
            if (proxy == null) return null;
            proxy.OnRemove();
            return proxy;
        }

        /// <summary>
        /// Check if a Proxy is registered
        /// </summary>
        /// <param name="proxyName"></param>
        /// <returns>whether a Proxy is currently registered with the given <c>proxyName</c>.</returns>
        public virtual bool HasProxy(string proxyName)
        {
            return ProxyMap.ContainsKey(proxyName);
        }

        protected static IModel Instance;

        /// <summary>Mapping of proxyNames to IProxy instances</summary>
        protected readonly IDictionary<string, IProxy> ProxyMap;
    }
}
