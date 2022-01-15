
![alt text](https://github.com/Elouel/DevopsPractice/blob/main/devops%20.png)

Prerequisites: 
  1. Manualy set up kubernetes cluster.
  2. Install in the cluster Argocd.
  3. Configure new argo app.

Workflow:
  1. Pushing changes in the main branch on path: 'App/**' will trigger the CI/CD pipeline.
  2. CI/CD pipeline will perform series of jobs:
     - Scan the commit for commited secrets/ keys etc. (Gitleaks)
     - Will build the application
     - Run unit tests
     - Static code analys with sonarcloud
     - Produce a docker image with the new version of the app
     - Push the immage in a container repository (currently Docker Hub)
     - Scan the newly created image for vulnerabilities via Snuk.
     - Change the kubernetes configs files and commit them back in the reppo on path: KubConfig/base
  3. ArgoCd check for changes in the kubernetes configuration files in the repo and apply changes in the kubernetes cluster.
  
