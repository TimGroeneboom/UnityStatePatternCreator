using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFlow.TemplateScripts
{
    public partial class ContextClassGenerator
    {
        public ContextClassGenerator(string contextName, string namespaceName, string[] states)
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
