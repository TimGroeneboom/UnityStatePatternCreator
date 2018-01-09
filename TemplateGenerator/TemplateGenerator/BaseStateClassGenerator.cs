using System;
using System.Collections.Generic;

namespace CodeFlow.TemplateScripts
{
    public partial class BaseStateClassGenerator
    {
        public BaseStateClassGenerator(string contextName, string namespaceName, string[] states)
        {
            this.contextName = contextName;
            this.namespaceName = namespaceName;
            this.states = states;
        }

        public string[] States { get { return states; } }
        private string[] states;

        public string ContextName { get { return contextName; } }
        private string contextName;

        public string NamespaceName { get { return namespaceName; } }
        private string namespaceName;
    }
}
