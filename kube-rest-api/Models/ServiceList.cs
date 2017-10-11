using System;

namespace Kube.RestApi.Models
{
    public class ServiceList
    {
        public string kind { get; set; }
        public string apiVersion { get; set; }
        public Metadata metadata { get; set; }
        public Item[] items { get; set; }
    }

    public class Metadata
    {
        public string selfLink { get; set; }
        public string resourceVersion { get; set; }
    }

    public class Item
    {
        public Metadata1 metadata { get; set; }
        public Spec spec { get; set; }
        public Status status { get; set; }
    }

    public class Metadata1
    {
        public string name { get; set; }
        public string _namespace { get; set; }
        public string selfLink { get; set; }
        public string uid { get; set; }
        public string resourceVersion { get; set; }
        public DateTime creationTimestamp { get; set; }
        public Labels labels { get; set; }
        public Annotations annotations { get; set; }
    }

    public class Labels
    {
        public string component { get; set; }
        public string provider { get; set; }
        public string app { get; set; }
        public string chart { get; set; }
        public string heritage { get; set; }
        public string release { get; set; }
        public string kubernetesioclusterservice { get; set; }
        public string kubernetesioname { get; set; }
        public string k8sapp { get; set; }
        public string name { get; set; }
    }

    public class Annotations
    {
        public string kubectlkubernetesiolastappliedconfiguration { get; set; }
    }

    public class Spec
    {
        public Port[] ports { get; set; }
        public string clusterIP { get; set; }
        public string type { get; set; }
        public string sessionAffinity { get; set; }
        public Selector selector { get; set; }
    }

    public class Selector
    {
        public string app { get; set; }
        public string k8sapp { get; set; }
        public string name { get; set; }
    }

    public class Port
    {
        public string name { get; set; }
        public string protocol { get; set; }
        public int port { get; set; }
        public object targetPort { get; set; }
        public int nodePort { get; set; }
    }

    public class Status
    {
        public Loadbalancer loadBalancer { get; set; }
    }

    public class Loadbalancer
    {
        public Ingress[] ingress { get; set; }
    }

    public class Ingress
    {
        public string ip { get; set; }
    }
}
