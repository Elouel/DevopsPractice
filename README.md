
![alt text](https://github.com/Elouel/DevopsPractice/blob/main/devops%20.png)


Prerequisites: 
  1. Manualy set up Kubernetes cluster (https://minikube.sigs.k8s.io/docs/start)
  2. Install in the cluster ArgoCD (https://argo-cd.readthedocs.io/en/stable/getting_started/)
  3. Configure new ArgoCD app

Workflow:
  1. Pushing changes in the main branch on path: 'App/**' will trigger the CI/CD pipeline
  2. CI/CD pipeline will perform series of jobs:
     - Scan the commit for commited secrets/ keys etc. (Gitleaks)
     - Build the application
        - Style checks
     - Run unit tests
     - Static code analysis with SonarCloud
     - Build a Docker image with the new version of the app
     - Push the image in a container repository (currently Docker Hub)
     - Scan the newly created image for vulnerabilities via Snuk
     - Change the Kubernetes configuration files and commit them back in the repo on path: KubConfig/Dev
  3. ArgoCD checks repo for changes in the Kubernetes configuration files and applies these in the Kubernetes cluster if such found 
 API Documentation:
    http://{cluseterIp}/swagger/index.html
 Future Improvements:
 
  1. CI/CD changes:
      - Add code coverage to the SonarCloud report
      - Add tag to the built Docker image from the commit SHA
  2. Create the infrastructure as a code with Terraform
  3. Add observability 
      - Configure Prometheus to collect application data and metrics
      - Grafana to visualize the data
  4. Secret managment
  5. ArgoCD support of multiple environments
      - Possible solutions:
          - Different branches for every environment
          - Different paths for every environment
          - using Kubernetes Kustomize/Helm
      
