
![alt text](https://github.com/Elouel/DevopsPractice/blob/main/devops%20.png)

Prerequisites: 
  1. Manualy set up kubernetes cluster.
  2. Install in the cluster Argocd.
  3. Configure new argo app.

Workflow:
  1. Pushing changes in the main branch on path: 'App/**' will trigger the CI/CD pipeline.
  2. CI/CD pipeline will perform series of jobs:
     - Scan the commit for commited secrets/ keys etc. (Gitleaks)
     - Build the application
        - Style checks.
     - Run unit tests
     - Static code analys with sonarcloud
     - Produce a docker image with the new version of the app
     - Push the immage in a container repository (currently Docker Hub)
     - Scan the newly created image for vulnerabilities via Snuk.
     - Change the kubernetes configs files and commit them back in the reppo on path: KubConfig/base
  3. ArgoCd check for changes in the kubernetes configuration files in the repo and apply changes in the kubernetes cluster.
 
 
 Future Imrpovements:
 
  1. CI/Cd changes
      - Add Code coverage to the sonarcloud report.
      - Produce the container immage with tag from the sha commit.
  3. Create the infra structure as a code with terraform and ansibel
      - Terraform to provision the needed infrastructure
      - Ansibel to install needed configurations and kubernetes cluster and installing the argo cd.
  4. Add Observability. 
      - Configure Prometheus to collect application data and metrics. Cluster metrics.
      - Grafana to visualize the data.
  5. Secret managment. 
  6. Argocd support multiple environments
      - Possible solutions:
          - Different branches for every environment
          - Different paths for every environment
          - Kubernetes template engine (kustomize, Helm)
      
