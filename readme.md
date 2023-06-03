- Purpose of this demo is to confirm how to override a .Net appsettings.json file in kubernetes. A simple .Net Core 6 WebApi was created and pushed to dockerhub, which has a single endpoint /api/settings, which returns a message. This message is changed in the kubernetes appsettings configMap, and this updated message should be the one displayed when run in a kubernetes cluster  

- image was built locally and pushed to dockerhub as easier than using local image

- run kubectl commands to create
kubectl apply -f demoapi-configmap.yaml
kubectl apply -f demoapi-deployment.yaml
kubectl apply -f demoapi-service.yaml

- make service available in the browser - works for both minikube and Kind
kubectl port-forward service/demoapi-service 5200:5200
http://localhost:5200/swagger/index.html

- when you run the /api/settings endpoint you will see the message from the demoapi-configmap rather than the application's appsettings value

- Learnings
.Net 6 has a new template, in that Startup has been combined into Program
.Net 6 now has minimal API feature with no Main - which is required when building the docker image - so needed to add
*** Without Logging configured the kubernetes pod would crash ****
Added Serilog to prevent Pod crashing
Removed check for in development around swagger, so swagger page could be seen from kubernetes pod
*** Dockerfile needed 3 vital changes ***
-- remove project dir from first COPY e.g. COPY["DemoApi.proj", "DemoApi"] not COPY["DemoApi/DemoApi.proj", "DemoApi"]
-- add dest dir to second COPY e.g. COPY . ./DemoApi not COPY . ./
-- change exposed port in dockerfile from 80 to something else e.g. EXPOSE 8080 rather than EXPOSE 80








