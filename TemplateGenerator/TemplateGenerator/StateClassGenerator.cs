using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFlow.TemplateScripts
{
    public partial class StateClassGenerator
    {
        public StateClassGenerator(string stateName, string contextName, string namespaceName)
        {
            this.stateName = stateName;
            this.contextName = contextName;
            this.namespaceName = namespaceName;
        }

        public string StateName { get { return stateName; } }
        private string stateName;

        public string ContextName { get { return contextName; } }
        private string contextName;

        public string NamespaceName { get { return namespaceName; } }
        private string namespaceName;
    }
}
