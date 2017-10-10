# TEAM20 openhack

# connect to the kubernetes cluster
download the kube-config and move into ~/.kube
```
ls ~/.kube
export KUBECONFIG=~/.kube/kube-config
kubectl cluster-info
kubectl get all
```

# install helm
see https://docs.helm.sh/using_helm/#installing-helm
```

brew install kubernetes-helm
helm init
# connect to remote
kubectl get pods --namespace kube-system
helm version
```
make sure both versions are the same.

# install minecraft
```
helm install --name my-release --set minecraftServer.eula=true stable/minecraft
kubectl get all
# change the deployment image to: openhack/minecraft-server:2.0
kubectl edit deploy/my-release-minecraft
```

To mkae you
